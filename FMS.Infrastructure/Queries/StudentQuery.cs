using FMS.Application.IQueries;
using FMS.Application.IQueries.Dto;

namespace FMS.Infrastructure.Queries
{
    public class StudentQuery : IStudentQuery
    {
        StudentDto IStudentQuery.GetStudent(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<StudentDto> IStudentQuery.GetStudents()
        {
            throw new NotImplementedException();
        }
    }
}
