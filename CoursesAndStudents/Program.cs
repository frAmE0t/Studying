using CoursesAndStudents;
using Microsoft.EntityFrameworkCore;

using (Academy a = new())
{
    bool deleted = await a.Database.EnsureDeletedAsync();
    Console.WriteLine($"Database deleted: {deleted}");

    bool created = await a.Database.EnsureCreatedAsync();
    Console.WriteLine($"Database created {created}");

    foreach (Student s in a.Students.Include(s => s.Courses))
    {
        Console.WriteLine($"{s.FirstName} {s.LastName} attends the following {s.Courses.Count} courses");

        foreach (Course c in s.Courses)
            Console.WriteLine(c.Title);
    }
}
