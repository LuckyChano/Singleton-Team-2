using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CSceneManager : MonoBehaviour
{
    public static CSceneManager instance;
    public ScreenManager screenManager;

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
        }
    }

    public void EndGame(params object[] parameters)
    {
        AudioManager.instance.Play("Loose");
        screenManager.ShowScreen(ScreensType.gameOverScreen);

        Debug.Log("GAME OVER");
    }

    public void WinGame(params object[] parameters)
    {
        AudioManager.instance.Play("Win");
        screenManager.ShowScreen(ScreensType.winScreen);
    }

    public void MainMenu()
    {
        PlayerPrefs.DeleteKey("Money");
        PlayerPrefs.DeleteKey("Life");
        SceneManager.LoadScene("Main Menu");
    }

    public void RestartGame()
    {
        PlayerPrefs.DeleteKey("Money");
        PlayerPrefs.DeleteKey("Life");
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