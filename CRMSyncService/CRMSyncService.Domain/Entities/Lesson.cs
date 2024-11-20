namespace DummyDb.Domain.Entities
{
    public class Lesson
    {
        private Lesson(DateTime date)
        {
            Date = date;
        }


        // ------------------------------------------ Properties -------------------------------------------------------------
        public Guid Id { get; protected set; }
        public DateTime Date { get; protected set; }
        public Teacher? Teacher { get; protected set; }
        public Room? Room { get; protected set; }
        public List<SchoolClass>? SchoolClasses { get; protected set; }

        // ------------------------------------------- Validation ------------------------------------------------------------


        // ----------------------------------------- Factory Method ---------------------------------------------------------
        public static Lesson Create(DateTime date)
        {
            return new Lesson(date);
        }
    }
}
