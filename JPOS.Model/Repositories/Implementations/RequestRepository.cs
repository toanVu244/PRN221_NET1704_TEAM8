using JPOS.Model.Entities;
using JPOS.Model.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JPOS.Model.Repositories.Implementations
{
    public class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        private readonly JPOSDbContext _context;
        public RequestRepository(JPOSDbContext context): base(context)
        {
            _context = context;
        }

        public async Task<Request?> GetLastRequestID()
        {
            var lastRequest = await _context.Requests
                .OrderByDescending(r=>r.ID)
                .FirstOrDefaultAsync();
            return lastRequest;
        }

        public async Task<Request?> GetRequestByID(int requestID)
        {
            return await _context.Requests.FirstOrDefaultAsync(r => r.ID == requestID);
        }

            public async Task<List<Request>> GetRequestByStatus(string status)
            {
            return await _context.Requests.Where(r => r.Status == status).ToListAsync();
            }

        public async Task<List<Request>?> GetRequestByTime(int year, int month)
        {
            return await _context.Requests
                         .Where(r => r.CreateDate.HasValue
                             && r.CreateDate.Value.Month == month
                                  && r.CreateDate.Value.Year == year)
                         .ToListAsync();
        }

        public async Task<bool> UpdateStatusAsync(int requestId, string status)
        {
            var request = await _context.Requests.FindAsync(requestId);
            if (request == null)
            {
                return false;
            }

            request.Status = status;

            _context.Requests.Update(request);
            return await _context.SaveChangesAsync() > 0;

        }
    }
}
