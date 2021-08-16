using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuyItem : ShopItemUI
{
    private void OnEnable()
    {
        playerCurrency.UpdateCurrencyEvent += CheckPrice;
    }

    public override void Start()
    {
        base.Start();

        CheckPrice(playerCurrency.Money);
    }

    public override void OnBuyItem()
    {
        base.OnBuyItem();
        playerCurrency.Money = -shopItem.price;
        buyButton.interactable = false;
        playerCurrency.UpdateCurrencyEvent -= CheckPrice;
    }

    private void CheckPrice(float currency)
    {
        if (currency >= shopItem.price) canBuy = true;
        else canBuy = false;

        buyButton.interactable = canBuy;
    }
}