namespace apiStarWarsProject
{
    public class Jedi
    {
        public int Id { get; set;}
        public string JediName { get; set;}

        // Relacion con tabla JediRank -- Relation with JediRank table
        public int JediRankId {get; set;}
        public virtual JediRank JediRankReference { get; set;}

        public int ArmyDivisionJedi {get; set;}
        public virtual ArmyDivision ArmyDivisionJediReference { get; set;}
    }
}