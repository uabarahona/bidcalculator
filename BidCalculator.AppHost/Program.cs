var builder = DistributedApplication.CreateBuilder(args);

var bidCalculatorDatabase = builder.AddSqlServer("bidcalculatorserver")
    .AddDatabase("bidcalculatordatabase");

var apiService = builder.AddProject<Projects.BidCalculator_Api>("bidcalculatorapi")
    .WithReference(bidCalculatorDatabase)
    .WithExternalHttpEndpoints();


builder.AddNpmApp("bidcalculatorclient", "../bidcalculator.client")
    .WithReference(apiService)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
