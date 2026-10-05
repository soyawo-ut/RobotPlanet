using System;

namespace RobotPlanet.Core
{
    public abstract class Robot
    {
        public string Name { get; }
        public int Energy { get; protected set; }

        protected Robot(string name, int energy)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Robot name cannot be empty.");

            if (energy < 0 || energy > 100)
                throw new ArgumentException("Energy must be between 0 and 100.");

            Name = name;
            Energy = energy;
        }

        public virtual string Work()
        {
            if (Energy < 10)
                return $"{Name} has too little energy.";

            Energy -= 10;

            return $"{Name} performs normal robot work. Energy: {Energy}%";
        }

        public abstract string CrazyAction();

        public override string ToString()
        {
            return $"{GetType().Name}: {Name}";
        }
    }
}