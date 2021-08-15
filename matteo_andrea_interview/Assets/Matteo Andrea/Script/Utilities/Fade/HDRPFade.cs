using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HDRPFade : MonoBehaviour
{
    [SerializeField] private FadeManager _fadeManager;

    [SerializeField] private Material _material;

    private Tween _tween;

    private void OnEnable()
    {
        _fadeManager.FadeInEvent += FadeIn;
        _fadeManager.FadeOutEvent += FadeOut;

        FadeOut(0);
    }

    private void OnDisable()
    {
         _fadeManager.FadeInEvent -= FadeIn;
        _fadeManager.FadeOutEvent -= FadeOut;
    }

    public void FadeIn(float i)
    {
        ChangeMaterialColor(new Vector3(1, 1, 1), i);
    }

    public void FadeOut(float i)
    {
        ChangeMaterialColor(new Vector3(0, 0, 0), i);
    }

    private void ChangeMaterialColor(Vector3 to, float t)
    {
        _tween?.Kill();

        Color c = new Color(to.x, to.y, to.z);
        _tween = _material.DOColor(c, "_Color", t);
    }

}
