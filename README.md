# Kammermúsíkklúbburinn 🎻

A .NET API for managing and exploring data about concerts from **Kammermúsíkklúbburinn**, an Icelandic chamber music club founded on **February 7, 1957**.  
The database contains information about concert seasons, concerts, performers, composers, and pieces performed throughout the club’s history.

---

## 🧱 Tech Stack

- **.NET 8** (API)
- **Entity Framework Core**
- **Docker & Docker Compose**
- **PostgreSQL** (Database)

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

Download and install the EF Core CLI tools:

👉 [dotnet-ef NuGet Package](https://www.nuget.org/packages/dotnet-ef)

---

### 3. Database Management Commands

#### Create a New Migration

```bash
dotnet ef migrations add [NAME OF MIGRATION] -s API -p Infrastructure
```

#### Update the Database

```bash
dotnet ef database update -s API -p Infrastructure
```

#### Drop the Database

```bash
dotnet ef database drop -p Infrastructure -s API
```

---

### 4. Run the Application

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

## 🌐 API Endpoints

All endpoints are available at:

```
http://localhost:5000/api
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
