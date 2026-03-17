namespace ImportWizard.Api.Entities;

public class ImportRun
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FileName { get; set; } = string.Empty;
    public string Status { get; set; } = "Pending"; // Pending | Processing | Completed | Failed
    public int TotalRows { get; set; }
    public int ProcessedRows { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? CompletedAt { get; set; }

    public ICollection<ImportRowError> RowErrors { get; set; } = new List<ImportRowError>();
    public ICollection<ImportedRecord> ImportedRecords { get; set; } = new List<ImportedRecord>();
}
