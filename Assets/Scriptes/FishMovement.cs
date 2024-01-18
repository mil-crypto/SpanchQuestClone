using UnityEngine;
using DG.Tweening;
using System.Collections;

public class FishMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _duration;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _sekToFlip;
    private void Start()
    {
        Vector3[] arrVec3 =new Vector3[_waypoints.Length];
        for(int i=0; i<_waypoints.Length;i++)
        {
            arrVec3[i] = _waypoints[i].position;
        }
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Tween tween= transform.DOPath(arrVec3, _duration,PathType.CatmullRom).SetOptions(true).SetLookAt(1f);
        tween.SetEase(Ease.Linear).SetLoops(-1);
    }

    private IEnumerator FlipForDelay(bool cur)
    {
        yield return new WaitForSeconds(_sekToFlip);
        switch (cur)
        {
            case true:
                _spriteRenderer.flipX = true;
                break;
            case false:
                _spriteRenderer.flipX = false;
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LeftPoint"))
        {
            StartCoroutine(FlipForDelay(true));
        }
        else if (collision.gameObject.CompareTag("RightPoint"))
        {
            StartCoroutine(FlipForDelay(false));
        }
    }
}
