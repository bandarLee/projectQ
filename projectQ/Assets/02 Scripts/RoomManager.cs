using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    void Start()
    {
        OneEye oneeye = GameObject.FindObjectOfType<OneEye>();

        oneeye.gameObject.SetActive(false);

    }


    void Update()
    {
        OneEye oneeye = GameObject.FindObjectOfType<OneEye>();

        if (oneeye != null && !oneeye.gameObject.activeInHierarchy)
        {
            oneeye.gameObject.SetActive(true);
        }
    }
}
