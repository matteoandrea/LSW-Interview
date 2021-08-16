using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ShopControl", menuName = "Shop/ShopControl", order = 0)]
public class ShopControl : ScriptableObject
{
    public event UnityAction OpenShopEvent = delegate { };
    public event UnityAction CloseShopEvent = delegate { };

    public void OpenShop() => OpenShopEvent.Invoke();
    public void CloseShop() => CloseShopEvent.Invoke();
}



