namespace RobotPlanet.Core
{
    public class GuardBot : Robot, IChargeable
    {
        public GuardBot(string name, int energy)
            : base(name, energy)
        {
        }

        public override string Work()
        {
            if (Energy < 15)
                return $"{Name} cannot patrol because the battery is too low.";

            Energy -= 15;
            return $"{Name} is patrolling the perimeter. Energy: {Energy}%";
        }

        public override string CrazyAction()
        {
            if (Energy < 25)
                return $"{Name} wanted to activate emergency defense shield, but energy was too low.";

            Energy -= 25;
            return $"{Name} activated MAXIMUM SECURITY MODE and deployed energy shields everywhere! Energy: {Energy}%";
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