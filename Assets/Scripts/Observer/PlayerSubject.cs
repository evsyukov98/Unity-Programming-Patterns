using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Observer
{
    public class PlayerSubject : MonoBehaviour, ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
    
        public void Subscribe(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach(IObserver enemy in observers)
            {
                enemy.OnSubject();
            }
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                NotifyObservers();
                transform.DOPunchScale(Vector3.one, 0.2f);
            }
        }
    }
}