using Microsoft.AspNetCore.Mvc.Formatters;
using Restful.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(setupAction =>
{
    setupAction.ReturnHttpNotAcceptable = true; //S�ger 406 not acceptable om man ber om fel format, te.x application/xml i RequestMessage
    
}).AddXmlDataContractSerializerFormatters(); //L�gger till att XML �r OK att skicka mot Apiet och converterar till det om man ber om det


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler(appBuilder => //Skickar generiskt felmeddelande i produktions milj� om throw h�nder
    {
        appBuilder.Run(async context =>
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("An unexpected error occured. Please try again later");
        });
    });
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

