using Scalar.Aspire;

var builder = DistributedApplication.CreateBuilder(args);

// "backing services" - what app needs in env (database, id provider)

var scalar = builder.AddScalarApiReference();

//postgres - supports relational and document
var postGres = builder.AddPostgres("db-server")
    .WithLifetime(ContainerLifetime.Persistent); //can have multiple dbs in 1 server

//add database
var mmDb = postGres.AddDatabase("db-mm");

//can have scripts to set schema

var mmApi = builder.AddProject<Projects.MuddiestMoment_Api>("mm-api")
    .WithReference(mmDb) //adds to environment variables
    .WaitFor(mmDb);

scalar.WithApiReference(mmApi);

var gateway = builder.AddProject<Projects.Gateway_Api>("gateway")
    .WithReference(mmApi)
    .WaitFor(mmApi);


builder.Build().Run();
