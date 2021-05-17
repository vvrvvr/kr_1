using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int worldState = 0;
    [SerializeField] private List<ObjectState> buildings = new List<ObjectState>();
    [SerializeField] private GameObject[] environment;
    [SerializeField] private Material[] skyboxes;


    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            ChangeWorldState();
        }
    }
    private void ChangeWorldState()
    {
        worldState++;
        foreach(ObjectState obj in buildings)
        {
            if(obj != null)
                obj.NextState();
        }
        if(worldState < environment.Length)
        {
            environment[worldState].SetActive(true);
        }
        if (worldState < skyboxes.Length)
        {
            RenderSettings.skybox = skyboxes[worldState];
        }
    }
}
