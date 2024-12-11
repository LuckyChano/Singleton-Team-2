using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyUI : MonoBehaviour
{
    private PlayerStats _stats;
    public Text moneyText;
 
    void Update()
    {
        moneyText.text = "$" + _stats.Money.ToString();
    }
}
