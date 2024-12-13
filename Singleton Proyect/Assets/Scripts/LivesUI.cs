using UnityEngine.UI;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    private PlayerStats _stats;
    public Text livesText;

    private void Start()
    {
        _stats = GameManager.instance.PlayerStats;
    }

    void Update()
    {
        livesText.text = _stats.Lives + " Lives";
    }
}
