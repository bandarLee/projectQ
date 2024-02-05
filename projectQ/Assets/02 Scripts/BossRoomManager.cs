using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
