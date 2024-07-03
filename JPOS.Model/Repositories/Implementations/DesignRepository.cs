﻿using JPOS.Model.Entities;
using JPOS.Model.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPOS.Model.Repositories.Implementations
{
    public class DesignRepository : GenericRepository<Design>, IDesignRepository
    {
        private readonly JPOSDbContext context;

        public DesignRepository(JPOSDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Design>?> GetAllDesign()
        {
            return await context.Designs.OrderByDescending(p => p.CreateDate).ToListAsync();
        }

        public async Task<Design?> GetLastDesign()
        {
            var lastRequest = await context.Designs
               .OrderByDescending(r => r.DesignID)
               .FirstOrDefaultAsync();
            return lastRequest;
        }
    }
}
