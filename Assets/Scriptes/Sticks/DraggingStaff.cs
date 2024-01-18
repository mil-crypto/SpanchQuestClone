using DG.Tweening;
using UnityEngine;
public class DraggingStaff : MonoBehaviour
{
    [SerializeField] private Vector3 _positionToMove;
    private void OnMouseDown()
    {
        transform.DOMove(_positionToMove,0.5f);
    }
}
