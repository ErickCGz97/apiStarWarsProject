namespace apiStarWarsProject
{
    public class ArmyDivision
    {
        public int Id { get; set;}
        public string ArmyDivisionName { get; set;}
        public ICollection<CloneTrooper> cloneTroopersArmyDivisionCollection { get; set; }        

        public ICollection<Jedi> jediArmyDivisionCollection { get; set; }        

    }
}