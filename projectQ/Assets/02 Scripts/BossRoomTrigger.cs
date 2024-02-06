using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossRoomTrigger : MonoBehaviour
{

    public enum BossWallType
    {
        Default,
        Left,
        Right,
        Top,
        Bot
    }
    public BossWallType bosswalltype;
    void Awake()
    {

    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.gameObject.CompareTag("Player") && !Player.Instance.IsPlayerMove)
            {
                switch (bosswalltype)
                {
                    case BossWallType.Left:
                        BossCameraMove.Instance.LeftMove = true;

                        break;
                    case BossWallType.Right:
                        BossCameraMove.Instance.RightMove = true;

                        break;
                    case BossWallType.Top:
                        BossCameraMove.Instance.UpMove = true;

                        break;
                    case BossWallType.Bot:
                        BossCameraMove.Instance.DownMove = true;

                        break;
                    default:
                        Debug.Log("오류");
                        break;
                }
            }
        }
    }

}
