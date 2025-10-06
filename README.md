# Kammermúsíkklúbburinn 🎻

A .NET API for managing and exploring data about concerts from **Kammermúsíkklúbburinn**, an Icelandic chamber music club founded in 1957.  
The database contains information about concert seasons, concerts, performers, composers and pieces performed throughout the club’s history.

---

## 🧱 Tech Stack

- **.NET 9** (API)
- **Entity Framework Core**
- **Docker & Docker Compose**
- **MSSQL** (Database)

---

## 🚀 Getting Started

### 1. Run Docker Containers

Make sure Docker is installed and running.

```bash
docker compose up -d
```

This will start the database container.

To stop and remove containers:

```bash
docker compose down
```

---

### 2. Install Entity Framework CLI

This project uses .NET 9.0. Download this version to run the project:

👉 [dotnet 9.0](https://dotnet.microsoft.com/en-us/download)

Download and install the EF Core CLI tools version 9.0.7:

👉 [dotnet-ef NuGet Package](https://www.nuget.org/packages/dotnet-ef)

---

### 3. Database Management Commands

#### Update the Database

```bash
dotnet ef database update -s API -p Infrastructure
```

---

### 4. Run the Application

You may need to tell .NET you want to run in development mode:

```bash
export ASPNETCORE_ENVIRONMENT=Development
```

Start the API project:

```bash
cd API
dotnet watch
```

---

### 5. Attach a Debugger (VS Code or similar)

1. Run the project.
2. Open the **Run and Debug** panel (🪲 icon on the left).
3. Press the green **Play** button.
4. Search for **API** in the target list and attach.

---

## Other DB management commands

#### Drop the Database

```bash
dotnet ef database drop -p Infrastructure -s API
```

#### Create a New Migration

```bash
dotnet ef migrations add [NAME OF MIGRATION] -s API -p Infrastructure
```

---

## 🌐 API Endpoints

All endpoints are available at:

```
http://localhost:5000/api
```

You can view a swagger definition at:

```
http://localhost:5000/swagger/index.html
```

but make sure you are running the app in dev mode:

```bash
export ASPNETCORE_ENVIRONMENT=Development
```

| Method                 | Endpoint          | Description            |
| ---------------------- | ----------------- | ---------------------- |
| GET, POST, PUT, DELETE | `/ConcertSeasons` | Manage concert seasons |
| GET, POST, PUT, DELETE | `/Concerts`       | Manage concerts        |
| GET, POST, PUT, DELETE | `/Performers`     | Manage performer data  |
| GET, POST, PUT, DELETE | `/Composers`      | Manage composer data   |
| GET, POST, PUT, DELETE | `/Pieces`         | Manage musical pieces  |

### Example Query

Search concerts or related data by keyword (e.g., composer name) as well as paginate:

```
?Search=Beethoven
?PageIndex=1&PageSize=6
```

---

## 🧩 Project Structure

```
├── API/                # Main .NET API project
├── Core/               # Entities, interfaces and specifications
├── Infrastructure/     # Data layer (EF Core, Migrations)
├── docker-compose.yml  # Docker setup for DB
└── README.md           # Project documentation
```
