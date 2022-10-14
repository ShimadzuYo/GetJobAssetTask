// See https://aka.ms/new-console-template for more information

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using App1;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using Serilog;
using Serilog.Core;


var httpClient = new HttpClient();

void Main(string[] args)
{
    var logFilePath = "C:\\Users\\timelysoft\\RiderProjects\\App1\\App1\\App1.csproj";
    Log.Logger = new LoggerConfiguration().WriteTo.File(logFilePath).CreateLogger();

    var token =
        "eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJSYWNpYm9yc2tpLlRvbWFzeiIsImlhdCI6MTUxNjIzOTAyMiwiZXhwIjoxNjkxNjg5NTE3LCJuYW1lIjoiUmFjaWJvcnNraS5Ub21hc3oiLCJpc3MiOiJtb2NrX2p3dF9pc3N1ZXIiLCJ1c2lkIjoiUmFjaWJvcnNraS5Ub21hc3oiLCJvaWQiOiJzdXBlcl9wcm92aWRlcl9kZXZfb3JnIn0.52LILp9J3QCZxlfnzlxOjO3FsqEBp1YqN5kUEYVotBk";
    httpClient.BaseAddress = new Uri("https://content-provider-api.staging.lionbridge.com/v2/swagger/index.html#/");
    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

    var a = File.ReadAllLines("C:\\Users\\timelysoft\\RiderProjects\\App1\\App1\\shit.json");

    var jobId = "";
    var providerId = "";
}


async Task<Job> GetJobDetails(httpClient client, string jobId, string providerId)
{
    var httpResponseMessage = await httpClient.GetAsync($"v2/providers/{providerId}/jobs/{jobId}");
    var responseContentAsString = await httpResponseMessage.Content.ReadAsStringAsync();
    var job = JsonSerializer.Deserialize<Job>(responseContentAsString);
    Serilog.Log.Information();
}