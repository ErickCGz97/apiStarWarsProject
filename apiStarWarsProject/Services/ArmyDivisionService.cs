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

        public async Task<string> CreateArmyDivision(ArmyDivisionDTO armyDivisionDTO)
        {
            var _armyDivision = new ArmyDivision
            {
                ArmyDivisionName = armyDivisionDTO.ArmyDivisionName
            };

            await _context.armyDivisions.AddAsync(_armyDivision);
            await _context.SaveChangesAsync();

            return "Army Division created successfully";
        }
    }
}
