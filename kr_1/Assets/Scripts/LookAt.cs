using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    void LateUpdate()
    {
        if(Camera.main != null)
            transform.LookAt(Camera.main.transform.position);   
    }
}
