using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private float moveVertical, rotation = 70f;
    private int money = 0;
    [SerializeField] private float speedPlayer;

    public static event Action<int> onCoinsChange;
    public static event Action<bool> onTaskMoney , onTaskKey;

    void Start()
    {
        anim = GetComponent<Animator>();
        onCoinsChange?.Invoke(money);
    }

    void FixedUpdate()
    {
        Move();
        Rotation();
    }

    private void Move()
    {
 
        moveVertical = Input.GetAxis("Vertical");
        transform.Translate(0, 0, moveVertical * Time.deltaTime * speedPlayer);
        anim.SetFloat("SpeedY", moveVertical);
    }

    private void Rotation()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0.0f, Time.deltaTime * -(rotation), 0.0f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0.0f, Time.deltaTime * rotation, 0.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Money"))
        {
            money++;
            onCoinsChange?.Invoke(money);
            Destroy(other.gameObject);

            if(money==40)
            {
                onTaskMoney?.Invoke(true);
            }

        }

        if (other.CompareTag("Key"))
        {
            onTaskKey?.Invoke(true);
            Destroy(other.gameObject);
        }
    }
}
