## How to test
Run ~/.dotnet/tools/dotnet-lambda-test-tool-7.0 in its own process/terminal
Add the env var for AWS_LAMBDA_RUNTIME_API as described in the launchSettings.json
Debug your project
Queue up an event and you should hit your breakpoint(s)