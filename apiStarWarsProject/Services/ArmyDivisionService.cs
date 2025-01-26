using Microsoft.EntityFrameworkCore;

using apiStarWarsProject.DTOs;
using apiStarWarsProject.Context;

namespace apiStarWarsProject.Services
{
    public class ArmyDivisionService
    {
        private readonly ApplicationDbContext _context;

        public ArmyDivisionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ArmyDivisionDTO>> GetDivisions()
        {
            var totalDivisions = new List<ArmyDivisionDTO>();

            foreach(var item in await _context.armyDivisions.ToListAsync())
            {
                totalDivisions.Add(new ArmyDivisionDTO
                {
                    Id = item.Id,
                    ArmyDivisionName = item.ArmyDivisionName,
                });
            }
            return totalDivisions;
        }
    }
}
