using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private List<Pool> pools;

    private void Start()
    {
        foreach (var item in pools)
        {
            item.Inicialize(this.gameObject);
        }
    }
}
