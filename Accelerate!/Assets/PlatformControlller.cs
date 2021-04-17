using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControlller : MonoBehaviour
{
    public bool horizontalCheck;
    public bool isAtTarget;

    public Transform posXTarget;
    public Transform negXTarget;

    public Transform posYTarget;
    public Transform negYTarget;

    public float speed;

    private float boolRandomizer;


    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(4, 20);
        boolRandomizer = Random.value;

        if(boolRandomizer >= 0.5f)
        {
            horizontalCheck = true;
        }
        else if (boolRandomizer <= 0.5f)
        {
            horizontalCheck = false;
        }
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
                transform.position = Vector3.MoveTowards(transform.position, posXTarget.position, speed * Time.deltaTime);
                if (transform.position.x >= posXTarget.position.x)
                {
                    isAtTarget = true;
                }
            }

            if (isAtTarget)
            {
                transform.position = Vector3.MoveTowards(transform.position, negXTarget.position, speed * Time.deltaTime);
                if (transform.position.x <= negXTarget.position.x)
                {
                    isAtTarget = false;
                }
            }
        }

        else if (!horizontalCheck)
        {
            if (!isAtTarget)
            {
                transform.position = Vector3.MoveTowards(transform.position, posYTarget.position, speed * Time.deltaTime);
                if (transform.position.y >= posYTarget.position.y)
                {
                    isAtTarget = true;
                }
            }

            if (isAtTarget)
            {
                transform.position = Vector3.MoveTowards(transform.position, negYTarget.position, speed * Time.deltaTime);
                if (transform.position.y <= negYTarget.position.y)
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
