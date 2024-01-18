using UnityEngine;

public class StickCloser : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _anotherCircleSprite;
    [SerializeField] private Color _closeColor , _openColor;
    [SerializeField] private Transform _anotherStick;
    private Collider2D _anotherCollider;
    private void Start()
    {
        _anotherCollider = _anotherStick.GetComponent<Collider2D>();
    }
    private void OnMouseDown()
    {
        _anotherCircleSprite.color = _closeColor;
        _anotherCollider.enabled = false;
    }
    private void OnEnable()
    {
        EventActionController.EndExplosionBombAction += ActivateCollider2D;
    }
    private void OnDisable()
    {
        EventActionController.EndExplosionBombAction -= ActivateCollider2D;
    }
    private void ActivateCollider2D()
    {
        _anotherCircleSprite.color = _openColor;
        _anotherCollider.enabled = true; ;
    }
}
