using Microsoft.EntityFrameworkCore;

using apiStarWarsProject.DTOs;
using apiStarWarsProject.Context;

namespace apiStarWarsProject.Services
{
    public class JediRankService
    {
        private readonly ApplicationDbContext _context;

        public JediRankService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<JediRankDTO>> GetJediRanks()
        {
            var totalRanks = new List<JediRankDTO>();
            foreach(var item in await _context.jediRanks.ToListAsync())
            {
                totalRanks.Add(new JediRankDTO
                {
                    Id = item.Id,
                    JediRankName = item.JediRankName,
                });
            }
            return totalRanks;
        }

        public async Task<string> CreateJediRank(JediRankDTO jediRankDTO)
        {
            var _jediRank = new JediRank
            {
                JediRankName = jediRankDTO.JediRankName
            };

            await _context.jediRanks.AddAsync(_jediRank);
            await _context.SaveChangesAsync();

            return "Jedi Rank created succesfully";
        }
    }
}
