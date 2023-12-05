
namespace Patterns.Decorator
{
    public class EffectsStats : StatsDecorator
    {
        private readonly EffectType _effect;
        
        public EffectsStats(IStatsProvider wrappedEntity, EffectType effect) : base(wrappedEntity)
        {
            _effect = effect;
        }
        
        protected override PlayerStats GetStatsInternal()
        {
            return _wrappedEntity.GetStats() * GetEffectMultiplier(_effect);
        }

        public static PlayerStats GetEffectMultiplier(EffectType effect)
        {
            switch (effect)
            {
                case EffectType.HolyBless: return new PlayerStats {Strength = 1.5f, Agility = 1.5f, Intelligence = 1.5f, Stamina = 1.5f};
                case EffectType.TitanStrength: return new PlayerStats {Strength = 2f, Agility = 2f, Intelligence = 1, Stamina = 1};
                case EffectType.Cursed: return new PlayerStats {Strength = 0.2f, Agility = 0.2f, Intelligence = 1, Stamina = 0.2f};
                case EffectType.None: return new PlayerStats {Strength = 1, Agility = 1, Intelligence = 1, Stamina = 1};
                default: return new PlayerStats();
            }
        }
    }
    
    public enum EffectType
    {
        None,
        HolyBless,
        TitanStrength,
        Cursed
    }
}