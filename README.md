# 🧱 Insurance Calculator (Clean Architecture & DDD Project)

This project is an **educational open-source implementation** of **Domain-Driven Design (DDD)** and **Clean Architecture** principles, built with modern .NET technologies.  
It is designed **for learning purposes only** and not intended for commercial or production use.

---

## 🛠️ Technologies Used

- **.NET 8**
- **ASP.NET Core Web API**
- **C#**
- **Entity Framework Core 9**
- **MediatR**
- **CQRS Pattern**
- **Domain-Driven Design (DDD)**
- **MS SQL Server**
- **Serilog**
- **FluentValidation**
- **Swagger / OpenAPI**
- **Clean Architecture**
- *and more...*

![dotnet-version](https://img.shields.io/badge/dotnet%20version-net8.0-blue)

---

## Database Connection & Migration

### Connection String
The application uses **SQL Server** with different configurations for **Development** and **Production** environments.  
In both environments, the `appsettings.json` (or `appsettings.Development.json`) contains:

```json
"ConnectionStrings": {
  "AppDbContext": "Server=SERVER_NAME;Database=InsuranceCalculatorDb;User=SQL_USER_NAME;Password=SQL_USER_PASSWORD;TrustServerCertificate=True;"
}
```

Make sure to configure the connection string according to your environment.

### Database Setup
To set up the database:

1. Open **Package Manager Console** in Visual Studio.  
2. Set **Default Project** to `InsuranceCalculator.Infrastructure`.  
3. Run the following command:

```powershell
Update-Database
```

This will apply all migrations and create the database.

### Seed Data
After running the application, initial **SeedData** will be created for the `CoverageDefinations` and `Users` tables.  
This provides default test data for evaluation and demonstration purposes.

---

## Getting Started

### Prerequisites
- Install [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Install [Git](https://git-scm.com/)
- SQL Server installed and running

### Clone & Run
```bash
git clone https://github.com/mh-zolfaghari/insurance-calculator.git
cd insurance-calculator
dotnet ef database update
dotnet run --project src/InsuranceCalculator.Api
```

---

## 📘 License

This project is licensed under the **Educational MIT License** — see the [LICENSE](./LICENSE) file for details.

---

### 👨‍💻 Author
**Mohammad Hossein Zolfaghari**  

---

## 🩷 Follow Me!

[![LinkedIn][linkedin-shield]][linkedin-url]  [![Telegram][telegram-shield]][telegram-url]  [![WhatsApp][whatsapp-shield]][whatsapp-url]  [![Gmail][gmail-shield]][gmail-url]  ![GitHub followers](https://img.shields.io/github/followers/mh-zolfaghari)

[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?logo=linkedin&color=555
[linkedin-url]: https://www.linkedin.com/in/ronixa/

[telegram-shield]: https://img.shields.io/badge/-Telegram-black.svg?logo=telegram&color=fff
[telegram-url]: https://t.me/DanialDotNet

[whatsapp-shield]: https://img.shields.io/badge/-WhatsApp-black.svg?logo=whatsapp&color=fff
[whatsapp-url]: https://wa.me/989389043224

[gmail-shield]: https://img.shields.io/badge/-Gmail-black.svg?logo=gmail&color=fff
[gmail-url]: mailto:personal.mhz@gmail.com