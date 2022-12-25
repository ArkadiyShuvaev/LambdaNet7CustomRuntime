using Amazon.Lambda.ApplicationLoadBalancerEvents;
using Amazon.Lambda.Core;
using Amazon.Lambda.RuntimeSupport;
using Amazon.Lambda.Serialization.SystemTextJson;

namespace LambdaNet7CustomRuntime;

public class Function
{
    /// <summary>
    /// The main entry point for the custom runtime.
    /// </summary>
    /// <param name="args"></param>
    private static async Task Main(string[] args)
    {
        Func<ApplicationLoadBalancerRequest, ILambdaContext, Task<ApplicationLoadBalancerResponse>> handler = FunctionHandlerAsync;
        await LambdaBootstrapBuilder.Create(handler, new SourceGeneratorLambdaJsonSerializer<HttpApiJsonSerializerContext>())
            .Build()
            .RunAsync();
    }

    public static async Task<ApplicationLoadBalancerResponse> FunctionHandlerAsync(ApplicationLoadBalancerRequest request, ILambdaContext context)
    {
        var architecture = System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture;
        var dotnetVersion = Environment.Version.ToString();

        return new ApplicationLoadBalancerResponse
        {
            Body = $"Architecture: {architecture}, .NET Version: {dotnetVersion} -- {request?.Body.ToUpper()}",
            StatusCode = 200
        };
    }
}
