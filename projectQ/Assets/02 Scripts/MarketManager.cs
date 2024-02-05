using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using TMPro;
public class MarketManager : MonoBehaviour
{
    public GameObject MarketMoneyInput;
    public GameObject VendingMachine;
    public TextMeshProUGUI MarketNoticeText;

    public bool IsPlayerMarket = false;
    public TextMeshProUGUI InputArea;


    void Awake()
    {
        MarketMoneyInput.SetActive(false);
    }

    void Update()
    {
        if (!IsPlayerMarket)
        {
            MarketMoneyInput.SetActive(false);

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
            int moneyInput = int.Parse(inputText);
            if(moneyInput > Player.Instance.CoinCount)
                {

                    MarketNoticeText.text = "가진 돈보다 많이 입력하셨습니다";
                    MarketMoneyInput.SetActive(false);

                    InputArea.text = null;

                

                }
            else if(moneyInput <= Player.Instance.CoinCount && moneyInput >=0 )
            {
                GenerateItem(moneyInput);
                MarketMoneyInput.SetActive(false);
                Destroy(VendingMachine);
            }

        }
        catch (System.FormatException e)
        {
            Debug.Log(e);
            MarketNoticeText.text = "에러발생";
        }
    }



    public void GenerateItem(int money)
    {
  
        switch (money/3)
        {
            case 0:
                GameObject item_CardKey = Instantiate(ItemPrefab_CardKey);
                item_CardKey.transform.position = this.transform.position;

                break;
            case 1:
                Debug.Log("10원입력");

                break;
            case 2: break;
            case 3: break;
            case 4: break;
            case 5: break;
            case 6: break;

        }
    }


}
