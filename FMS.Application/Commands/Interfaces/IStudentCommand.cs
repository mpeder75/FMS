using FMS.Application.Commands.CommandDto.StudentDto;

namespace FMS.Application.Commands.Interfaces
{
    public interface IStudentCommand
    {
        void CreateStudent(CreateStudentDto studentDto);
    }
}
