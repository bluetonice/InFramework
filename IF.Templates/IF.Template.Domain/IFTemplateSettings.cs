﻿using IF.Configuration;
using IF.Core.Configuration;
using IF.Core.Database;
using IF.Core.MongoDb;
using IF.Core.RabbitMQ;
using IF.Core.Sms;
using System;

namespace IF.Template.Domain
{

    public interface IIFTemplateSettings : IAppSettingsCore
    {
        RabbitMQConnectionSettings RabbitMQConnection { get; set; }
        DatabaseSettings Database { get; set; }

        IFSmsSettings IFSms { get; set; }

        MongoConnectionSettings MongoConnection { get; set; }
    }

    public class IFTemplateSettings : AppSettingsCore, IIFTemplateSettings
    {

        public RabbitMQConnectionSettings RabbitMQConnection { get; set; }

        public IFSmsSettings IFSms { get; set; }

        public DatabaseSettings Database { get; set; }

        public MongoConnectionSettings MongoConnection { get; set; }

    }
}
