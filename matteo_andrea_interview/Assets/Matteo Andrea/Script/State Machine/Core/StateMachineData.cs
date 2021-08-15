using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjSystem = System.Object;

[DisallowMultipleComponent]
public class StateMachineData : MonoBehaviour
{
    [SerializeField] StateMachineKeys _keys;

    public void InicializeData()
    {
        _keys.CreatKeys(this);
    }

    public Dictionary<string, ObjSystem> data = new Dictionary<string, ObjSystem>();

    public void CacheData(string s, ObjSystem obj)
    {
        if (data.ContainsKey(s)) return;

        data.Add(s, obj);
    }

    public bool GetData<T>(string key, out T value)
    {
        value = default;
        var isFind = data.TryGetValue(key, out var obj);

        if (isFind)
            value = (T)obj;

        return isFind;
    }

    public void SetData(string s, ObjSystem obj)
    {
        data[s] = obj;
    }
}