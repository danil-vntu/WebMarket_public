# WebMarket API (ASP.NET Core)

## 🇬🇧 English

### Overview
**WebMarket** is a backend API for a digital products store. It supports user registration and login, product listing, purchasing with license key generation, and admin promotions. Built with **ASP.NET Core**, **Entity Framework Core**, and **AutoMapper**.

### 🔧 Features
- 🔐 User registration and login (session-based)
- 📦 Product listing with promotion support
- 🛒 Purchasing flow with license key generation
- 🧑‍💻 Admin endpoints for price updates and promotions
- 🗭 Swagger UI for testing endpoints

### 🚀 Getting Started
1. Clone the repository:
```bash
git clone https://github.com/danil-vntu/WebMarket_public.git
```
2. Navigate to backend:
```bash
cd WebMarket-public/backend
```
3. Configure database in `AppDbContext.cs` (edit connection string manually):
```csharp
options.UseSqlServer("Server=.;Database=WebMarketDb;Trusted_Connection=True;");
```
4. Apply migrations:
```bash
dotnet ef database update
```
5. Run the app:
```bash
dotnet run
```

### 🛠 Technologies
- ASP.NET Core
- EF Core (Code First)
- AutoMapper
- Swagger

---

## 🇺🇦 Українською

### Опис
**WebMarket** — бекенд для магазину цифрових товарів. Підтримує реєстрацію, вхід, перегляд товарів, купівлю з генерацією ключів, а також адміністрування. Побудований на **ASP.NET Core** з використанням **EF Core** та **AutoMapper**.

### 🔧 Можливості
- 🔐 Авторизація на сесіях (без JWT)
- 📦 Каталог товарів із промо-опціями
- 🛒 Купівля товарів з генерацією ліцензійних ключів
- 🧑‍💻 Адмін-функції: оновлення ціни, промоція товарів
- 🗭 Swagger UI для тестування

### 🚀 Запуск проєкту
1. Клонуйте репозиторій:
```bash
git clone https://github.com/danil-vntu/WebMarket_public.git
```
2. Перейдіть у директорію `backend`:
```bash
cd WebMarket-public/backend
```
3. Налаштуйте підключення до БД у `AppDbContext.cs`:
```csharp
options.UseSqlServer("Server=.;Database=WebMarketDb;Trusted_Connection=True;");
```
4. Застосуйте міграції:
```bash
dotnet ef database update
```
5. Запустіть сервер:
```bash
dotnet run
```

### 🛠 Технології
- ASP.NET Core
- EF Core
- AutoMapper
- Swagger

---

> ✨ Проєкт створено як частина навчального портфоліо .NET розробника