namespace apiStarWarsProject
{
    public class TrooperStatus
    {
        public int Id { get; set;}
        public string StatusName { get; set;}
        public ICollection<CloneTrooper> cloneTroopersStatus { get; set; }        
    }
}