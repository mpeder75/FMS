using FMS.Application.IQueries.Dto;

namespace FMS.Application.IQueries
{
    public interface IStudentQuery
    {
        StudentDto GetStudent(int id);
        IEnumerable<StudentDto> GetStudents();
    }
}
