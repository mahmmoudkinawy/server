var builder = WebApplication.CreateBuilder(args);

// builder.Host.UseSerilog((context, configuration) =>
//     configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddControllers();

builder.Services.AddAuth0Services(builder.Configuration);

builder.Services.AddSwaggerDocs();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
