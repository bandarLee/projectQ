using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailRoomManager : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        OneEye[] oneeyes = RoomManager.Instance.oneeyes;
        if (other.gameObject.CompareTag("Player")) 
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
}
