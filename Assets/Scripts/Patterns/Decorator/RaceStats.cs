namespace Patterns.Decorator
{
    public class RaceStats : IStatsProvider
    {
        private readonly RaceType _raceType;

        public RaceStats(RaceType raceType)
        {
            _raceType = raceType;
        }

        public PlayerStats GetStats()
        {
            switch (_raceType)
            {
                case RaceType.Human: return new PlayerStats {Strength = 5, Agility = 5, Intelligence = 6, Stamina = 8};
                case RaceType.Ork: return new PlayerStats {Strength = 10, Agility = 3, Intelligence = 2, Stamina = 8};
                case RaceType.Elf: return new PlayerStats { Strength = 4, Agility = 8, Intelligence = 9, Stamina = 5};
                case RaceType.Dwarf: return new PlayerStats {Strength = 7, Agility = 3, Intelligence = 8, Stamina = 5};
                default: return new PlayerStats();
            }
        }
    }
}