using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _diamondPrefab,_goldPrefab,_emeraldPrefab,_jevelryGlitterPrefab;
    [SerializeField] private GameObject _lavaPrefab;
    [SerializeField] private Transform [] _jewelryStartPosition, _lavaStartPosition;
    [SerializeField] private short _fluidsAmount,_jevelryAmount,_jevelryGlitterAmount;
    [SerializeField] private bool _initLava, _initJevelry;

    private void Start()
    {
        if (_initJevelry)
        {
            foreach (Transform tempTranform in _jewelryStartPosition)
            {
                JewelryInstantiate(tempTranform);
            }
        }
        if (_initLava)
        {
            foreach (Transform tempTranform in _lavaStartPosition)
            {
                LavaInstantiate(tempTranform);
            }
        }
    }

    private void JewelryInstantiate(Transform startPos)
    {
        RandInstantiate(startPos, _jevelryAmount, _diamondPrefab);
        RandInstantiate(startPos, _jevelryAmount, _goldPrefab);
        RandInstantiate(startPos, _jevelryAmount, _emeraldPrefab);
        RandInstantiate(startPos, _jevelryGlitterAmount, _jevelryGlitterPrefab);
    }
    private void LavaInstantiate(Transform startPos)
    {
        RandInstantiate(startPos, _fluidsAmount, _lavaPrefab);
    }

    private void RandInstantiate(Transform Pos, short fludsSum, GameObject Prefab)
    {
        for (int i = 0; i <= fludsSum; i++)
        {
            float random = Random.Range(-0.2f, 0.2f);
            var temp = Instantiate(Prefab);
            temp.transform.position = new Vector3(Pos.position.x + random, Pos.position.y + random, 0f);
        }
    }
}
