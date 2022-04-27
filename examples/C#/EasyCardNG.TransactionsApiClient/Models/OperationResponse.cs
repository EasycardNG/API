using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Shared.Api.Models.Enums;
using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Shared.Api.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class OperationResponse
    {
        public OperationResponse()
        {
        }

        public OperationResponse(string message, StatusEnum status)
        {
            Message = message;
            Status = status;
        }

        public OperationResponse(string message, StatusEnum status, Guid? entityUid = null, string correlationId = null, IEnumerable<Error> errors = null)
        {
            Message = message;
            Status = status;
            EntityReference = entityUid.ToString();
            EntityUID = entityUid;
            CorrelationId = correlationId;
            Errors = errors?.Select(d => d).ToList();
        }

        public OperationResponse(string message, Guid? entityUid, string correlationId, string errorCode, string errorDescription)
        {
            Message = message;
            Status = StatusEnum.Error;
            EntityReference = entityUid.ToString();
            EntityUID = entityUid;
            CorrelationId = correlationId;
            Errors = new List<Error> { new Error(errorCode, errorDescription) };
        }

        public OperationResponse(string message, StatusEnum status, Guid? entityUid = null)
        {
            Message = message;
            Status = status;
            EntityReference = entityUid.ToString();
            EntityUID = entityUid;
        }

        public OperationResponse(string message, StatusEnum status, string entityReference)
        {
            Message = message;
            Status = status;
            EntityReference = entityReference;
        }

        public string Message { get; set; }

        [EnumDataType(typeof(StatusEnum))]
        [JsonConverter(typeof(StringEnumConverter))]
        public StatusEnum? Status { get; set; }

        public long? EntityID { get; set; }

        public Guid? EntityUID { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string EntityReference { get; set; }

        public string CorrelationId { get; set; }

        public string EntityType { get; set; }

        public IEnumerable<Error> Errors { get; set; }

        public string ConcurrencyToken { get; set; }

        public OperationResponse InnerResponse { get; set; }

        public JObject AdditionalData { get; set; }
    }
}
