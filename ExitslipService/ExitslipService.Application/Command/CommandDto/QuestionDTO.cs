using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExitslipService.Application.Command.CommandDto
{
    public record QuestionDTO
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
