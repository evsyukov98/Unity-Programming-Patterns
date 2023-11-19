using DG.Tweening;
using UnityEngine;

namespace Common
{
    public class RotationTween : MonoBehaviour
    {
        [SerializeField] private Vector3 rotationAxis = Vector3.up; // Ось вращения
        [SerializeField] private float rotationDuration; 

        private void Start()
        {
            RotateObject();
        }

        private void RotateObject()
        {
            transform.DOLocalRotate(rotationAxis * 360, rotationDuration, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Incremental);
        }
    }
}
