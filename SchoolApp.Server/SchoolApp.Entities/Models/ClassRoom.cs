using SchoolApp.Entities.Abstractions;

namespace SchoolApp.Entities.Models;

public sealed class ClassRoom:Entity
{
    public string Name { get; set; } = string.Empty;
    public List<Student>? Students { get; set; }

}
