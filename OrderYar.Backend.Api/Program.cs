

using OrderYar.Backend.Api.Application.Common;
using OrderYar.Backend.Api.Application.Common.Exceptions;
using OrderYar.Backend.Api.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration.Get<AppSettings>()
    ?? throw ProgramException.AppsettingNotSetException();

builder.Services.AddSingleton(configuration);
var app = await builder.ConfigureServices(configuration).ConfigurePipelineAsync(configuration);

await app.RunAsync();

// this line tell integration test
public partial class Program { }