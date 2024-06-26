using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void OnRestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void ToGameScene()
    {
        SceneManager.LoadScene(4);
    }
}
