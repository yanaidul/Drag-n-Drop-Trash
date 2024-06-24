using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHome : MonoBehaviour
{
    public void TombolKeluar()
    {
        Application.Quit();
        Debug.Log("Game Close");
    }

    public float delayTime = 0.5f;

    public void LoadScene(string sceneName)
    {
        StartCoroutine(DelayedLoadScene(sceneName));
    }

    private IEnumerator DelayedLoadScene(string sceneName)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(sceneName);
    }

    public void Mainkan()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Home()
    {
        SceneManager.LoadScene("mainmenu");
    }
}