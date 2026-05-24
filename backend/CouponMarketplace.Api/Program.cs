using FluentValidation;
using FluentValidation.AspNetCore;
using CouponMarketplace.Api.Middlewares;
using CouponMarketplace.Application.DTOs;
using CouponMarketplace.Application.Services.Interfaces;
using CouponMarketplace.Application.Validators;
using CouponMarketplace.Infrastructure.Data;
using CouponMarketplace.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// FluentValidation
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddScoped<IValidator<CreateCouponDto>, CreateCouponDtoValidator>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection
builder.Services.AddScoped<ICouponService, CouponService>();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Global Exception Middleware
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();