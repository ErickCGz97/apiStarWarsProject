namespace apiStarWarsProject
{
    public class TropperRank
    {
        public int Id { get; set;}
        public string RankTrooperName { get; set;}

        public ICollection<CloneTrooper> cloneTroopersRanks{ get; set;}
    }
}