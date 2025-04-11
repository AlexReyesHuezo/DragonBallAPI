# 🐉 Dragon Ball API (ASP.NET Core)

Este proyecto es una **API RESTful en ASP.NET Core** que consume la [Dragon Ball API pública](https://web.dragonball-api.com/), almacena datos en **SQL Server**, y proporciona endpoints protegidos con autenticación **JWT**. Se aplican principios **SOLID** y arquitectura **MVC**.

---

## 🚀 Características

- 🔄 Sincronización de personajes desde API externa
- 🧠 Persistencia en base de datos SQL Server
- 🔐 Autenticación basada en JWT
- 📐 Separación por capas: Models, DTOs, Services, Controllers

---

## 🧱 Tecnologías utilizadas

- ASP.NET Core 8 Web API
- Entity Framework Core + SQL Server
- JWT (Json Web Tokens)
- Principios SOLID

---

## 🛠️ Instalación y configuración

### 1. Clonar el repositorio
```bash
git clone https://github.com/alexreyeshuezo/dragonball-api-dotnet.git
cd dragonball-api-dotnet
```

### 2. Configurar la base de datos y JWT
En `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=DragonBallDb;Trusted_Connection=True;TrustServerCertificate=True;"
},
"JwtSettings": {
  "Secret": "TU_CLAVE_SECRETA",
  "Issuer": "DragonBallApi",
  "Audience": "DragonBallApiUsers",
  "ExpirationMinutes": 60
}
```

### 3. Aplicar migraciones
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## 📂 Estructura de carpetas
```
│
├── Controllers/
├── Models/
├── Dtos/
├── Services/
├── Data/
├── Program.cs
└── appsettings.json
```

---

## 🧪 Tests
Pendiente: agregar pruebas unitarias con xUnit / Moq.


---

## 👨‍💻 Autor
**Alexander Reyes** - [@AlexReyesHuezo](https://github.com/alexreyeshuezo)

---

## 📄 Licencia
MIT

