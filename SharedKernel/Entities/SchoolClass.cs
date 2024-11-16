
namespace SharedKernel.Entities
{
    public class SchoolClass
    {
        private SchoolClass(int term) 
        {
            Term = term;
        }


        // ------------------------------------------ Properties -------------------------------------------------------------
        public int Term { get; protected set; }

        // ------------------------------------------- Validation ------------------------------------------------------------


        // ----------------------------------------- Factory Method ---------------------------------------------------------
        public static SchoolClass Create(int term)
        {
            return new SchoolClass(term);
        }
    }
}
