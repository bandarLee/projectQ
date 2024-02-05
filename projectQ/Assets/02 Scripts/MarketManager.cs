using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using TMPro;
public class MarketManager : MonoBehaviour
{
    public GameObject MarketMoneyInput;
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
        Debug.Log("InputMoneyClick called with: '" + inputText + "'");
        try
        {
            int moneyInput = int.Parse(inputText);
            GenerateItem(moneyInput);
            MarketMoneyInput.SetActive(false);
        }
        catch (System.FormatException e)
        {
            Debug.Log(e);
            MarketNoticeText.text = "가진 돈을 숫자로 입력하세요";
        }
    }



    public void GenerateItem(int money)
    {
  
        switch (money/10)
        {
            case 0:
                Debug.Log("10원입력");

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
