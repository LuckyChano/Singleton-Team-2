using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;

    public int stamina;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayGame()
    {
        if (stamina > 0)
        {
            SceneManager.LoadScene("Lvl 1");
        }
        else
        {
            
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quited");
    }
}
