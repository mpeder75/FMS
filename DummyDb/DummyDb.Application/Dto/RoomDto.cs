using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyDb.Application.Dto
{
    public class RoomDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<LessonDto> Lessons { get; set; }
        public List<SchoolClassDto> SchoolClasses { get; set; }
    }
}
