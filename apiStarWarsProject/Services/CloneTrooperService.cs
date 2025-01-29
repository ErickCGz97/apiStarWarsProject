using Microsoft.EntityFrameworkCore;


using apiStarWarsProject;
using apiStarWarsProject.Context;
using apiStarWarsProject.DTOs;

namespace apiStarWarsProject.Services
{
    public class CloneTrooperService
    {
        private readonly ApplicationDbContext _context;

        public CloneTrooperService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CloneTrooperDTO>> GetTrooper()
        {
            var listTrooper = new List<CloneTrooperDTO>();
            var listDB = await _context.cloneTroopers.Include(p => p.TrooperRankReference)
                                            .Include(p => p.TrooperArmyDivisionReference)
                                            .Include(p => p.TrooperStatusReference).ToListAsync();
            
            foreach(var item in listDB)
            {
                listTrooper.Add(new CloneTrooperDTO
                {
                    CloneTrooperIdDTO = item.CloneTrooperId,
                    CloneTrooperNameDTO = item.CloneTrooperName,
                    TrooperRankIdDTO = item.TrooperRankId,
                    TrooperRankNameDTO = item.TrooperRankReference.RankTrooperName,
                    TrooperArmyDivisionIdDTO = item.TrooperArmyDivisionId,
                    TrooperArmyDivisionNameDTO = item.TrooperArmyDivisionReference.ArmyDivisionName,
                    TrooperStatusIdDTO = item.TrooperStatusId,
                    TrooperStatusDTO = item.TrooperStatusReference.StatusName,
                    dateTime = item.dateTime
                });
            }
            return listTrooper;
        }

        public async Task<string> SaveTrooperData(CloneTrooperDTO cloneTrooperDTO)
        {
            var listDB = new CloneTrooper
            {
                CloneTrooperId = cloneTrooperDTO.CloneTrooperIdDTO,
                CloneTrooperName = cloneTrooperDTO.CloneTrooperNameDTO,
                TrooperRankId = cloneTrooperDTO.TrooperRankIdDTO,
                TrooperArmyDivisionId = cloneTrooperDTO.TrooperArmyDivisionIdDTO,
                TrooperStatusId = cloneTrooperDTO.TrooperStatusIdDTO
            };

            await _context.cloneTroopers.AddAsync(listDB);
            await _context.SaveChangesAsync();

            return "Trooper data created successfully";
        }

        public async Task<string> UpdateTrooper(CloneTrooperDTO cloneTrooperDTO)
        {
             var listDB = await _context.cloneTroopers.Include(p => p.TrooperRankReference)
                                                .Include(p => p.TrooperArmyDivisionReference)
                                                .Include(p => p.TrooperStatusReference)   
                .Where(e => e.CloneTrooperId == cloneTrooperDTO.CloneTrooperIdDTO).FirstOrDefaultAsync();

            if(listDB  is null){
                 return "Data not found";
            }
            
            listDB.CloneTrooperName = cloneTrooperDTO.CloneTrooperNameDTO;
            listDB.TrooperRankId = cloneTrooperDTO.TrooperRankIdDTO;
            listDB.TrooperArmyDivisionId = cloneTrooperDTO.TrooperArmyDivisionIdDTO;
            listDB.TrooperStatusId = cloneTrooperDTO.TrooperStatusIdDTO;

            _context.cloneTroopers.Update(listDB);
            await _context.SaveChangesAsync();
            
            return "Data modified";
        }

        public async Task<string> DeleteTrooperData(string id)
        {
             var listDB = await _context.cloneTroopers.FindAsync(id);

            if(listDB  is null){
                 return "Data not found";
            }

            _context.cloneTroopers.Remove(listDB);
            await _context.SaveChangesAsync();
            
            return "Trooper data removed";
        }
    }
}