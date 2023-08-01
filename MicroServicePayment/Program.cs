using AutoMapper;
using MicroServicePayment.DTO;
using MicroServicePayment.Interfaces;
using MicroServicePayment.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add AutoMapper services
builder.Services.AddScoped<IPaymentCardRepository, PaymentCardRepository>();
builder.Services.AddScoped<ICardInfoRepository, CardInfoRepository>();
builder.Services.AddAutoMapper(typeof(EntityProfile), typeof(AccountProfile) ,typeof(AccountcontractProfile),typeof(NternalaccountProfile), typeof(PaymentcardProfile));
builder.Services.AddDbContext<PayDbContext>(options =>
{
    options.UseOracle("Data Source=10.250.0.130:1521/DBSTB;User Id=cartdef_digi;Password=sa;"
    );
});
var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

