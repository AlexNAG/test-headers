using TestHeadersWebApi.Dto;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
var app = builder.Build();
app.MapGet("/", (HttpContext context) => new HostInfoDto(context.Request.Host.ToString(), context.Request.Scheme, context.Connection.RemoteIpAddress?.ToString()));
app.Run();
