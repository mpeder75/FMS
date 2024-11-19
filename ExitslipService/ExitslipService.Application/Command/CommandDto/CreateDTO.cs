using ExitslipService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExitslipService.Application.Command.CommandDto
{
    public class CreateDTO
    {
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }

        public Guid LessonId { get; set; }

        public List<Question> Questions { get; set; }

    }
}
