using FMS.Application.IRepositories;
using FMS.Domain.Entity;

namespace FMS.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        void IStudentRepository.AddBooking(Student student)
        {
            throw new NotImplementedException();
        }

        void IStudentRepository.DeleteBooking(Student student)
        {
            throw new NotImplementedException();
        }

        Student IStudentRepository.GetBooking(int id)
        {
            throw new NotImplementedException();
        }

        void IStudentRepository.UpdateBooking(Student student, byte[] rowversion)
        {
            throw new NotImplementedException();
        }
    }
}
