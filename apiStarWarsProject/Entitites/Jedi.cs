namespace apiStarWarsProject
{
    public class Jedi
    {
        public int Id { get; set;}
        public string JediName { get; set;}

        // Relacion con tabla JediRank -- Relation with JediRank table
        public int JediRank {get; set;}
        public virtual JediRank JediRankReference { get; set;}
    }
}