using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace api
{
    public static class FetchVisitorCounter
    {
        [FunctionName("FetchVisitorCounter")]
        public static HttpResponseMessage Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
        [CosmosDB(databaseName: "AzureResume", collectionName: "Counter", ConnectionStringSetting = "AzureResumeConnectionString", Id = "1", PartitionKey = "1")] Counter counter,
        [CosmosDB(databaseName: "AzureResume", collectionName: "Counter", ConnectionStringSetting = "AzureResumeConnectionString", Id = "1", PartitionKey = "1")] out Counter updatedcounter,
        ILogger log)
        {
            //Counter gets updated here.
            log.LogInformation("C# HTTP trigger function processed a request.");

            counter.Count += 1;
            updatedcounter = counter;

            var jsonToRetun = JsonConvert.SerializeObject(updatedcounter);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(jsonToRetun, Encoding.UTF8, "application/json")
            };
            
        }
    }
}
    
