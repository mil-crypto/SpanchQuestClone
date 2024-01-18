using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _waterPrefab;
    [SerializeField] private GameObject _lavaPrefab;
    [SerializeField] private Transform [] _waterStartPosition, _lavaStartPosition;
    [SerializeField] private short _fluidsAmount;
    [SerializeField] private bool _initWater, _initLava;
    [SerializeField] private Transform _fluidsContainer;

    private void Start()
    {
        if (_initWater)
        {
            foreach (Transform tempTranform in _waterStartPosition)
            {
                WaterInstantiate(tempTranform, _fluidsAmount, _waterPrefab);
            }
        }
        if (_initLava)
        {
            foreach (Transform tempTranform in _lavaStartPosition)
            {
                LavaInstantiate(tempTranform, _fluidsAmount, _lavaPrefab);
            }
        }
    }

    private void WaterInstantiate(Transform waterPos, short fludsSum,GameObject waterPrefab)
    {      
        for (int i = 0; i <= fludsSum; i++)
        {
            float random = Random.Range(-0.2f, 0.2f);
            var water = Instantiate(waterPrefab, _fluidsContainer);
            water.transform.position = new Vector3(waterPos.position.x + random, waterPos.position.y + random, 0f);        
        }
    }
    private void LavaInstantiate(Transform lavaPos, short fludsSum, GameObject lavaPrefab)
    {
        for (int i = 0; i <= fludsSum; i++)
        {
            float random = Random.Range(-0.2f, 0.2f);
            var lava = Instantiate(lavaPrefab, _fluidsContainer);
            lava.transform.position = new Vector3(lavaPos.position.x + random, lavaPos.position.y + random, 0f);
        }
    }
}
