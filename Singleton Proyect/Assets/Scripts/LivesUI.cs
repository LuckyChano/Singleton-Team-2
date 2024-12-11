using UnityEngine.UI;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    private PlayerStats _stats;
    public Text livesText;

    void Update()
    {
        livesText.text = _stats.Lives + " Lives";
    }
}
