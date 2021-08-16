using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
public class BlinkSpriteColor : MonoBehaviour
{
    private Color _OriginColor;
    [SerializeField] private float _time;

    [SerializeField] private Color _targetColor;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _OriginColor = _spriteRenderer.color;
    }

    private void Start()
    {
        GotoTarget(_targetColor, _OriginColor);
    }

    private void GotoTarget(Color targetColor, Color baseColor)
    {
        _spriteRenderer.DOColor(targetColor, _time).OnComplete(() => GotoTarget(baseColor, targetColor));
    }
}

