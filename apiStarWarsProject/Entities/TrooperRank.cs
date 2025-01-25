namespace apiStarWarsProject
{
    public class TrooperRank
    {
        public int Id { get; set;}
        public string RankTrooperName { get; set;}

        public ICollection<CloneTrooper> cloneTroopersRanksCollection{ get; set;}
    }
}