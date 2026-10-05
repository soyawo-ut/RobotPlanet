namespace RobotPlanet.Core
{
    public class CleanerBot : Robot, IChargeable
    {
        public CleanerBot(string name, int energy)
            : base(name, energy)
        {
        }

        public override string Work()
        {
            if (Energy < 5)
                return $"{Name} cannot clean because the battery is too low.";

            Energy -= 5;
            return $"{Name} cleaned the floor. Energy: {Energy}%";
        }

        public override string CrazyAction()
        {
            if (Energy < 15)
                return $"{Name} wanted to clean the whole planet, but the battery was too low.";

            Energy -= 15;
            return $"{Name} entered TURBO CLEANING MODE and tried to vacuum the whole planet!";
        }

        public string Charge(int amount)
        {
            if (amount <= 0)
                return "Charge amount must be positive.";

            Energy += amount;

            if (Energy > 100)
                Energy = 100;

            return $"{Name} charged to {Energy}%.";
        }
    }
}