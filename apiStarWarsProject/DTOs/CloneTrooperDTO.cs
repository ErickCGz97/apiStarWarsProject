namespace apiStarWarsProject
{
    public class CloneTrooperDTO
    {
        public string CloneTrooperIdDTO { get; set;}
        public string CloneTrooperNameDTO { get; set;}

        //Relaciones con entidades
        public int TrooperRankIdDTO { get; set; }
        public string? TrooperRankNameDTO { get; set; }
        
        public int TrooperArmyDivisionIdDTO { get; set; }
        public  string? TrooperArmyDivisionNameDTO { get; set; }
        
        public int TrooperStatusIdDTO { get; set; }
        public  string? TrooperStatusDTO { get; set; }

        public DateTime dateTime{ get; set; } = DateTime.Now;
}
}