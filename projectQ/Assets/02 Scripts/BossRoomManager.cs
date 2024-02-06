using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossRoomManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject BossWallLeft;
    public GameObject BossWallRight;
    public GameObject BossWallTop;
    public GameObject BossWallBottom;
    private void Awake()
    {
        Instantiate(Player, this.gameObject.transform.position, Quaternion.identity);


    }

    void Start()
    {
     
    }

    void Update()
    {
    }
}
