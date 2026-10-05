namespace RobotPlanet.Core
{
    public class RepairBot : Robot, IChargeable, IRepair
    {
        public RepairBot(string name, int energy)
            : base(name, energy)
        {
        }

        public override string Work()
        {
            if (Energy < 7)
                return $"{Name} cannot work because the battery is too low.";

            Energy -= 7;
            return $"{Name} repaired a machine. Energy: {Energy}%";
        }

        public override string CrazyAction()
        {
            if (Energy < 20)
                return $"{Name} tried to repair itself but accidentally opened Calculator.";

            Energy -= 20;
            return $"{Name} upgraded the coffee machine into a rocket engine!";
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

        public string Repair()
        {
            if (Energy < 10)
                return $"{Name} does not have enough energy for a special repair.";

            Energy -= 10;
            return $"{Name} completed a special repair. Energy: {Energy}%";
        }
    }
}