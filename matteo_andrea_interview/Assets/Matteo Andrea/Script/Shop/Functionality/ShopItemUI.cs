using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ShopItemUI : MonoBehaviour
{
    public PlayerCurrency playerCurrency;

    public ShopItem shopItem;

    public TMP_Text title;
    public Image sprite;
    public TMP_Text priceText;

    public bool canBuy = false;

    public Button buyButton;

    public virtual void Start()
    {
        title.text = shopItem.title;
        sprite.sprite = shopItem.sprite;
        priceText.text = shopItem.price.ToString();
    }

    public virtual void OnBuyItem()
    {
        if (!canBuy) return;
    }

    public virtual void SellItem()
    {
        playerCurrency.Money = +shopItem.price;
    }

    public virtual void UseItem() { }
}
