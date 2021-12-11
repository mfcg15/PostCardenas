using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LaptopController : MonoBehaviour
{
    public static event Action<int> onConsoleChange;
    public static event Action<bool> onActivePanel;

    private bool isActivated = false;

    private void OnTriggerStay(Collider other)
    {

        if (Input.GetKeyDown(KeyCode.C) && !isActivated)
        {
            isActivated = true;
            onConsoleChange?.Invoke(1);
            onActivePanel?.Invoke(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isActivated)
        {
            isActivated = false;
            onConsoleChange?.Invoke(0);
            onActivePanel?.Invoke(true);
        }
    }
}
