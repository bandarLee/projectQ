using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketManager : MonoBehaviour
{
    public bool IsPlayerMarket = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (IsPlayerMarket)
        {

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") )
            {
            IsPlayerMarket = true;
            }
        if (IsPlayerMarket && Input.GetKey(KeyCode.E))
            {
                Debug.Log("상점쓰기");
            }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            IsPlayerMarket = false;
        }
 
    }

}
