namespace ImportWizard.Api.Entities;

public class ImportRowError
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ImportRunId { get; set; }
    public int RowNumber { get; set; }
    public string Column { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;

    public ImportRun ImportRun { get; set; } = null!;
}
