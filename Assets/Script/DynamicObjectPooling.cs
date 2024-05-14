using System.Collections.Generic;
using UnityEngine;

public class DynamicObjectPooling : MonoBehaviour
{
    public GameObject prefab;
    public int initialPoolSize = 10;
    public int maxPoolSize = 20;

    private List<GameObject> objectPool = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            CreateNewObject();
        }
    }
    private void CreateNewObject()
    {
        if (objectPool.Count < maxPoolSize)
        {
            GameObject obj = Instantiate(prefab, transform.position, Quaternion.identity);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }
    public GameObject TakeObjectFromPool()
    {
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        if (objectPool.Count < maxPoolSize)
        {
            CreateNewObject();
            return objectPool[objectPool.Count - 1];
        }
        return null;
    }
    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}

