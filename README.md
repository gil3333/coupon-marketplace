# Coupon Marketplace API

Backend API for managing coupons and users.

## Technologies

- ASP.NET Core 9
- Entity Framework Core
- PostgreSQL
- JWT Authentication
- Swagger
- Docker

---

## Run With Docker

```bash
docker compose up -d
```

---

## Run Database Migrations

```bash
dotnet ef database update --project ../CouponMarketplace.Infrastructure --startup-project .
```

---

## Run The Project

```bash
dotnet run
```

---

## Swagger

After running the project:

```text
http://localhost:5293/swagger
```

---

## Features

- User Registration
- User Login with JWT
- Coupons CRUD
- Validation
- PostgreSQL database
- Swagger API documentation