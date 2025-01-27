using Microsoft.EntityFrameworkCore;

using apiStarWarsProject.DTOs;
using apiStarWarsProject.Context;

namespace apiStarWarsProject.Services
{
    public class TrooperStatusService
    {
        private readonly ApplicationDbContext _context;

        public TrooperStatusService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TrooperStatusDTO>> GetTrooperStatus()
        {
            var totalStatus = new List<TrooperStatusDTO>();

            foreach(var item in await _context.trooperStatus.ToListAsync())
            {
                totalStatus.Add(new TrooperStatusDTO
                {
                    Id = item.Id,
                    StatusName = item.StatusName,
                });
            }
            return totalStatus;
        }

        public async Task<string> CreateTrooperStatus(TrooperStatusDTO trooperStatusDTO)
        {
            var _trooperStatus = new TrooperStatus
            {
                StatusName = trooperStatusDTO.StatusName
            };

            await _context.trooperStatus.AddAsync(_trooperStatus);
            await _context.SaveChangesAsync();

            return "Trooper Status created succesfully";
        }
    }
}
