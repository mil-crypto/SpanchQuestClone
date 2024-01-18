using DG.Tweening;
using UnityEngine;

public class RemoveStick : MonoBehaviour
{
    [SerializeField] private RemoveStick _anotherStick;
    [SerializeField] private Vector2 _positionToMove;
    [SerializeField] private float _speed;
    private Vector2 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }
    private void OnMouseDown()
    {
        ChangePosition();
        _anotherStick.ChangePosition();
    }

    private void ChangePosition()
    {
        Vector2 curPos = transform.position;
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
