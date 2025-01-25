namespace apiStarWarsProject
{
    public class ArmyDivision
    {
        public int Id { get; set;}
        public string ArmyDivisionName { get; set;}
        public ICollection<CloneTrooper> cloneTroopersArmyDivision { get; set; }        
    }
}