using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedbackService.Application;
using FeedbackService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeedbackService.Infrastructure.Repositories
{
    internal class FeedbackpostRepository : IFeedbackpostRepository
    {
        private readonly FeedbackContext _db;

        public FeedbackpostRepository(FeedbackContext context)
        {
            _db = context;
        }
        async Task<Feedbackpost> IFeedbackpostRepository.GetAsync(Guid id)
        {
            try
            {
                return await _db.Feedbackposts.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        async Task<List<Feedbackpost>> IFeedbackpostRepository.GetFeedbackposts()
        {
            return await _db.Feedbackposts.ToListAsync();
        }

        async Task IFeedbackpostRepository.AddAsync(Feedbackpost feedbackpost)
        {
            throw new NotImplementedException();
        }

        async Task IFeedbackpostRepository.DeleteAsync(Guid postId)
        {
            throw new NotImplementedException();
        }


        async Task IFeedbackpostRepository.UpdateAsync(Feedbackpost post, byte[] rowversion)
        {
            throw new NotImplementedException();
        }

        async Task<List<Feedbackpost>> IFeedbackpostRepository.GetFeedbackpostsByRoom(Guid roomId)
        {
            return await _db.Feedbackposts.Where(x => x.Room.Id == roomId).ToListAsync();
        }
    }
}
