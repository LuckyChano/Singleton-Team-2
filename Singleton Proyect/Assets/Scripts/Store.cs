using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] StoreButton itemButton;
    [SerializeField] Transform parent;

    [SerializeField] ItemStore[] items = new ItemStore[0];

    private void Start()
    {
        for (int i = 0; i < items.Length; i++)
        {
            StoreButton newButton = Instantiate(itemButton, parent);
            newButton.SetButton(items[i]);
        }
    }
}
