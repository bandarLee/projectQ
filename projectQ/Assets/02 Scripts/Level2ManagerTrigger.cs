using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2ManagerTrigger : MonoBehaviour
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
            switch (doortype)
            {
               
                case DoorType.Boss:
                    if (Player.Instance.HasPlayerCard)
                    {
                        SceneManager.LoadScene("BossScene2");
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
