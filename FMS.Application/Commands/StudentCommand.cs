using FMS.Application.Commands.CommandDto.StudentDto;
using FMS.Application.Commands.Interfaces;

namespace FMS.Application.Commands
{
    public class StudentCommand : IStudentCommand
    {
        void IStudentCommand.CreateStudent(CreateStudentDto studentDto)
        {
            throw new NotImplementedException();
        }
    }
}
