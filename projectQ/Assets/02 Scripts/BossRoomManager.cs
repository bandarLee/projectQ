using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomManager : MonoBehaviour
{
    public GameObject Player;

    void Start()
    {
        Instantiate(Player, this.gameObject.transform.position, Quaternion.identity);

    }

    void Update()
    {
        
    }
}
