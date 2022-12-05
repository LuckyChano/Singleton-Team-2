using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CSceneManager : MonoBehaviour
{
    public static CSceneManager instance;

    public void Awake()
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
        if (GameManager.instance.puedoJugar)
        {
            SceneManager.LoadScene("Lvl 1");
        }
        else
        {
            //abre la pantalla scren de stamina
            ScreenMG.instance.staminaScreen.Activate();
        }

    }

    public void EndGame()
    {
        //Agregar splash de derrota.// FALTA
        GameManager.instance.gameEnded = true;
        Debug.Log("GAME OVER");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quited");
    }
}
