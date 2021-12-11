using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasController : MonoBehaviour
{
    [SerializeField] private List<GameObject> cameras;

    void Start()
    {
        LaptopController.onConsoleChange += ChangeCamera;
    }

    private void ChangeCamera(int index)
    {
   
        for (int i = 0; i < cameras.Count; i++)
        {
            if (i == index)
            {
                cameras[i].SetActive(true);
            }
            else
            {
                cameras[i].SetActive(false);
            }

        }
    }
}
