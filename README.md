# MinimalAPIsSandbox

The purpose of this repository is to demonstrate some difference between the .NET Web APIs as we know today (.NET 5 and below) compared to the ones we should expect to see on .NET 6, specially on what is related to the Minimal APIs.

## What is covered

In general words, we have samples of a very simple CRUD API, considering the implementation of a regular .NET API on .NET 5 (RegularAPINET5), the implementation of a regular .NET API on .NET 6 (RegularAPINET6) and two other samples using the new concept of Minimal APIs, the Minimal API approach (MinimalAPI) and a tweaked version of this same Minimal API (MinimalAPITweaked).
These four mentioned projects have pretty much the same logics and scope, considering each appropiate implementation.

## Performance comparison

Included on the solution, there's also a project using NBomber (available as a Nuget Package) to stress test the application and compare its results between each other.

## Further information on Minimal APIs

Scott Hanselman: https://www.hanselman.com/blog/exploring-a-minimal-web-api-with-aspnet-core-6
.NET Core Tutorials: https://dotnetcoretutorials.com/2021/07/16/building-minimal-apis-in-net-6/
Nick Chapsas: https://www.youtube.com/watch?v=eRJFNGIsJEo - Special thanks in here, the kick-off for this sandbox and a few implementation ideas came from this material.
