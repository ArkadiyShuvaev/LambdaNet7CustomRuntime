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
        Func<string, ILambdaContext, string> handler = FunctionHandler;
        await LambdaBootstrapBuilder.Create(handler, new DefaultLambdaJsonSerializer())
            .Build()
            .RunAsync();
    }

    public static string FunctionHandler(string input, ILambdaContext context)
    {
        var architecture = System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture;
        var dotnetVersion = Environment.Version.ToString();
        return $"Architecture: {architecture}, .NET Version: {dotnetVersion} -- {input?.ToUpper()}";
    }
}
