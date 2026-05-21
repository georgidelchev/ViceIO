<div align="center">

# ViceIO

### Your daily dose of jokes, riddles, fun facts, funny pictures & GIFs — all in one place.

**A full-stack ASP.NET Core entertainment platform built for the easily amused.**

<br/>

[![C#](https://img.shields.io/badge/C%23-32%25-239120?style=flat-square&logo=csharp&logoColor=white)](https://github.com/georgidelchev/ViceIO/search?l=c%23)
[![SCSS](https://img.shields.io/badge/SCSS-23%25-CC6699?style=flat-square&logo=sass&logoColor=white)](https://github.com/georgidelchev/ViceIO/search?l=scss)
[![HTML](https://img.shields.io/badge/HTML-14%25-E34F26?style=flat-square&logo=html5&logoColor=white)](https://github.com/georgidelchev/ViceIO/search?l=html)
[![CSS](https://img.shields.io/badge/CSS-14%25-1572B6?style=flat-square&logo=css3&logoColor=white)](https://github.com/georgidelchev/ViceIO/search?l=css)
[![License](https://img.shields.io/badge/License-MIT-6366F1?style=flat-square)](LICENSE)
[![Stars](https://img.shields.io/github/stars/georgidelchev/ViceIO?style=flat-square&color=F59E0B)](https://github.com/georgidelchev/ViceIO/stargazers)
[![Forks](https://img.shields.io/github/forks/georgidelchev/ViceIO?style=flat-square&color=22C55E)](https://github.com/georgidelchev/ViceIO/network/members)

<br/>

*122 commits of laugh-per-minute engineering — a content platform built with ASP.NET Core*
*and a healthy disregard for taking things too seriously.*

<br/>

</div>

---

## 😄 About

**ViceIO** is a full-stack ASP.NET Core web application that serves as a hub for light-hearted internet content — jokes, riddles, fun facts, funny pictures, and GIFs. It's the kind of site you open when you need a break, a laugh, or proof that the internet isn't entirely terrible.

Under the hood it's a properly built web application: layered architecture, a real database, user authentication, content management, and a polished frontend with SCSS — because even fun deserves good engineering.

---

## ✨ Features

### 😂 Content Types
- **Jokes** — browse, submit, and enjoy a curated library of jokes
- **Riddles** — challenge yourself or stump your friends
- **Fun Facts** — weird, wonderful, and surprisingly educational
- **Funny Pictures** — an image gallery of the internet's finest moments
- **GIFs** — because some reactions can only be expressed in motion

### 👤 User System
- Registration and login with ASP.NET Core Identity
- Role-based access — regular users and administrators
- User profiles and content submission

### 🛠️ Administration
- Admin panel for managing all content types
- Approve, edit, and delete user-submitted entries
- Category and content moderation

### 🎨 Frontend
- Custom SCSS stylesheets for a polished, themed UI
- Responsive design across desktop and mobile
- Clean Razor views with reusable components

---

## 🏗️ Architecture

ViceIO follows a standard ASP.NET Core MVC structure:

```
ViceIO/
└── ViceIO/
    ├── Controllers/     # MVC controllers for each content type
    ├── Views/           # Razor views and layouts
    ├── Models/          # Domain models and view models
    ├── Data/            # DbContext, EF Core migrations
    ├── Services/        # Business logic layer
    └── Areas/
        └── Admin/       # Admin area — separate controllers & views
```

---

## 🛠️ Tech Stack

| Layer | Technology |
|-------|-----------|
| Framework | ASP.NET Core MVC |
| Language | C# (.NET) |
| ORM | Entity Framework Core |
| Auth | ASP.NET Core Identity |
| Styling | SCSS, Less, CSS |
| Views | Razor Pages |
| Database | MS SQL Server |
| IDE | Visual Studio |

---

## 🚀 Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server) (local or remote)
- Visual Studio or JetBrains Rider

### Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/georgidelchev/ViceIO.git
   cd ViceIO
   ```

2. **Update the connection string** in `ViceIO/appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=.;Database=ViceIO;Trusted_Connection=True;"
     }
   }
   ```

3. **Apply migrations and run**
   ```bash
   cd ViceIO
   dotnet ef database update
   dotnet run
   ```

4. Open your browser at `https://localhost:5001` and start laughing. 😄

---

## 👤 Author

**Georgi Delchev**

[![GitHub](https://img.shields.io/badge/GitHub-georgidelchev-181717?style=flat-square&logo=github)](https://github.com/georgidelchev)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-delchevgeorgi-0A66C2?style=flat-square&logo=linkedin)](https://www.linkedin.com/in/delchevgeorgi/)
[![Facebook](https://img.shields.io/badge/Facebook-georgi.d99-1877F2?style=flat-square&logo=facebook)](https://www.facebook.com/georgi.d99/)

---

## 📄 License

This project is licensed under the [MIT License](LICENSE).

---

<div align="center">
<sub>Made with ☕, ASP.NET Core, and a questionable sense of humour</sub>
</div>
