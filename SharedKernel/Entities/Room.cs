using System.ComponentModel.DataAnnotations.Schema;

namespace SharedKernel.Entities
{
    public class Room
    {
        private Room(string name, string description)
        {
            Name = name;
            Description = description;
        }


        // ------------------------------------------ Properties -------------------------------------------------------------
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public List<Lesson>? Lessons { get; protected set; }
        public SchoolClass? SchoolClass { get; protected set; }
        //public List<FeedbackPost>? Posts { get; protected set; }

        // ------------------------------------------- Validation ------------------------------------------------------------


        // ----------------------------------------- Factory Method ---------------------------------------------------------
        public static Room Create(string name, string description)
        {
            return new Room(name, description);
        }
    }
}
