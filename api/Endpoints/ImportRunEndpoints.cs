// TODO: Implement import-run endpoints.
//
// Planned routes (to be added to Program.cs via RouteGroupBuilder):
//
//   POST   /api/import-runs
//     - Create a new ImportRun record.
//     - Accept multipart/form-data (file upload) or a JSON body with metadata.
//     - Return the created ImportRun id and initial status.
//
//   POST   /api/import-runs/{id}/upload
//     - Upload the CSV/Excel file associated with an existing ImportRun.
//     - Store the raw file (blob storage or local disk) and enqueue a parse job.
//
//   POST   /api/import-runs/{id}/validate
//     - Trigger validation of the uploaded file against the selected column mapping.
//     - Returns a summary of validation errors (ImportRowError list) without persisting records.
//
//   POST   /api/import-runs/{id}/process
//     - Kick off background chunked processing.
//     - Rows are written in batches to ImportedRecords; errors go to ImportRowErrors.
//     - Consider using IHostedService / Channel<T> or a queue (RabbitMQ / Azure Service Bus) for
//       large files so the HTTP request returns immediately.
//
//   GET    /api/import-runs/{id}/status
//     - Return current ImportRun status, TotalRows, ProcessedRows, error count.
//     - Suitable for polling from the frontend; SSE or WebSocket can be added later.
//
//   GET    /api/import-runs/{id}/errors
//     - Paginated list of ImportRowError for a given run.
//
// Performance ideas (no implementation yet):
//   - Chunk uploads: split large files into pages of N rows, process each chunk independently.
//   - Parallel processing: fan-out chunks across multiple Task workers or hosted services.
//   - Bulk insert: use Npgsql COPY or EF Core BulkExtensions for high-throughput inserts.
//   - Progress via SSE: stream ImportRun.ProcessedRows updates without polling overhead.

namespace ImportWizard.Api.Endpoints;

public static class ImportRunEndpoints
{
    public static IEndpointRouteBuilder MapImportRunEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/import-runs").WithTags("ImportRuns");

        // TODO: POST /api/import-runs — create import run
        // group.MapPost("/", CreateImportRun).WithName("CreateImportRun").WithOpenApi();

        // TODO: POST /api/import-runs/{id}/upload — upload file
        // group.MapPost("/{id:guid}/upload", UploadFile).WithName("UploadFile").WithOpenApi();

        // TODO: POST /api/import-runs/{id}/validate — validate rows
        // group.MapPost("/{id:guid}/validate", ValidateImport).WithName("ValidateImport").WithOpenApi();

        // TODO: POST /api/import-runs/{id}/process — start processing
        // group.MapPost("/{id:guid}/process", ProcessImport).WithName("ProcessImport").WithOpenApi();

        // TODO: GET /api/import-runs/{id}/status — poll progress
        // group.MapGet("/{id:guid}/status", GetStatus).WithName("GetImportStatus").WithOpenApi();

        // TODO: GET /api/import-runs/{id}/errors — list row errors
        // group.MapGet("/{id:guid}/errors", GetErrors).WithName("GetImportErrors").WithOpenApi();

        return app;
    }
}
