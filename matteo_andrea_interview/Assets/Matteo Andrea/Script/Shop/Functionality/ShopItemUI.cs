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

    public bool canBuy;

    public Button buyButton;

    private void OnEnable()
    {
        playerCurrency.UpdateCurrencyEvent += CheckPrice;
    }

    private void Start()
    {
        title.text = shopItem.title;
        sprite.sprite = shopItem.sprite;
        priceText.text = shopItem.price.ToString();

        CheckPrice(playerCurrency.Money);
    }

    private void CheckPrice(float currency)
    {
        if (currency >= shopItem.price) canBuy = true;
        else canBuy = false;

        buyButton.interactable = canBuy;
    }

    public virtual void BuyItem()
    {
        if (!canBuy) return;

        playerCurrency.Money = -shopItem.price;
        buyButton.interactable = false;
        playerCurrency.UpdateCurrencyEvent -= CheckPrice;
    }

    public virtual void SellItem()
    {
        playerCurrency.Money = +shopItem.price;
    }

    public virtual void UseItem() { }
}
