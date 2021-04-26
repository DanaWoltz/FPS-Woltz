using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextText : MonoBehaviour
{
    public GameObject firstText;
    public GameObject secondText;

    void Start()
    {
        if(firstText == true)
        StartCoroutine(Test());
    }
  
    IEnumerator Test()
    {
        yield return new WaitForSeconds(8);
        firstText.SetActive(false);
        secondText.SetActive(true);
    }
}
