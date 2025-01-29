using Microsoft.EntityFrameworkCore;


using apiStarWarsProject;
using apiStarWarsProject.Context;
using apiStarWarsProject.DTOs;

namespace apiStarWarsProject.Services
{
    public class JediService
    {
        private readonly ApplicationDbContext _context;

        public JediService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<JediDTO>> GetJedi()
        {
            var totalJedi = new List<JediDTO>();
            var listDB = await _context.jedis.Include(p => p.JediRankReference)
                                            .Include(p => p.ArmyDivisionJediReference).ToListAsync();
            
            foreach(var item in listDB)
            {
                totalJedi.Add(new JediDTO
                {
                    IdDTO = item.Id,
                    JediNameDTO = item.JediName,
                    JediRankIdDTO = item.JediRankId,
                    JediRankNameDTO = item.JediRankReference.JediRankName,
                    ArmyDivisionJediDTO = item.ArmyDivisionJedi,
                    ArmyDivisionJediNameDTO = item.ArmyDivisionJediReference.ArmyDivisionName
                });
            }
            return totalJedi;
        }

        public async Task<string> SaveJediData(JediDTO jediDTO)
        {
            var jediDB = new Jedi
            {
                JediName = jediDTO.JediNameDTO,
                JediRankId = jediDTO.JediRankIdDTO,
                ArmyDivisionJedi = jediDTO.ArmyDivisionJediDTO
            };

            await _context.jedis.AddAsync(jediDB);
            await _context.SaveChangesAsync();

            return "Jedi data created successfully";
        }

        public async Task<string> UpdateJedi(JediDTO jediDTO)
        {
             var jediDB = await _context.jedis.Include(p => p.JediRankReference)
                                                .Include(p => p.ArmyDivisionJediReference)   
                .Where(e => e.Id == jediDTO.IdDTO).FirstAsync();

            if(jediDB  is null){
                 return "Data not found";
            }
            
            jediDB.JediName = jediDTO.JediNameDTO;
            jediDB.JediRankId = jediDTO.JediRankIdDTO;
            jediDB.ArmyDivisionJedi = jediDTO.ArmyDivisionJediDTO;

            _context.jedis.Update(jediDB);
            await _context.SaveChangesAsync();
            
            return "Data modified";
        }

        public async Task<string> DeleteJediData(int id)
        {
             var jediDB = await _context.jedis.FindAsync(id);

            if(jediDB  is null){
                 return "Data not found";
            }

            _context.jedis.Remove(jediDB);
            await _context.SaveChangesAsync();
            
            return "Jedi data removed";
        }
    }
}