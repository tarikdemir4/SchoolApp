using SchoolApp.DataAccess.Context;
using SchoolApp.Entities.Models;

namespace SchoolApp.DataAccess.Repositories;

public sealed class ClassRoomRepository(ApplicationDbContext context) : IClassRoomRepository
{
    public void Create(ClassRoom classRoom)
    {
        context.Add(classRoom);
        context.SaveChanges();
    }

    public void DeleteById(Guid id)
    {
        ClassRoom? classRoom = GetClassRoomById(id);
        if (classRoom is not null)
        {
            context.Remove(classRoom);
            context.SaveChanges();
        }
    }

    public List<ClassRoom> GetAll()
    {
        return context.ClassRooms.ToList();
    }

    public ClassRoom? GetClassRoomById(Guid id)
    {
        return context.ClassRooms.Where(p => p.Id == id).FirstOrDefault();
    }

    public void Update(ClassRoom classRoom)
    {
        context.Update(classRoom);
        context.SaveChanges();
    }
}
