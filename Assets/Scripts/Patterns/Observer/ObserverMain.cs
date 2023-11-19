using System.Collections.Generic;
using UnityEngine;

namespace Patterns.Observer
{
    /// <summary>
    /// Паттерн для уведомления подписчиков.
    /// В данном примере использована стандартная реализация
    /// (также можно просто использовать встроенные C# ивенты)
    /// Внимение! - Подписчики оповещаются в случайном порядке.
    /// </summary>
    public class ObserverMain : MonoBehaviour
    {
        [SerializeField] private List<EnemyObserver> observers;
        [SerializeField] private PlayerSubject subject;

        private void Start()
        {
            foreach (EnemyObserver observer in observers)
            {
                subject.Subscribe(observer);
            }
        }

        private void OnDestroy()
        {
            foreach (EnemyObserver observer in observers)
            {
                subject.Unsubscribe(observer);
            }
        }
    }
}