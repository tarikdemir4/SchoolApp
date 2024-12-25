using SchoolApp.Entities.Models;

namespace SchoolApp.DataAccess.Repositories;

public interface IClassRoomRepository
{
    void Create(ClassRoom classRoom);
    void Update(ClassRoom classRoom);
    void DeleteById(Guid id);
    List<ClassRoom> GetAll();
    ClassRoom? GetClassRoomById(Guid id);
}
