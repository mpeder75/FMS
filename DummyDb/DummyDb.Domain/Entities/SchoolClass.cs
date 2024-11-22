namespace DummyDb.Domain.Entities
{
    public class SchoolClass
    {
        private SchoolClass(int term)
        {
            Term = term;
        }


        // ------------------------------------------ Properties -------------------------------------------------------------
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public int Term { get; protected set; }
        public List<Student>? Students { get; protected set; }
        public List<Room>? Rooms { get; protected set; }
        public List<Lesson>? Lessons { get; protected set; }

        // ------------------------------------------- Validation ------------------------------------------------------------


        // ----------------------------------------- Factory Method ---------------------------------------------------------
        public static SchoolClass Create(int term)
        {
            return new SchoolClass(term);
        }
    }
}
