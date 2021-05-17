using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal Other;
    public Camera PortalView;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookerPosition = Other.transform.worldToLocalMatrix.MultiplyPoint3x4(Camera.main.transform.position);
        PortalView.transform.localPosition = -lookerPosition;
    }
}
