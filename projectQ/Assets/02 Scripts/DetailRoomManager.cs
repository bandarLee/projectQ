using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailRoomManager : MonoBehaviour
{
    public Rect roomRect;


    void Start()
    {
        roomRect = Rect.MinMaxRect(this.transform.position.x - 7, this.transform.position.y - 3, this.transform.position.x + 7, this.transform.position.y + 3);

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
          
                if (!oneeye.gameObject.activeInHierarchy && roomRect.Contains(oneeye.gameObject.transform.position))
                        {
                            oneeye.gameObject.SetActive(true);
                        }

            }

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        OneEye[] oneeyes = RoomManager.Instance.oneeyes;
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (OneEye oneeye in oneeyes)
            {
                if (oneeye.gameObject.activeInHierarchy && !roomRect.Contains(oneeye.gameObject.transform.position))
                {
                    oneeye.gameObject.SetActive(false);
                }
            }
        }
    }
}
