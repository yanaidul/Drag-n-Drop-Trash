using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : Singleton<CanvasManager>
{
    [SerializeField] private GameObject _openingPanel, _gamePanel, _popUpGameOver, _popUpWin;

    private void Start()
    {
        Time.timeScale = 1;
        TurnOffAllUI();
        _openingPanel.SetActive(true);
    }

    public void OnDisplayGamePanel()
    {
        TurnOffAllUI();
        _gamePanel.SetActive(true);
    }

    public void OnDisplayGameOver()
    {
        Time.timeScale = 0;
        TurnOffAllUI();
        _popUpGameOver.SetActive(true);
    }

    public void OnDisplayWin()
    {
        Time.timeScale = 0;
        TurnOffAllUI();
        _popUpWin.SetActive(true);
    }

    private void TurnOffAllUI()
    {
        _openingPanel.SetActive(false);
        _gamePanel.SetActive(false);
        _popUpGameOver.SetActive(false);
        _popUpWin.SetActive(false);
    }
}
