using Waddabha.API.Hubs;
using Waddabha.API.Middlewares;
using Waddabha.BL;
using Waddabha.DAL;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDALServices(builder.Configuration);
builder.Services.AddBLServices(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:4200", "http://localhost:5000") // Angular frontend URL
              .AllowAnyMethod()
              .AllowAnyHeader()
             .AllowCredentials();
              
                            // Required for SignalR
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");
//app.UseCors();
app.UseHttpsRedirection();
app.UseRouting(); // Ensure routing is added before configuring endpoints
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Map controllers and the SignalR ChatHub
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();   // Map API controllers
    endpoints.MapHub<ChatHub>("/chatHub"); // Map SignalR hub to /chatHub
});
app.Run();