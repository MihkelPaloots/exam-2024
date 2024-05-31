namespace App.DTO.v1_0;

public class Homework
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime DueDate { get; set; } = default!;
    public string? Mark { get; set; }
}