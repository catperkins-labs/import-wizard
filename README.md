# import-wizard

A full-stack bulk-import tool built with **.NET 8 Minimal API** (backend) and **React + TypeScript** (frontend).

---

## Project structure

```
import-wizard/
├── docker-compose.yml        # Orchestrates Postgres + API for local dev
├── .env.example              # Required environment variables (copy to .env)
├── README.md
├── api/                      # .NET 8 Minimal API
│   ├── Dockerfile
│   ├── ImportWizard.Api.csproj
│   ├── Program.cs
│   ├── appsettings.json
│   ├── Data/
│   │   └── AppDbContext.cs   # EF Core DbContext
│   ├── Entities/
│   │   ├── ImportRun.cs
│   │   ├── ImportRowError.cs
│   │   └── ImportedRecord.cs
│   ├── Endpoints/
│   │   └── ImportRunEndpoints.cs  # Stubbed future routes
│   └── Migrations/           # EF Core migrations (generated)
└── web/                      # Vite + React + TypeScript
    ├── src/
    │   ├── App.tsx            # Router + layout
    │   ├── api/
    │   │   └── client.ts      # API fetch helper
    │   └── pages/
    │       ├── NewImport.tsx
    │       ├── MapColumns.tsx
    │       ├── ValidatePreview.tsx
    │       └── ImportStatus.tsx
    ├── .env.example
    └── vite.config.ts
```

---

## How to run

### Prerequisites

- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (includes Docker Compose)
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (for local API development)
- [Node.js 20+](https://nodejs.org/) (for local frontend development)

### 1. Configure environment

```bash
cp .env.example .env
# Edit .env and set a strong POSTGRES_PASSWORD
```

### 2. Start Postgres + API with Docker Compose

```bash
docker compose up --build
```

- Postgres will be available at `localhost:5432`
- API will be available at `http://localhost:5000`
- Swagger UI: `http://localhost:5000/swagger`
- Health check: `http://localhost:5000/health`

### 3. Run database migrations

Once the containers are running, apply EF Core migrations from the `api/` directory:

```bash
cd api
dotnet ef migrations add InitialCreate
dotnet ef database update
```

Or inside the running container:

```bash
docker compose exec api dotnet ef database update
```

### 4. Start the frontend (development)

```bash
cd web
cp .env.example .env.local   # already set to http://localhost:5000
npm install
npm run dev
```

The app will be available at `http://localhost:5173`.

---

## Planned workflow

```
User uploads CSV/Excel
        │
        ▼
POST /api/import-runs          ← Create ImportRun record (status: Pending)
        │
        ▼
POST /api/import-runs/{id}/upload   ← Store raw file; queue parse job
        │
        ▼
[Map Columns UI]               ← User maps source columns → target fields
        │
        ▼
POST /api/import-runs/{id}/validate ← Server validates rows; returns errors
        │
        ▼
[Validate Preview UI]          ← User reviews errors; fixes or proceeds
        │
        ▼
POST /api/import-runs/{id}/process  ← Kick off background chunked processing
        │
        ▼
GET  /api/import-runs/{id}/status   ← Poll (or SSE) for progress
        │
        ▼
[Import Status UI]             ← Progress bar, error count, completion banner
```

---

## Performance ideas (not yet implemented)

| Idea | Description |
|---|---|
| **Chunked uploads** | Split large files into pages of N rows; process each chunk independently so a single failure doesn't abort the whole import. |
| **Background processing** | Use `IHostedService` + `Channel<T>` (or an external queue like RabbitMQ) so the HTTP request returns immediately while rows are written asynchronously. |
| **Parallel fan-out** | Distribute chunks across multiple `Task` workers or scaled-out API replicas. |
| **Bulk inserts** | Use Npgsql `COPY` protocol or EF Core BulkExtensions for high-throughput row inserts instead of individual `SaveChanges` calls. |
| **Server-Sent Events (SSE)** | Stream `ImportRun.ProcessedRows` updates to the frontend without the overhead of polling. |
| **Idempotency** | Accept a client-supplied `idempotency-key` header so retried uploads don't create duplicate runs. |

---

## API endpoints

| Method | Path | Status | Description |
|---|---|---|---|
| GET | `/health` | ✅ Implemented | Health check |
| POST | `/api/import-runs` | 🔲 TODO | Create an import run |
| POST | `/api/import-runs/{id}/upload` | 🔲 TODO | Upload the file |
| POST | `/api/import-runs/{id}/validate` | 🔲 TODO | Validate rows |
| POST | `/api/import-runs/{id}/process` | 🔲 TODO | Start background processing |
| GET | `/api/import-runs/{id}/status` | 🔲 TODO | Poll progress |
| GET | `/api/import-runs/{id}/errors` | 🔲 TODO | List row errors |

---

## Frontend routes

| Path | Page | Status |
|---|---|---|
| `/` | New Import | 🔲 Placeholder |
| `/import/:id/map-columns` | Map Columns | 🔲 Placeholder |
| `/import/:id/validate` | Validate Preview | 🔲 Placeholder |
| `/import/:id/status` | Import Status | 🔲 Placeholder |
