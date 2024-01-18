using DG.Tweening;
using UnityEngine;

public class DraggingReturnable : MonoBehaviour
{
    [SerializeField] private Vector3 _positionToMove;
    [SerializeField] private float _speed;
    private Vector3 _startPosition;
    private void Start()
    {
        _startPosition = transform.position;
    }
    private void OnMouseDown()
    {
        Vector3 curPos = transform.position;
        if (curPos == _startPosition)
        {
            transform.DOMove(_positionToMove, _speed);
        }
        else if (curPos == _positionToMove)
        {
            transform.DOMove(_startPosition, _speed);
        }
        else
            Debug.Log("CURPOS= " + curPos + "    STARTPOS= " + _startPosition + "    POSTOMOVE= " + _positionToMove);
    }
}
