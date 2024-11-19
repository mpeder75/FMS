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
        Task<Feedbackpost> IFeedbackpostRepository.GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task IFeedbackpostRepository.AddAsync(Feedbackpost feedbackpost)
        {
            throw new NotImplementedException();
        }

        Task IFeedbackpostRepository.DeleteAsync(Guid postId)
        {
            throw new NotImplementedException();
        }


        Task IFeedbackpostRepository.UpdateAsync(Feedbackpost post, byte[] rowversion)
        {
            throw new NotImplementedException();
        }

        Task<List<Feedbackpost>> IFeedbackpostRepository.GetFeedbackpostsByRoom(Guid roomId)
        {
            throw new NotImplementedException();
        }
    }
}
