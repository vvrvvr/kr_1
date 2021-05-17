using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class GameManager : MonoBehaviour
{
    private int worldState = 0;
    private int noteNumber = 0;
    [SerializeField] private List<ObjectState> buildings = new List<ObjectState>();
    [SerializeField] private GameObject[] environment;
    [SerializeField] private Material[] skyboxes;
    [Header("       notes")]
    [SerializeField] GameObject noteObject;
    [SerializeField] private string[] notes = new string[6];
    [SerializeField] private Image note;
    [SerializeField] private Text noteText;
    [SerializeField] private FirstPersonAIO player;

    private bool isNoteShowing;

    void Start()
    {
        //note.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        notes[0] = "1";
        notes[1] = "2";
        notes[2] = "3";
        notes[3] = "4";
        notes[4] = "5";
        notes[5] = "6";

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ChangeWorldState();
        }
        if(isNoteShowing)
        {
            if(Input.GetMouseButtonDown(0))
            {
                isNoteShowing = false;
                HideNote();
            }
        }
    }
    public void ChangeWorldState()
    {
        worldState++;
        foreach (ObjectState obj in buildings)
        {
            if (obj != null)
                obj.NextState();
        }
        if (worldState < environment.Length)
        {
            environment[worldState].SetActive(true);
        }
        if (worldState < skyboxes.Length)
        {
            RenderSettings.skybox = skyboxes[worldState];
        }
    }
    public void ShowNote()
    {
        player.ControllerPause();
        noteObject.SetActive(true);
        if (noteNumber < notes.Length)
        {
            noteText.text = notes[worldState];
            noteNumber++;
        }
        note.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        note.transform.DOScale(Vector3.one, 0.5f).OnComplete(() => isNoteShowing = true);
    }
    public void HideNote()
    {
        note.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.5f).OnComplete(() => noteObject.SetActive(false));
        isNoteShowing = false;
        player.ControllerPause();
    }
}
