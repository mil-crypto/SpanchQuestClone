using DG.Tweening;
using UnityEngine;

public class WindmillRotater : MonoBehaviour
{
    private bool _rotateRight;
    [SerializeField] private Vector3 _rotateRightVector, _rotateLeftVector;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Vector3 _startRotateVector;
    private void Start()
    {
        transform.DORotate(_startRotateVector, _rotateSpeed, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear)
                .SetRelative();
    }

    private void OnMouseDown()
    {
        Sequence mySequence = DOTween.Sequence();
        Sequence mySequence2 = DOTween.Sequence();
        EventActionController.GetSelectorAction();
        if (!_rotateRight)
        {
            mySequence2.Kill();
            mySequence.Append(transform.DORotate(_rotateRightVector, _rotateSpeed,RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear)
                .SetRelative());
            _rotateRight = true;
        }
        else if (_rotateRight)
        {
            mySequence.Kill();
            mySequence2.Append(transform.DORotate(_rotateLeftVector,_rotateSpeed,RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear)
                .SetRelative());
            _rotateRight = false;
        }
    }

}
