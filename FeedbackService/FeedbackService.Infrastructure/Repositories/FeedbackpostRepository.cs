using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedbackService.Application;
using FeedbackService.Domain.Entities;

namespace FeedbackService.Infrastructure.Repositories
{
    internal class FeedbackpostRepository : IFeedbackpostRepository
    {
        private readonly FeedbackContext _db;

        public FeedbackpostRepository(FeedbackContext context)
        {
            _db = context;
        }

        async Task IFeedbackpostRepository.AddFeedbackpostAsync(Feedbackpost feedbackpost)
        {
            await _db.Feedbackposts.AddAsync(feedbackpost);
            await _db.SaveChangesAsync();
        }

        void IFeedbackpostRepository.UpdateFeedbackpostAsync(Feedbackpost post, byte[] rowversion)
        {
            throw new NotImplementedException();
        }
    }
}
