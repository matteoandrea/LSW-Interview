using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class PlayerWalletUI : MonoBehaviour
{
    [SerializeField] private PlayerCurrency _playerCurrency;
    private TMP_Text _text;

    private void OnEnable() => _playerCurrency.UpdateCurrencyEvent += UpdateUI;

    private void OnDisable() => _playerCurrency.UpdateCurrencyEvent += UpdateUI;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Start() => UpdateUI(_playerCurrency.Money);

    private void UpdateUI(float value) => _text.text = value.ToString();
}
