using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothShop : BuyItem
{
    [SerializeField] private GameObject _selectButton;

    [SerializeField] private PlayerClothManager _playerCloth;

    public override void OnBuyItem()
    {
        base.OnBuyItem();
        buyButton.gameObject.SetActive(false);
        _selectButton.SetActive(true);
    }

    public override void UseItem()
    {
        _playerCloth.ChangeCloth(shopItem.sprite);
    }
}
