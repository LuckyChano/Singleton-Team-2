using TMPro;
using UnityEngine;

public class WaveUIManager : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI waveCounterText;

    // Actualiza el temporizador con un número flotante
    public void UpdateTimer(float countdown)
    {
        timerText.text = $"Next Wave: {Mathf.Ceil(countdown)}s";
    }

    // Actualiza el temporizador con un mensaje de texto
    public void UpdateTimer(string message)
    {
        timerText.text = message;
    }

    public void UpdateWaveCounter(int waveNumber)
    {
        waveCounterText.text = $"Wave: {waveNumber}";
    }
}