using Logistic.Code;
using Logistic.Data;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IDownload, DownloadExcel>();
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<VipPonyContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllOrigins",
        builder =>
        {
            //builder.WithOrigins("http://127.0.0.1:5500")
            //        .AllowAnyHeader()
            //        .AllowAnyMethod();
            builder.AllowAnyHeader()
                               .AllowAnyOrigin()
                              .AllowAnyMethod();
        });
});

builder.Services.AddSwaggerGen();
builder.Services.Configure<FormOptions>(x =>
{
    x.ValueLengthLimit = int.MaxValue;
    x.MultipartBodyLengthLimit = int.MaxValue;
    x.MultipartHeadersLengthLimit = int.MaxValue;
});
var app = builder.Build();
app.UseCors("AllOrigins");
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
    app.UseSwaggerUI();
//}
//Scaffold-DbContext "Host=localhost;Port=5432;Database=VipPony;Username=postgres;Password=" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir "Data"

app.UseAuthorization();

app.MapControllers();

app.Run();
