using App.DTO.v1_0;

namespace App.DTO;

public class AddHomeworkBody
{
    public Guid SubjectId { get; set; } = default!;
    public Homework Homework { get; set; } = default!;
}