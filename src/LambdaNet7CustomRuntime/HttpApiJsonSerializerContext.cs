using Amazon.Lambda.ApplicationLoadBalancerEvents;
using System.Text.Json.Serialization;

namespace LambdaNet7CustomRuntime
{
    [JsonSerializable(typeof(ApplicationLoadBalancerRequest))]
    [JsonSerializable(typeof(ApplicationLoadBalancerResponse))]
    public partial class HttpApiJsonSerializerContext : JsonSerializerContext
    {
    }
}
