using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RabbitController : MonoBehaviour
{
    private Animator anim;
    private int currentIndex = 0;
    private bool goBack = false, stop = false, key = false;
    private float speed = 0.4f, rotationSpeed = 10, minimumDistance = 1;

    [SerializeField] Transform[] waypoints;
    
    public static event Action<bool> onTaskRabbit;

    void Start()
    {
        anim = GetComponent<Animator>();
        PlayerController.onTaskKey += onVerifyKey;
    }

    void Update()
    {
        if(stop)
        {
            anim.SetFloat("SpeedY", 0f);
        }
        else
        {
            Movement();
        }
    }

    private void Movement()
    {
        Vector3 deltaVector = waypoints[currentIndex].position - transform.position;
        Vector3 direction = deltaVector.normalized;

        transform.forward = Vector3.Lerp(transform.forward, direction, rotationSpeed * Time.deltaTime);

        transform.position += transform.forward * speed * Time.deltaTime;
        anim.SetFloat("SpeedY", 1f);

        float distance = deltaVector.magnitude;

        if (distance < minimumDistance)
        {
            if (currentIndex >= waypoints.Length - 1)
            {
                goBack = true;
            }
            else if (currentIndex <= 0)
            {
                goBack = false;
            }

            if (!goBack)
            {
                currentIndex++;
            }
            else currentIndex--;
        }
    }


    public void onVerifyKey(bool verify)
    {
        key = verify;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")&& key == true)
        {
            stop = true;
            onTaskRabbit?.Invoke(true);
        }
    }
}
