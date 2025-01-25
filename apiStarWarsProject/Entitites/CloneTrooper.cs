namespace apiStarWarsProject
{
    public class CloneTrooper
    {
        public string Id { get; set;}
        public string CloneTrooperName { get; set;}

        //Relaciones con entidades
        public int TrooperRankId { get; set; }
        public virtual TropperRank TrooperRankReference { get; set; }
        
        public int TrooperArmyDivisionId { get; set; }
        public virtual ArmyDivision TrooperArmyDivisionReference { get; set; }
        
        public int TrooperStatusId { get; set; }
        public virtual TrooperStatus TrooperStatusReference { get; set; }
}
}