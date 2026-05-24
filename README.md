# Coupon Marketplace API

Backend project built with:

- ASP.NET Core Web API
- PostgreSQL
- Entity Framework Core
- JWT Authentication
- FluentValidation
- Swagger

## Run Project

1. Start PostgreSQL with Docker

docker run --name coupons-db ^
-e POSTGRES_USER=postgres ^
-e POSTGRES_PASSWORD=postgres ^
-e POSTGRES_DB=coupons ^
-p 5432:5432 ^
-d postgres

2. Run migrations

dotnet ef database update --project ../CouponMarketplace.Infrastructure --startup-project .

3. Run API

dotnet run

Swagger:
http://localhost:5293/swagger