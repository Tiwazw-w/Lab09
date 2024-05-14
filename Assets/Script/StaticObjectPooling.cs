using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    public GameObject platformPrefab; // Prefab de la plataforma
    public int poolSize = 10; // Tamaño del pool
    public float spawnRange = 10f; // Rango de generación aleatoria

    private List<GameObject> platformPool = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject platform = Instantiate(platformPrefab, transform.position, Quaternion.identity);
            platform.SetActive(false);
            platform.transform.parent = transform;
            platformPool.Add(platform);
        }
    }
    public GameObject GetRandomPlatform()
    {
        GameObject platform = TakeObjectFromPool();

        Vector3 randomPosition = transform.position + new Vector3(Random.Range(-spawnRange, spawnRange), 0f, 0f);
        platform.transform.position = randomPosition;

        platform.SetActive(true);
        return platform;
    }

    private GameObject TakeObjectFromPool()
    {
        foreach (GameObject platform in platformPool)
        {
            if (!platform.activeInHierarchy)
            {
                return platform;
            }
        }
        GameObject newPlatform = Instantiate(platformPrefab, transform.position, Quaternion.identity);
        newPlatform.SetActive(false);
        newPlatform.transform.parent = transform;
        platformPool.Add(newPlatform);
        return newPlatform;
    }
}


//public class StaticObjectPooling : MonoBehaviour
//{
//    public GameObject prefab;
//    public int poolSize = 10;

//    private List<GameObject> objectPool = new List<GameObject>();

//    private void Start()
//    {
//        for (int i = 0; i < poolSize; i++)
//        {
//            GameObject obj = Instantiate(prefab, transform.position, Quaternion.identity);
//            obj.SetActive(false);
//            objectPool.Add(obj);
//        }
//    }

//    public GameObject TakeObjectFromPool()
//    {
//        foreach (GameObject obj in objectPool)
//        {
//            if (!obj.activeInHierarchy)
//            {
//                obj.SetActive(true);
//                return obj;
//            }
//        }
//        GameObject newObj = Instantiate(prefab, transform.position, Quaternion.identity);
//        objectPool.Add(newObj);
//        return newObj;
//    }
//    public void ReturnObjectToPool(GameObject obj)
//    {
//        obj.SetActive(false);
//    }
//}

