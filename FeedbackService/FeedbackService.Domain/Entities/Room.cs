namespace FeedbackService.Domain.Entities
{
    public class Room : DomainEntity
    {
        private Room(string name, string description)
        {
            Name = name;
            Description = description;
        }
        
        public string Name { get; protected set; }
        public string Description { get; protected set; }

        public static Room Create(string name, string description)
        {
            return new Room(name, description);
        }
    }
}
