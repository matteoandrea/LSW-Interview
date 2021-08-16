using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private InputReader _input;
    [SerializeField] private PauseManager _pauseManager;

    [SerializeField] private RectTransform _pauseCanvas;

    private Tween _tween;

    private void OnEnable()
    {
        _input.PauseEvent += PauseInput;
    }

    private void OnDisable()
    {
        _input.PauseEvent -= PauseInput;
    }

    private void Start()
    {
        _pauseManager.PlayGame();
    }

    private void PauseInput()
    {
        if (Time.timeScale == 0) PlayGame();
        else PauseGame();
    }

    public void PauseGame()
    {
        _pauseManager.PauseGame();
        _pauseCanvas.gameObject.SetActive(true);
        _pauseCanvas.DOScale(1, .4f);

    }

    public void PlayGame()
    {
        _pauseManager.PlayGame();
        _pauseCanvas.DOScale(0, .4f).OnComplete(() => _pauseCanvas.gameObject.SetActive(false));
    }

}
