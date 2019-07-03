﻿using IF.Core.Sms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Linq;

namespace IF.Sms.Turatel
{
    

    public class TuratelSmsService: IIFSmsService
    {

        private readonly HttpClient httpClient;
        private readonly IFSmsSettings settings;

        public TuratelSmsService(HttpClient httpClient, IFSmsSettings settings)
        {
            this.httpClient = httpClient;
            this.settings = settings;
        }


        public IFSmsResponse SendSms(IFSmsRequest request)
        {
            IFSmsResponse response = new IFSmsResponse();

            try
            {
                var result = this.MesajGonder(request.Subject, request.Message, request.Numbers, null);

                response.IsSuccess = result.IsSuccess;
                response.Code = result.Code.ToString();
                response.ErrorMessage = result.Desc;
            }
            catch (Exception ex)
            {
                response.FromException(ex);
            }

            return response;
        }

     

        private HttpClient GetHttpClient()
        {
            
          
            return this.httpClient;
        }

       

        public SmsLimitResult KrediDurum()
        {
            throw new NotImplementedException();
        }

        public SmsResult MesajGonder(string başlık, string mesaj, List<string> numaralar, DateTime? ileritarih)
        {
            var doc = new XDocument(
                new XElement("MainmsgBody",
                    new XElement("Command", "0"),
                    new XElement("PlatformID", "1"),
                    new XElement("ChannelCode", settings.ChannelCode),
                    new XElement("UserName", settings.UserName),
                    new XElement("PassWord", settings.Password),
                    new XElement("Type", "1"),
                    new XElement("Concat", "1"),
                    new XElement("Option", "1"),
                    new XElement("Originator", başlık),
                    new XElement("Mesgbody", mesaj),
                    new XElement("Numbers", string.Join(",", numaralar)),
                    new XElement("SDate", "")
                )
            );


            var response = Gonder(doc);

            return response;
        }

        public SmsResult MesajGonderDogrulamKodu(string başlık, string mesaj, string numara)
        {
            var dogrulamaKodu = new Random().Next(100000, 999999);
            var doc = new XDocument(
                new XElement("MainmsgBody",
                    new XElement("Command", "0"),
                    new XElement("PlatformID", "1"),
                    new XElement("ChannelCode", settings.ChannelCode),
                    new XElement("UserName", settings.UserName),
                    new XElement("PassWord", settings.Password),
                    new XElement("Type", "1"),
                    new XElement("Concat", "1"),
                    new XElement("Option", "1"),
                    new XElement("Originator", başlık),
                    new XElement("Mesgbody", mesaj.Replace("@kod", dogrulamaKodu.ToString())),
                    new XElement("Numbers", numara),
                    new XElement("SDate", "")
                )
            );

            var response = Gonder(doc);
            response.EncryptedCode = GetSHA1(dogrulamaKodu.ToString());
            return response;
        }

        private SmsResult Gonder(XDocument document)
        {
            document.Declaration = new XDeclaration("1.0", "utf-8", null);
            var model = new SmsResult { IsSuccess = true };

            this.httpClient.BaseAddress = new Uri("https://processor.smsorigin.com");
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            this.httpClient.MaxResponseContentBufferSize = Int32.MaxValue;


            var httpContent = new StringContent(document.ToString(), Encoding.UTF8, "text/html");

            var response = this.httpClient.PostAsync("xml/process.aspx", httpContent).Result;
            var returnValue = response.Content.ReadAsStringAsync().Result;
            if (!response.IsSuccessStatusCode)
            {
                model.IsSuccess = false;
            }

            model.Desc = returnValue;
            model.IntegrationId = returnValue.Replace("ID", "").Replace(":", "");

            return model;
        }

        private string GetSHA1(string temp)
        {
            using (var sha1 = new System.Security.Cryptography.SHA1Managed())
            {
                var hash = sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(temp));
                var sb = new System.Text.StringBuilder(hash.Length * 2);
                foreach (byte bb in hash)
                {
                    sb.Append(bb.ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}
