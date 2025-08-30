var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.HealthCarePortalApp_ApiService>("apiservice");

builder.AddProject<Projects.HealthCarePortalApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
