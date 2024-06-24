using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Welcome : MonoBehaviour
{
    public InputField inputNama;
    public static string namePlayer;
    public Button buttonLanjut;
    

    void Start()
    {
       
    }

    void Update()
    {
        
    }

    public void InputPlayerName()
    {
        if (inputNama.text.Length > 0) //0 == tidak text wa == length menjadi 2 button aktif
        {
            buttonLanjut.interactable = true;
        } 
        else
        {
            buttonLanjut.interactable = false;
        }
    }

    public void ButtonLanjut()
    {
        namePlayer = inputNama.text;

        SceneManager.LoadScene(3);
    }
}