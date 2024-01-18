using DG.Tweening;
using UnityEngine;

public class RemoveSticsThreePositions : MonoBehaviour
{
    [SerializeField] private RemoveSticsThreePositions _anotherStick;
    [SerializeField] private Vector2 _startPosition, _secondPositionToMove;
    [SerializeField] private float _speed;
    private Vector2 _firstPositionToMove;
    private bool _isUpPosition;

    private void Start()
    {
        _firstPositionToMove = transform.position;
    }
    private void OnMouseDown()
    {
        ChangePosition();
       _anotherStick.ChangePosition();
    }

    private void ChangePosition()
    {
        Vector2 curPos = transform.position;
        if (curPos == _startPosition && _isUpPosition == false)
        {
            transform.DOMove(_firstPositionToMove, _speed);
            _isUpPosition = true;
        }

        else if (curPos == _startPosition && _isUpPosition == true)
        {
            transform.DOMove(_secondPositionToMove, _speed);
            _isUpPosition = false;
        }

        else if (curPos == _firstPositionToMove)
        {
            transform.DOMove(_startPosition, _speed);
        }

        else if(curPos == _secondPositionToMove)
        {
            transform.DOMove(_startPosition, _speed);
        }

        else
            Debug.Log("CURPOS= " + curPos + "    STARTPOS= " + _startPosition + "    POSTOMOVE= " + _firstPositionToMove);
    }
}
