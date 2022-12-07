using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScreenMG : MonoBehaviour
{
    public static ScreenMG instance;

    public MainMenuScreen mainMenu = null;
    
    private Dictionary<ScreensType, Screens> _allScreens = new Dictionary<ScreensType, Screens>();

    private Stack<IScreen> _stackScrens = new Stack<IScreen>();


    //sacar el stack de screens y hacerlo lista y por cada elemento de la lista lo voy a buscar el que necesito para apagarlo o prenderlo.

    void Awake()
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

    public void Push(IScreen screen)
    {
        //Si hay pantallas en el stack las sacamos de la pila y las desactivamos
        if (_stackScrens.Count > 0)
        {
            _stackScrens.Pop().Desactivate();
        }

        //Guardamos la patalla actual
        _stackScrens.Push(screen);

        //Activamos la pantalla actual
        screen.Activate();
    }

    public void Pop()
    {
        //Si no hay panatallas guardadas retornamos
        if (_stackScrens.Count <= 0)
            return;

        //Sacamos del stack la panatalla y la desactivamos
        _stackScrens.Pop().Desactivate();
    }

    public void AddScreen(ScreensType type, Screens screen)
    {
        if (!_allScreens.ContainsKey(type))
        {
            _allScreens.Add(type, screen);

            Debug.Log("se cargo la pantalla " + type.ToString());
        }
    }

    public void AddMainMenu(MainMenuScreen menu)
    {
        mainMenu = menu;
    }

    public void RemoveScreen(ScreensType type, Screens screen)
    {
        if (_allScreens.ContainsKey(type))
        {
            _allScreens.Remove(type);
        }
    }

    public Screens GetScreens(ScreensType type)
    {
        if (_allScreens.ContainsKey(type))
        {
        }

        return _allScreens[type];
    }
}
