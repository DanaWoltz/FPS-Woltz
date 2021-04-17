using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlatformControlller : MonoBehaviour
{
    public bool horizontalCheck;
    public bool isAtTarget;

    public Transform posTarget;
    public Transform negTarget;

    public float speed;
    public float delta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
        
    }

    void MovePlatform()
    {
        if (horizontalCheck)
        {
            if (!isAtTarget)
            {
                transform.position = Vector3.MoveTowards(transform.position, posTarget.position, speed * Time.deltaTime);
                if (transform.position.x >= posTarget.position.x)
                {
                    isAtTarget = true;
                }
            }

            if (isAtTarget)
            {
                transform.position = Vector3.MoveTowards(transform.position, negTarget.position, speed * Time.deltaTime);
                if (transform.position.x <= negTarget.position.x)
                {
                    isAtTarget = false;
                }
            }
        }

        else if (!horizontalCheck)
        {
            if (!isAtTarget)
            {
                transform.position = Vector3.MoveTowards(transform.position, posTarget.position, speed * Time.deltaTime);
                if (transform.position.y >= posTarget.position.y)
                {
                    isAtTarget = true;
                }
            }

            if (isAtTarget)
            {
                transform.position = Vector3.MoveTowards(transform.position, negTarget.position, speed * Time.deltaTime);
                if (transform.position.y <= negTarget.position.y)
                {
                    isAtTarget = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fast Bullet")
        {
            speed *= 2;
        }
        else if (other.gameObject.tag == "Slow Bullet")
        {
            speed /= 2;
        }
    }
}
