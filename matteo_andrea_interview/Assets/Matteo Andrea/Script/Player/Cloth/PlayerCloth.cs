using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerCloth
{
    [SerializeField] private PlayerClothManager _playerClothManager;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void OnEnable() => _playerClothManager.ChangeClothEvent += ChangeCloth;

    public void OnDisable() => _playerClothManager.ChangeClothEvent -= ChangeCloth;


    private void ChangeCloth(Sprite cloth) => _spriteRenderer.sprite = cloth;
}
