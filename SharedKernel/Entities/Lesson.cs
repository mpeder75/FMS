namespace SharedKernel.Entities
{
    public class Lesson
    {
        private Lesson(DateTime date, Teacher teacher, Room room)
        {
            Date = date;
            Teacher = teacher;
            Room = room;

        }


        // ------------------------------------------ Properties -------------------------------------------------------------
        public Guid Id { get; protected set; }
        public DateTime Date { get; protected set; }
        public Teacher? Teacher { get; protected set; }
        public Room Room { get; protected set; }
        //public List<ExitSlip>? ExitSlips { get; protected set; }

        // ------------------------------------------- Validation ------------------------------------------------------------


        // ----------------------------------------- Factory Method ---------------------------------------------------------
        public static Lesson Create(DateTime date, Teacher teacher, Room room)
        {
            return new Lesson(date,teacher,room);
        }
    }
}
