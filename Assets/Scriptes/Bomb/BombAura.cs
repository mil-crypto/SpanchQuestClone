using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAura : MonoBehaviour
{
    [SerializeField] private float _timer;
    private List<Collider2D> _tachingList = new();
    [SerializeField] private int _amountOfFluids;
    [SerializeField] private GameObject _explosionEffect;
    [SerializeField] private Vector2 _scaleVector;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponentInParent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lava") || collision.gameObject.CompareTag("Water")|| collision.gameObject.CompareTag("Jevelry"))
        {
            //for (int i=0;i<_tachingList.Count;i++)
           // {
               // if (_tachingList.Count > 0)
               // {
                  //  if (collision.GetHashCode() == _tachingList[i].GetHashCode())
                   // {
                   //     return;
                   // }
               // }
               // else if(_tachingList.Count==0)
                //{
                    _tachingList.Add(collision);
               // }    
           // }
            //_tachingList.Add(collision);
            if ( _tachingList.Count >= _amountOfFluids)
            {
                StartCoroutine(Explosion(_tachingList));
            }
                  }
        else if (collision.gameObject.CompareTag("Player"))
        {
            _tachingList.Add(collision);
            StartCoroutine(Explosion(_tachingList));
        }
        else if (collision.gameObject.CompareTag("Zombi"))
        {
            _tachingList.Add(collision);
            StartCoroutine(Explosion(_tachingList));
            
        }
        else if(collision.TryGetComponent(out Bomb _))
        {
            _tachingList.Add(collision);
            StartCoroutine(Explosion(_tachingList));
        }  
    }

    private IEnumerator Explosion(List<Collider2D> list)
    {
        //transform.parent.DOScale(_scaleVector, 0.6f).SetLoops(-1, LoopType.Yoyo);
        _animator.SetBool("Explose", true);
        yield return new WaitForSeconds(_timer);

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] != null)
            {
                if (list[i].gameObject.CompareTag("Player"))
                {
                    EventActionController.GetEndGameEvent();
                    Destroy(list[i].gameObject);
                }
                if (list[i].gameObject.CompareTag("Zombi"))
                {
                    EventActionController.GetWinGameEvent();
                    Destroy(list[i].gameObject);
                }
                else
                {
                    Destroy(list[i].gameObject);
                }                      
            }
            else if (list[i] == null)
            {
                Debug.Log(list[i].ToString()+"   This is empty member");
            }
        }
        for (int i = list.Count-1; i > 0; i--)
        {
            list.Remove(list[i]);
        }
        Destroy(transform.parent.gameObject);
        EventActionController.GetEndExplosionBombAction();
        ActivateExplosionEffect();
    }

    private void ActivateExplosionEffect()
    {
        var effect = Instantiate(_explosionEffect);
        effect.transform.position = transform.position;
    }
}
