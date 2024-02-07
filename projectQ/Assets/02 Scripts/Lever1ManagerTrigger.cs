using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lever1ManagerTrigger : MonoBehaviour
{
    public enum DoorType
        {
        Default,
        Left,
        Right,
        Top,
        Bot,
        Boss
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
        if (collision.gameObject.CompareTag("Player") && !Player.Instance.IsPlayerMove)
        {
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
                case DoorType.Boss:
                    if (Player.Instance.HasPlayerCard)
                    {
                        SceneManager.LoadScene("BossRoom");
                    }
                    else if (!Player.Instance.HasPlayerCard)
                    {
                        UIManager.Instance.CardKeyScreen.SetActive(true);
                        StartCoroutine(CardDelayCoroutine());

                    }

                    break;
                default:
                    Debug.Log("오류");
                    break;
            }
        }
    }
    IEnumerator CardDelayCoroutine()
    {
        yield return new WaitForSeconds(1f);
        UIManager.Instance.CardKeyScreen.SetActive(false);
    }
}
