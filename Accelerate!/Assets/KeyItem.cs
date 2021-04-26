using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    public int keyCount = 0;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            keyCount += 1;
            Destroy(gameObject);
        }
    }


}
