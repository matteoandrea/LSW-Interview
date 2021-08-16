using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ShopItem", menuName = "Shop/ShopItem", order = 0)]
public class ShopItem : ScriptableObject
{
    public string title;
    public Sprite sprite;
    public int price;
}
