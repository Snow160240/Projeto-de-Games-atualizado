using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject toolbarpanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            panel.SetActive(!panel.activeInHierarchy);
            toolbarpanel.SetActive(!toolbarpanel.activeInHierarchy);
        }
    }
}
