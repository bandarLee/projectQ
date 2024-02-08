using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePlayer : MonoBehaviour
{
    public GameObject Player;
    void Awake()
    {
        Instantiate(Player, this.gameObject.transform.position, Quaternion.identity);

    }

    void Update()
    {
        
    }
}
