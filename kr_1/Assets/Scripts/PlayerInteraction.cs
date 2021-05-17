using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private GameObject raycastedObj;
    [SerializeField] private int rayLength = 10;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private Sprite crosshair;
    [SerializeField] private Sprite hand;
    [SerializeField] private Transform camTransform;
    private FirstPersonAIO player;
    //[SerializeField] private Sprite eye;

    private void Start()
    {
        player = GetComponent<FirstPersonAIO>();
    }


    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = camTransform.TransformDirection(Vector3.forward);

        if(Physics.Raycast(camTransform.position, fwd, out hit, rayLength, layerMaskInteract.value))
        {
            Debug.Log("interactable");
            if(hit.collider.CompareTag("flower"))
            {
                raycastedObj = hit.collider.gameObject;
                player.Crosshair = hand;
                Debug.Log("flower hit");
            }
        }
        else
        {
            player.Crosshair = crosshair;
        }


    }
}
