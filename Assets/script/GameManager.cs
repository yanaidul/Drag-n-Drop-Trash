using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameEventNoParam _onIncorrectAnswer;
    [SerializeField] private GameEventNoParam _onCorrectAnswer;
    [SerializeField] private GameEventNoParam _onWin;
    [SerializeField] private int _score;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private List<GameObject> _listTrash = new();

    public void OnIncorrectAnswer()
    {
        _onIncorrectAnswer.Raise();
        if(_score > 0)
        {
            _score -= 10;
            _scoreText.SetText("Score: " + _score.ToString());
        }
    }

    public void OnCorrectAnswer(GameObject discardedGameObject)
    {
        _listTrash.Remove(discardedGameObject);
        _onCorrectAnswer.Raise();
        _score += 10;
        _scoreText.SetText("Score: " + _score.ToString());
        if (_listTrash.Count <= 0)
        {
            _onWin.Raise();
        }
    }
}
