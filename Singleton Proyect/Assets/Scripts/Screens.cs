using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScreensType
{
    mainMenuScreen,
    staminaScreen,
    storeScreen,
    optionsScreen,
    gameOverScreen,
    winScreen

}

public abstract class Screens : MonoBehaviour, IScreen
{
    public abstract void Activate();

    public abstract void Desactivate();
}
