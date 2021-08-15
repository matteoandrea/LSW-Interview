using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pool", menuName = "Pool", order = 2)]
public class Pool : ScriptableObject
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField] private int totalCapacity;
    [SerializeField] private int currentCapacity;
    [SerializeField] private bool expandable;

    [SerializeField] private Queue<GameObject> pool = new Queue<GameObject>();

    //[SerializeField]private Dictionary<int, Queue<GameObject>> poolDictonary = new Dictionary<int, Queue<GameObject>>();


    public void Inicialize(GameObject obj)
    {
        currentCapacity = totalCapacity;

        for (int i = 0; i < totalCapacity; i++)
        {
            var go = Instantiate(prefab);
            go.transform.parent = obj.transform;
            go.SetActive(false);
            pool.Enqueue(go);
        }
    }

    public GameObject GetPool(Transform pos, Quaternion rot)
    {

        if (pool.Count > 0)
        { 
            var go = pool.Dequeue();
            go.transform.position = pos.position;
            go.transform.rotation = rot;
            go.SetActive(true);
            return go;
        }    
        else if(expandable)
        {
            return CreatNewObject(pos, rot);
        }        
      
        else return null;
    }

    private GameObject CreatNewObject(Transform pos, Quaternion rot)
    {
        var go = Instantiate(prefab, pos.position, rot);
        currentCapacity++;
        return go;  
        

    }

    public void ReturnPool(GameObject obj)
    {        
        //obj.transform
        pool.Enqueue(obj);           
        obj.SetActive(false);
    }
}
