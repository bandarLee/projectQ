using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public OneEye[] oneeyes;
    void Awake()
    {
        OneEye[] oneeyes = GameObject.FindObjectsOfType<OneEye>();

        foreach (OneEye oneeye in oneeyes)
        {
            oneeye.gameObject.SetActive(false);
        }

    }


    void Update()
    {        

        foreach (OneEye oneeye in oneeyes)
        {
            if (!oneeye.gameObject.activeInHierarchy)
            {
                oneeye.gameObject.SetActive(true);
            }
        }
    }
}
