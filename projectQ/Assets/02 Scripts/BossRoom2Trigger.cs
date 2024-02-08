using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossRoom2Trigger : MonoBehaviour
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
                        BossCamera2Move.Instance.LeftMove = true;

                        break;
                    case BossWallType.Right:
                        BossCamera2Move.Instance.RightMove = true;

                        break;
                    case BossWallType.Top:
                        BossCamera2Move.Instance.UpMove = true;

                        break;
                    case BossWallType.Bot:
                        BossCamera2Move.Instance.DownMove = true;

                        break;
                    default:
                        Debug.Log("오류");
                        break;
                }
            }
        }
    }

}
