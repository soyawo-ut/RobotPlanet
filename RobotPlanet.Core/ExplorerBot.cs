namespace RobotPlanet.Core
{
    public class ExplorerBot : Robot, IChargeable
    {
        public ExplorerBot(string name, int energy)
            : base(name, energy)
        {
        }

        public override string Work()
        {
            if (Energy < 8)
                return $"{Name} cannot explore because the battery is too low.";

            Energy -= 8;
            return $"{Name} explored a new sector. Energy: {Energy}%";
        }

        public override string CrazyAction()
        {
            if (Energy < 30)
                return $"{Name} tried to launch into space, but only jumped 2 centimetres.";

            Energy -= 30;
            return $"{Name} launched itself into space without permission!";
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