﻿using IF.Core.Data;
using IF.Core.Json;
using IF.Core.Log;
using IF.MongoDB.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IF.MongoDB
{
    public class MongoAuditLogService : IAuditLogService
    {

        private readonly IMongoAuditLogRepository mongoLogRepository;
        private readonly IJsonSerializer jsonSerializer;

        public MongoAuditLogService(IMongoAuditLogRepository mongoLogRepository, IJsonSerializer jsonSerializer)
        {
            this.mongoLogRepository = mongoLogRepository;
            this.jsonSerializer = jsonSerializer;
        }

        public async Task<IAuditLog> GetDetailAsync(Guid uniqueId)
        {
            return await this.mongoLogRepository.GetDetailAsync(uniqueId);
        }


        public async Task<PagedListResponse<IAuditLog>> GetPaginatedAsync(DateTime BeginDate, DateTime EndDate, string Source, string UserId, int skipNumber = 0, int takeNumber = 50)
        {
            return await this.mongoLogRepository.GetPaginatedAsync(BeginDate, EndDate, Source, UserId, skipNumber , takeNumber );
        }

        public void Log(object @object, Guid uniqueId, DateTime LogDate, string objectName, string IpAdress, string Channel,string UserId)
        {
            AuditLog auditLog = new AuditLog();
            auditLog.ObjectName = objectName;
            auditLog.UniqueId = uniqueId;
            auditLog.JsonObject = jsonSerializer.Serialize(@object);
            auditLog.Channel = Channel;
            auditLog.ClientId = IpAdress;
            auditLog.UserId = UserId;
            this.mongoLogRepository.AddLog(auditLog);
        }

        public async Task LogAsync(object @object, Guid uniqueId, DateTime LogDate,string objectName,string ClientId,string Channel,string UserId)
        {
            AuditLog auditLog = new AuditLog();
            auditLog.ObjectName = objectName;
            auditLog.UniqueId = uniqueId;
            auditLog.JsonObject = jsonSerializer.Serialize(@object);
            auditLog.Channel = Channel;
            auditLog.ClientId = ClientId;
            auditLog.UserId = UserId;
            await this.mongoLogRepository.AddLogAsync(auditLog).ConfigureAwait(false);

        }
    }
}
