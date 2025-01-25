using Microsoft.EntityFrameworkCore;

using apiStarWarsProject;

namespace apiStarWarsProject.Context
{
    public class ApplicationDbContext: DbContext
    {
        //Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<CloneTrooper> cloneTroopers {get; set;}
        public DbSet<ArmyDivision> armyDivisions{get; set;}
        public DbSet<TrooperStatus> trooperStatus {get; set;}
        public DbSet<TrooperRank> tropperRanks {get; set;}
        public DbSet<Jedi> jedis {get; set;}
        public DbSet<JediRank> jediRanks {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ArmyDivision>(toBD => {
                toBD.HasKey(col => col.Id);
                toBD.Property(col => col.ArmyDivisionName).IsRequired();
                
                toBD.ToTable("Army Division");
                           
            });

            modelBuilder.Entity<JediRank>(toBD => {
                toBD.HasKey(col => col.Id);
                toBD.Property(col => col.JediRankName).IsRequired();
                
                toBD.ToTable("Jedi Rank");            
            });

            modelBuilder.Entity<TrooperStatus>(toBD => {
                toBD.HasKey(col => col.Id);
                toBD.Property(col => col.StatusName).IsRequired();
                
                toBD.ToTable("Trooper Status");            
            });

            modelBuilder.Entity<TrooperRank>(toBD => {
                toBD.HasKey(col => col.Id);
                toBD.Property(col => col.RankTrooperName).IsRequired();
                
                toBD.ToTable("Trooper Rank");            
            });

            modelBuilder.Entity<Jedi>(toBD => {
                toBD.HasKey(col => col.Id);
                toBD.Property(col => col.Id).UseIdentityColumn().ValueGeneratedOnAdd();
                toBD.Property(col => col.JediName).IsRequired();
                
                toBD.HasOne(col => col.JediRankReference).WithMany(col => col.JedisCollection).HasForeignKey(col => col.JediRankId);
                toBD.HasOne(col => col.ArmyDivisionJediReference).WithMany(col => col.jediArmyDivisionCollection).HasForeignKey(col => col.ArmyDivisionJedi);
                
                toBD.ToTable("Jedis");            
            });

            modelBuilder.Entity<CloneTrooper>(toBD => {
                toBD.HasKey(col => col.CloneTrooperId);
                toBD.Property(col => col.CloneTrooperName).IsRequired().HasMaxLength(50);
                
                toBD.HasOne(col => col.TrooperRankReference).WithMany(col => col.cloneTroopersRanksCollection).HasForeignKey(col => col.TrooperRankId);
                toBD.HasOne(col => col.TrooperArmyDivisionReference).WithMany(col => col.cloneTroopersArmyDivisionCollection).HasForeignKey(col => col.TrooperArmyDivisionId);
                toBD.HasOne(col => col.TrooperStatusReference).WithMany(col => col.cloneTroopersStatusCollection).HasForeignKey(col => col.TrooperStatusId);                
                
                toBD.ToTable("Clone Trooper");
            
            });

        }
    }
}