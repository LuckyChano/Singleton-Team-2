using UnityEngine.UI;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    //PARA MOBILE HACERLO EN UNA CORRUTINA O LINKEARLO A LOS STATS DEL PLAYER DE ALGUNA MANERA.

    public Text livesText;
    void Update()
    {
        livesText.text = PlayerStats.Lives + " Lives";
    }
}
