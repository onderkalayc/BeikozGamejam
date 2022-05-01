using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(AddApple());
        }
    }

    IEnumerator AddApple()
    {
        yield return new WaitForSeconds(7.0f);
       
    }
}
