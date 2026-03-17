namespace ImportWizard.Api.Entities;

public class ImportedRecord
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ImportRunId { get; set; }
    public int RowNumber { get; set; }
    // Flexible JSON payload — actual columns depend on the import template
    public string DataJson { get; set; } = "{}";
    public DateTime ImportedAt { get; set; } = DateTime.UtcNow;

    public ImportRun ImportRun { get; set; } = null!;
}
