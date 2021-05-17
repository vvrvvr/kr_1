using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restrictions : MonoBehaviour
{
    [SerializeField] private float xMax;
    [SerializeField] private float xMin;
    [SerializeField] private float zMax;
    [SerializeField] private float zMin;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > xMax)
            transform.position = new Vector3(xMin, transform.position.y, transform.position.z);
        if (transform.position.x < xMin)
            transform.position = new Vector3(xMax, transform.position.y, transform.position.z);
        if (transform.position.z > zMax)
            transform.position = new Vector3(transform.position.x, transform.position.y, zMin);
        if (transform.position.z < zMin)
            transform.position = new Vector3(transform.position.x, transform.position.y, zMax);
    }
}
