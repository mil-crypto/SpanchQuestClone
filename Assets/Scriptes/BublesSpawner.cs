using UnityEngine;
using DG.Tweening;
using System.Collections;

public class BublesSpawner : MonoBehaviour
{
    [SerializeField] GameObject [] _bubles;
    [SerializeField] private int _countOfBubles;
    [SerializeField] private float _durationOfUpMove;
    [SerializeField] private float _timeToDeactivateBubles;
    [SerializeField] private float _minPosX, _maxPosX, _minPosY, _maxPosY, _posZ;
    [SerializeField] private float _minScale, _maxScale;

    private void Start()
    {     
        InitBubles();
    }

    private void InitBubles()
    {
        for (int i = 0; i < _bubles.Length; i++)
        {
            float randomScale= Random.Range(_minScale, _maxScale);
            float randomPosX = Random.Range(_minPosX, _maxPosX);
            float randomPosY = Random.Range(_minPosY, _maxPosY);
            _bubles[i].transform.DOScale(randomScale,0f);
            _bubles[i].transform.position = new Vector3(randomPosX, randomPosY, _posZ);
            _bubles[i].transform.DOMoveY(99, _durationOfUpMove);
        }
        EventActionController.GetActivateBublesAction();
        StartCoroutine(BublesDeactivator());
    }

    private IEnumerator BublesDeactivator()
    {
        yield return new WaitForSeconds(_timeToDeactivateBubles);
        foreach(GameObject obj in _bubles)
        {
            obj.SetActive(false);
        }
    }
}
