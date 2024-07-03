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
    public class MaterialRepository : GenericRepository<Material>, IMaterialRepository
    {
        private readonly JPOSDbContext _context;
        public MaterialRepository(JPOSDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool?> CreateMaterial(Material material)
        {
            try {
                await _context.Materials.AddAsync(material);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex) {

                return false;
            }
              
           
        }

        public async Task<bool?> DeleteMaterial(int id)
        {
           throw new NotImplementedException();
        }

        public async Task<List<Material>?> GetAllMaterial()
        {
          return await _context.Materials.ToListAsync();
        }

        public async Task<Material?> GetMaterialById(int id)
        {
          var a = await _context.Materials.FirstOrDefaultAsync(x => x.MaterialID == id);
            return a;
         
        }

        public async Task<bool?> UpdateMaterial(int id,Material material)
        {
            Material? oldmaterial = await _context.Materials.FirstOrDefaultAsync(x => x.MaterialID == id);
            if (oldmaterial != null)
            {
                oldmaterial.Name = material.Name;
                oldmaterial.Price = material.Price;
                oldmaterial.TotalPrice = material.TotalPrice;
                oldmaterial.Status = material.Status;
                oldmaterial.Quantity = material.Quantity;
                _context.Materials.Update(material);
                return await _context.SaveChangesAsync() > 0;
            }
                 return false;
            
        }
    }
}