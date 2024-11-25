using ExitslipService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExitslipService.Application.Query.ExitSlipDto
{
    public class ExitSlipDTO
    {
        public Guid StudentId { get; internal set; }
        public Comment TeacherComment { get; internal set; }
        public List<Question> Questions { get; internal set; }
    }
}
