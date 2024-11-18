namespace SharedKernel.Entities
{
    public class Lesson
    {
        private Lesson(DateTime date)
        {
            Date = date;
        }


        // ------------------------------------------ Properties -------------------------------------------------------------
        public DateTime Date { get; protected set; }

        // ------------------------------------------- Validation ------------------------------------------------------------


        // ----------------------------------------- Factory Method ---------------------------------------------------------
        public static Lesson Create(DateTime date)
        {
            return new Lesson(date);
        }
    }
}
