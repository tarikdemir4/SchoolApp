using SchoolApp.Entities.Abstractions;

namespace SchoolApp.Entities.Models;
public sealed class Student : Entity
{

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => string.Join(" ", FirstName, LastName);
    public int StudentNumber { get; set; }
    public string IdentityNumber { get; set; } = string.Empty;
    public Guid ClassRoomId { get; set; }
    public ClassRoom? ClassRoom { get; set; }
}
