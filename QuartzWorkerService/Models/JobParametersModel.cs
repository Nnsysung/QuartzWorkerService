using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace QuartzWorkerService.Models
{
    public sealed class JobParametersModel
    {
        [JsonProperty("iterations")]
        public uint Iterations { get; set; }

        [JsonProperty("seedData")]
        public uint SeedData { get; set; }
    }
}
