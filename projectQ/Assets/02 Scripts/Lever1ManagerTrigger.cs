using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lever1ManagerTrigger : MonoBehaviour
{
    public enum DoorType
        {
        Default,
        Left,
        Right,
        Top,
        Bot
        }
    public DoorType doortype;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enter");
            switch(doortype)
            {
                case DoorType.Left:
                    CameraMove.Instance.LeftMove = true;
                    PlayerMove.Instance.moveDirection = DoorType.Left;

                    break;
                case DoorType.Right:
                    CameraMove.Instance.RightMove = true;
                    PlayerMove.Instance.moveDirection = DoorType.Right;

                    break;
                case DoorType.Top:
                    CameraMove.Instance.UpMove = true;
                    PlayerMove.Instance.moveDirection = DoorType.Top;

                    break;
                case DoorType.Bot:
                    CameraMove.Instance.DownMove = true;
                    PlayerMove.Instance.moveDirection = DoorType.Bot;

                    break;
                default:
                    Debug.Log("오류");
                    break;
            }
        }
    }
}
