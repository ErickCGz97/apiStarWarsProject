namespace apiStarWarsProject
{
    public class JediRank
    {
        public int Id { get; set;}
        public string JediRankName { get; set;}

        public ICollection<Jedi> JedisCollection { get; set; }        
    }
}