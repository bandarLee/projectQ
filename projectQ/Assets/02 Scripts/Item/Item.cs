using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
   　public enum ItemType
    {
        FireItem,
        KnifeItem,

    }

    public ItemType IType;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.CompareTag("Player") && IType == ItemType.FireItem )
        {
            
        }
    }
}
