using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject ObjectPrefab = null;
    public int PoolSize = 10;

    void Start()
    {
        GeneratePool();
    }

    public void GeneratePool()
    {
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject Obj = Instantiate(ObjectPrefab,
            Vector3.zero, Quaternion.identity,
            transform);
            Obj.SetActive(false);
        }
    }

    public Transform Spawn(Transform parent,
    Vector3 position = new Vector3(),
    Quaternion rotation = new Quaternion(),
    Vector3 scale = new Vector3())
    {
        if (transform.childCount <= 0) return null;
        Transform child = transform.GetChild(0);
        child.SetParent(parent);
        child.position = position;
        child.rotation = rotation;
        child.localScale = scale;
        child.gameObject.SetActive(true);
        return child;
    }

    public void DeSpawn(Transform objectToDeSpawn)
    {
        objectToDeSpawn.gameObject.SetActive(false);
        objectToDeSpawn.SetParent(transform);
        objectToDeSpawn.position = Vector3.zero;
    }
}

