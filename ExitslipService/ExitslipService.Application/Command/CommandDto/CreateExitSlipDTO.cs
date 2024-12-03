﻿using ExitslipService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExitslipService.Application.Command.CommandDto
{
    public record CreateExitSlipDTO
    {
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }

        public Guid LessonId { get; set; }

        public List<QuestionForm> Questions { get; set; }
        public Guid TeacherId { get; internal set; }
    }
}
