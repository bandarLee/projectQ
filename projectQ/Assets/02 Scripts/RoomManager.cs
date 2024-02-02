using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager Instance;

    public OneEye[] oneeyes;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        oneeyes = GameObject.FindObjectsOfType<OneEye>();

        foreach (OneEye oneeye in oneeyes)
        {
            oneeye.gameObject.SetActive(false);
        }

    }


    void Update()
    {        

      
    }
}
