using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShopUI : MonoBehaviour
{
    [SerializeField] ShopControl _shopControl;

    [SerializeField] private float _animationTime;

    private Tween _tween;
    [SerializeField] private RectTransform _ui;  

    private void OnEnable()
    {
        _shopControl.OpenShopEvent += OnOpen;
        _shopControl.CloseShopEvent += OnClose;
    }

    private void OnDisable()
    {
        _shopControl.OpenShopEvent -= OnOpen;
        _shopControl.CloseShopEvent -= OnClose;
    }

    private void OnOpen()
    {
        _ui.gameObject.SetActive(true);
        _tween = _ui.DOScale(Vector3.one, _animationTime);
    }

    private void OnClose()
    {
        _tween = _ui.DOScale(Vector3.zero, _animationTime);
    }
}
