using System.Collections.Generic;

namespace Patterns.Decorator
{
    public class ItemsStatsProvider : StatsDecorator
    {
        private readonly IEnumerable<string> _itemKeys;
        private readonly ItemsDateBase _dateBase;

        public ItemsStatsProvider(IStatsProvider wrappedEntity, IEnumerable<string> itemKeys, ItemsDateBase dateBase) : base(wrappedEntity)
        {
            _itemKeys = itemKeys;
            _dateBase = dateBase;
        }
        
        public ItemsStatsProvider(IStatsProvider wrappedEntity, IEnumerable<string> itemKeys) : base(wrappedEntity)
        {
            _itemKeys = itemKeys;
            _dateBase = new ItemsDateBase();
        }

        protected override PlayerStats GetStatsInternal()
        {
            PlayerStats stats = new PlayerStats();
            foreach (string item in _itemKeys)
            {
                stats += _dateBase.GetStats(item);
            }

            return _wrappedEntity.GetStats() + stats;
        }
    }
    
    public class ItemsDateBase 
    {
        public PlayerStats GetStats(string itemKey) //TODO: пока без реализации затычка в виде стейтмашин
        {
            switch (itemKey)
            {
                case "Sword": return new PlayerStats {Strength = 5, Agility = 5, Intelligence = 0, Stamina = 5};
                case "Mace": return new PlayerStats {Strength = 7, Agility = 2, Intelligence = 0, Stamina = 3};
                case "MagicStaff": return new PlayerStats { Strength = 2, Agility = 5, Intelligence = 10, Stamina = 5};
                case "Axe": return new PlayerStats {Strength = 9, Agility = 1, Intelligence = 0, Stamina = 2};
                default: return new PlayerStats();
            }
        }
    }
}