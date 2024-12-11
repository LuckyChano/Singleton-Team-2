using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    private Dictionary<ScreensType, IScreen> _screens = new Dictionary<ScreensType, IScreen>();

    public void RegisterScreen(ScreensType type, IScreen screen)
    {
        if (!_screens.ContainsKey(type))
        {
            _screens[type] = screen;
        }
    }

    public void ShowScreen(ScreensType type)
    {
        foreach (var screen in _screens.Values)
        {
            screen.Hide();
        }

        if (_screens.ContainsKey(type))
        {
            _screens[type].Show();
        }
    }
}
