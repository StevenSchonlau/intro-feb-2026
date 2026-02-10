namespace MuddiestMoment.Api.Student.Endpoints;

public record StudentMomentResponseModel
{
    public Guid Id { get; set; }
    public required string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty; // default in C# is null
    public string AddedBy { get; set; } = string.Empty;
    public DateTimeOffset CreatedOn { get; set; }
}
