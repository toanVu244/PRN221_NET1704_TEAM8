using JPOS.Model.Entities;
using JPOS.Model.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPOS.Model.Repositories.Implementations
{
    public class FeedbackRepository : GenericRepository<Feedback>, IFeedbackRepository
    {
        private readonly JPOSDbContext _context;
        public FeedbackRepository(JPOSDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<Feedback> GetFeedbacByID(int Id)
        {
            return await _context.Feedbacks.FirstOrDefaultAsync(f=>f.FeedBackID == Id);  
        }
    }
}
