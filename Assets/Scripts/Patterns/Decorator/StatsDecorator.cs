
namespace Patterns.Decorator
{
    public interface IStatsProvider
    {
        public PlayerStats GetStats();
    }
    
    /// <summary>
    /// Декоратор хранит в себе другой декоратор. (для того чтобы выполнять действия с ним) 
    /// </summary>
    public abstract class StatsDecorator : IStatsProvider
    {
        protected readonly IStatsProvider _wrappedEntity;

        protected StatsDecorator(IStatsProvider wrappedEntity)
        {
            _wrappedEntity = wrappedEntity;
        }

        public PlayerStats GetStats() => GetStatsInternal();

        protected abstract PlayerStats GetStatsInternal();
    }
}