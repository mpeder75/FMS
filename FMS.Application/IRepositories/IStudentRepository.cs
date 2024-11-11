using FMS.Domain.Entity;

namespace FMS.Application.IRepositories
{
    public interface IStudentRepository
    {
        Student GetBooking(int id);
        void AddBooking(Student student);
        void UpdateBooking(Student student, byte[] rowversion);
        void DeleteBooking(Student student);
    }
}
