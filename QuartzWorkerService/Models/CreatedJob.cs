using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace QuartzWorkerService.Models
{
   public sealed class CreatedJob
    {
        [JsonProperty("jobId")]
        public string JobId { get; set; }
        [JsonProperty("queuePosition")]
        public int QueuePosition { get; set; }
    }
}
