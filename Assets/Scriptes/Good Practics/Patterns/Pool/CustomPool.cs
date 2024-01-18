using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomPool
{
    private GameObject _prefab;
    private List<GameObject> _objects;

    public CustomPool(GameObject prefab, int prewarmObjects)
    {
        _prefab = prefab;
        _objects = new List<GameObject>();

        for (int i = 0; i < prewarmObjects; i++)
        {
            var obj = Object.Instantiate(_prefab);
            obj.gameObject.SetActive(false);
            _objects.Add(obj);
        }
    }

    public GameObject Get()
    {
        var obj = _objects.FirstOrDefault(x => !x.activeSelf);

        if (obj == null)
        {
            obj = Create();
        }

        obj.gameObject.SetActive(true);
        return obj;
    }

    public void Release(GameObject obj)
    {
        obj.gameObject.SetActive(false);
    }

    private GameObject Create()
    {
        var obj = Object.Instantiate(_prefab);
        _objects.Add(obj);
        return obj;
    }
}