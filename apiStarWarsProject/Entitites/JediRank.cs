namespace apiStarWarsProject
{
    public class JediRank
    {
        public int Id { get; set;}
        public string NameJediRank { get; set;}

        public ICollection<Jedi> Jedis { get; set; }        
    }
}