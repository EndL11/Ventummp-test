using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool
{
    private List<GameObject> _objects = new List<GameObject>();

    private int _size;
    private GameObject _prefab;
    private Transform _poolParent;

    public ObjectsPool(int size, GameObject prefab, Transform parent)
    {
        _size = size;
        _prefab = prefab;
        _poolParent = parent;

        CreatePool();
    }

    private void CreatePool()
    {
        for(int i = 0; i < _size; i++)
        {
            _objects.Add(CreateItem());
        }
    }

    public GameObject GetFreeItemOrCreate()
    {
        foreach (var item in _objects)
        {
            if (!item.activeInHierarchy)
                return item;
        }

        GameObject poolObject = CreateItem();
        _objects.Add(poolObject);

        _size++;

        return poolObject;
    }

    private GameObject CreateItem()
    {
        GameObject poolObject = GameObject.Instantiate(_prefab, _poolParent);
        poolObject.SetActive(false);
        poolObject.GetComponent<Coin>().Subscribe(ResetItem);

        return poolObject;
    }

    private void ResetItem(GameObject _object)
    {
        _object.SetActive(false);
    }
}
