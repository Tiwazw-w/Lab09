using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public virtual void OnReturnToPool()
    {
        gameObject.SetActive(false);
    }

    public virtual void OnTakeFromPool()
    {
        gameObject.SetActive(true);
    }
}

