using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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

    private void Start()
    {
        EventManager.Subscribe(EventManager.NameEvent.Win, WinGame);
        EventManager.Subscribe(EventManager.NameEvent.Lose, EndGame);
    }

    public void PlayGame()
    {
        if (GameManager.instance.puedoJugar)
        {
            SceneManager.LoadScene("Lvl 1");
            Time.timeScale = 0f;
            //ScreenMG.instance.GetScreens(ScreensType.infoScreen).Activate();
        }
        else
        {
            //abre la pantalla scren de stamina
            //ScreenMG.instance.staminaScreen.Activate();
            ScreenMG.instance.GetScreens(ScreensType.staminaScreen).Activate();
        }

    }

    public void EndGame(params object[] parameters)
    {
        ScreenMG.instance.GetScreens(ScreensType.gameOverScreen).Activate();

        Debug.Log("GAME OVER");
    }

    public void WinGame(params object[] parameters)
    {
        ScreenMG.instance.GetScreens(ScreensType.winScreen).Activate();

        Debug.Log("GANASTE!");
        Debug.Log("Sobreviviste a: " + GameManager.instance.waveSurvive + " ordas!");
        Debug.Log("Derrotaste a: " + GameManager.instance.enemiesKill + " enemigos!");
    }

    public void MianMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void RestarGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quited");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Lvl 2");
    }
}
