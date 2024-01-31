using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public string roomName; // 방의 이름
    public Vector3 roomPosition; // 방의 위치
    void Start()
    {
        roomPosition = this.transform.position;
    }

    void Update()
    {
        
    }
}
