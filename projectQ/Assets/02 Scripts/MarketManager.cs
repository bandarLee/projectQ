using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using TMPro;
public class MarketManager : MonoBehaviour
{
    public GameObject MarketMoneyInput;
    public GameObject VendingMachine;
    public TextMeshProUGUI MarketNoticeText;
    public GameObject ErrorMessage;
    public GameObject Casino;
    public static MarketManager Instance;
    public GameObject BlackScreen1;
    public GameObject BlackScreen2;

    public bool IsPlayerMarket = false;
    public TextMeshProUGUI InputArea;
    public ItemSpawner itemspawner;
    public static int moneyInput;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        moneyInput = 0;
        MarketMoneyInput.SetActive(false);
        Casino.SetActive(false);
        BlackScreen1.SetActive(false); 
        BlackScreen2.SetActive(false);
    }

    void Update()
    {
        if (!IsPlayerMarket)
        {
            MarketMoneyInput.SetActive(false);
            BlackScreen1.SetActive(false);
            BlackScreen2.SetActive(false);

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") )
            {
            IsPlayerMarket = true;
            }
        if (IsPlayerMarket && Input.GetKey(KeyCode.E))
            {
            MarketMoneyInput.SetActive(true);
            BlackScreen1.SetActive(true);
            BlackScreen2.SetActive(true);
            ErrorMessage.SetActive(false);


        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            IsPlayerMarket = false;
        }
 
    }
    public void InputMoneyClick()
    {
        string inputText = InputArea.text.Trim();
        inputText = inputText.Replace("\u200B", "");
        try
        {
              moneyInput = int.Parse(inputText);
            if(moneyInput > Player.Instance.CoinCount)
                {

                    MarketNoticeText.text = "가진 돈보다 많이 입력하셨습니다";
                    MarketMoneyInput.SetActive(false);
                    BlackScreen1.SetActive(false);
                    BlackScreen2.SetActive(false);
                    ErrorMessage.SetActive(true);

                    InputArea.text = null;

                

                }
            else if(moneyInput <= Player.Instance.CoinCount && moneyInput >=0 )
            {
                BlackScreen1.SetActive(false);
                BlackScreen2.SetActive(false);
                Casino.SetActive(true);

                Destroy(VendingMachine);
            }

        }
        catch (System.FormatException e)
        {
            ErrorMessage.SetActive(true);

            Debug.Log(e);
            MarketNoticeText.text = "에러발생";
        }
    }



   


}
