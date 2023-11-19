namespace Patterns.Observer
{
    public interface ISubject 
    {
        void Subscribe(IObserver observer);
        void Unsubscribe(IObserver observer);
        void NotifyObservers();
    }
}