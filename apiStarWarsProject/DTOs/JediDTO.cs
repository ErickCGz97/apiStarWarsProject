namespace apiStarWarsProject.DTOs
{
    public class JediDTO
    {
        public int IdDTO { get; set;}
        public string JediNameDTO { get; set;}

        // Relacion con tabla JediRank -- Relation with JediRank table
        public int JediRankIdDTO {get; set;}
        public string? JediRankNameDTO { get; set;}

        // Relacion con ArmyDivision
        public int ArmyDivisionJediDTO {get; set;}
        public string? ArmyDivisionJediNameDTO { get; set;}
    }
}