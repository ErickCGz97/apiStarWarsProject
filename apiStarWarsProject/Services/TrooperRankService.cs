using Microsoft.EntityFrameworkCore;

using apiStarWarsProject.DTOs;
using apiStarWarsProject.Context;

namespace apiStarWarsProject.Services
{
    public class TrooperRankService
    {
        private readonly ApplicationDbContext _context;

        public TrooperRankService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TrooperRankDTO>> GetTrooperRanks()
        {
            var totalRanks = new List<TrooperRankDTO>();

            foreach(var item in await _context.tropperRanks.ToListAsync())
            {
                totalRanks.Add(new TrooperRankDTO
                {
                    Id = item.Id,
                    RankTrooperName = item.RankTrooperName,
                });
            }
            return totalRanks;
        }

        public async Task<string> CreateTrooperRank(TrooperRankDTO trooperRankDTO)
        {
            var _trooperRank = new TrooperRank
            {
                RankTrooperName = trooperRankDTO.RankTrooperName
            };

            await _context.tropperRanks.AddAsync(_trooperRank);
            await _context.SaveChangesAsync();

            return "Trooper Rank created succesfully";
        }
    }
}
