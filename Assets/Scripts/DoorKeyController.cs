using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyController : MonoBehaviour
{
    [SerializeField] float angleOpen;
    [SerializeField] float angleClose;
    bool openDoor, key;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        PlayerController.onTaskKey += onVerifyKey;
    }

    void Update()
    {
        if (openDoor && key)
        {
            Quaternion rotation = Quaternion.Euler(0, angleOpen, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, rotation, 10f * Time.deltaTime);

            if ((Vector3.Distance(player.transform.position, transform.position) > 3f))
            {
                openDoor = false;
            }
        }
        else
        {
            Quaternion rotation = Quaternion.Euler(0, angleClose, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, rotation, 10f * Time.deltaTime);
        }

    }

    public void SystemDoor(bool status)
    {
        openDoor = status;
    }

    public void onVerifyKey(bool verify)
    {
        key = verify;
    }
}
