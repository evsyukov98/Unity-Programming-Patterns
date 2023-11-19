using DG.Tweening;
using UnityEngine;

namespace Patterns.Observer
{
    public class EnemyObserver : MonoBehaviour , IObserver
    {
        public void OnSubject()
        {
            Invoke(nameof(Animate), 0.2f);
        }

        private void Animate()
        {
            transform.DOPunchScale(Vector3.one, 0.2f);
        }
    }
}
