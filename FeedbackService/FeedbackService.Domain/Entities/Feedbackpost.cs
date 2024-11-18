﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel.Entities;

namespace FeedbackService.Domain.Entities
{
    public class Feedbackpost : DomainEntity
    {
        private readonly List<DateTime> _editedTimes;
        private readonly List<Comment> _comments;
        private readonly List<Question> _history;
        protected Feedbackpost()
        {

        }

        protected Feedbackpost(Student author, string title, Room room, Question feedback)
        {
            Author = author;
            Title = title;
            Room = room;
            Feedback = feedback;
            Likes = 0;
            Dislikes = 0;
        }

        public Student Author { get; protected set; }
        public string Title { get; protected set; }
        public Question Feedback { get; protected set; }
        public int Likes { get; protected set; }
        public int Dislikes { get; protected set; }
        public Room Room { get; protected set; }
        public List<DateTime> EditedTimes => _editedTimes;
        public IReadOnlyCollection<Comment> Comments => _comments;
        public IReadOnlyCollection<Question> History => _history;


        public static Feedbackpost CreateFeedbackpost(Student originalPoster, string title, Room room, Question feedback)
        {
            return new Feedbackpost(originalPoster, title, room, feedback);
        }

        public void AddComment(string commentString)
        {
            var comment = Comment.Create(commentString);
            _comments.Add(comment);
        }

    }
}
