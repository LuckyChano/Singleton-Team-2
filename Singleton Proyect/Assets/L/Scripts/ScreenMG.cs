using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenMG : MonoBehaviour
{
    public static ScreenMG instance;

    public StaminaScreen staminaScreen;

    public MainMenuScreen mainMenu;

    private Stack<IScreen> _screens = new Stack<IScreen>();

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
        if (_screens.Count > 0)
        {
            _screens.Pop().Desactivate();
        }

        //Guardamos la patalla actual
        _screens.Push(screen);

        //Activamos la pantalla actual
        screen.Activate();
    }

    public void Pop()
    {
        //Si no hay panatallas guardadas retornamos
        if (_screens.Count <= 0)
            return;

        //Sacamos del stack la panatalla y la desactivamos
        _screens.Pop().Desactivate();
    }

}
