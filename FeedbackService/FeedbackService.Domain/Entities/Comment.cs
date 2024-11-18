﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackService.Domain.Entities
{
    public class Comment : DomainEntity
    {
        protected Comment()
        {
        }
        private Comment(string commentString)
        {
            CommentString = commentString;
        }
        public string CommentString { get; protected set; }
        public static Comment Create(string commentString)
        {
            return new Comment(commentString);
        }
    }
}
