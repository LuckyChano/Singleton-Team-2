using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenMG : MonoBehaviour
{
    public static ScreenMG instance;

    public StaminaScreen staminaScreen;

    public MainMenuScreen mainMenu;

    public StoreScreen storeScreen;

    public OptionsScreen optionsScreen;

    private Stack<IScreen> _screns = new Stack<IScreen>();

    private Dictionary<string, Screens> _screens = new Dictionary<string, Screens>();

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
        if (_screns.Count > 0)
        {
            _screns.Pop().Desactivate();
        }

        //Guardamos la patalla actual
        _screns.Push(screen);

        //Activamos la pantalla actual
        screen.Activate();
    }

    public void Pop()
    {
        //Si no hay panatallas guardadas retornamos
        if (_screns.Count <= 0)
            return;

        //Sacamos del stack la panatalla y la desactivamos
        _screns.Pop().Desactivate();
    }

    public void AddScreen(Screens screen)
    {

    }

    public void RemoveScreen(Screens screen)
    {

    }

}
