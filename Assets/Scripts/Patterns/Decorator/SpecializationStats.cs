namespace Patterns.Decorator
{
    public class SpecializationStats : StatsDecorator
    {
        private readonly SpecializationType _specialization;

        public SpecializationStats(IStatsProvider wrappedEntity, SpecializationType specialization) : base(wrappedEntity)
        {
            _specialization = specialization;
        }

        protected override PlayerStats GetStatsInternal()
        {
            return _wrappedEntity.GetStats() + GetSpecStats(_specialization);
        }

        private PlayerStats GetSpecStats(SpecializationType spec)
        {
            switch (spec)   
            {
                case SpecializationType.Warrior: return new PlayerStats {Strength = 10, Agility = 5, Intelligence = 2, Stamina = 6};
                case SpecializationType.Mage: return new PlayerStats {Strength = 2, Agility = 4, Intelligence = 10, Stamina = 3};
                case SpecializationType.Rogue: return new PlayerStats {Strength = 6, Agility = 10, Intelligence = 5, Stamina = 8};
                case SpecializationType.Hunter: return new PlayerStats {Strength = 6, Agility = 7, Intelligence = 8, Stamina = 10};
                default: return new PlayerStats();
            }
        }
    }
    
    public enum SpecializationType
    {
        Warrior,
        Mage,
        Rogue,
        Hunter
    }
}