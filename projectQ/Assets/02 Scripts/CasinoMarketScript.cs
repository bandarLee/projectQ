using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CasinoMarketScript : MonoBehaviour
{
    public int RegendRate = 1;
    public int EpicRate = 10;
    public int RareRate = 23;
    public int NormalRate = 41;
    public int ItemSetInt;
    public int DecideItem;
    public static CasinoMarketScript Instance;
    public bool CasinoOn = false;
    public GameObject MarketImage;
  
    public enum ItemType
    {
        Default,
        Normal,
        Rare,     
        Epic,    
        Regend   
    }
    public ItemType itemtype = ItemType.Default;
    private float Movespeed = 2f; // 이동 속도 : 초당 3만큼 이동하겠다.
    public ItemSpawner itemspawner;

    public GameObject[] Images;
    private void Awake()
    {

        CasinoOn = true;


        foreach (GameObject image in Images)
        {

            image.SetActive(false);

        }
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void OnEnable()
    {
        int a = MarketManager.moneyInput * 3;
        EpicRate += a;
        RegendRate += a;
        RareRate += a;
        NormalRate += a;

        
        DecideItem = Random.Range(0, NormalRate + 1);
            
        if(DecideItem < RegendRate)
            {
            if (MarketManager.Instance != null)
            {
                ItemSpawner.Instance.SpawnRegendItem(MarketManager.Instance.transform.position);
            }
                itemtype = ItemType.Regend;

                itemspawner.SpawnItem(this.transform.position);


        }
        else if(DecideItem < EpicRate)
            {
            if (MarketManager.Instance != null)
            {
                ItemSpawner.Instance.SpawnEpicItem(MarketManager.Instance.transform.position);
            }
                itemtype = ItemType.Epic;
                itemspawner.SpawnItem(this.transform.position);


        }
        else if (DecideItem < RareRate)
        {
            if (MarketManager.Instance != null)
            {
                ItemSpawner.Instance.SpawnRareItem(MarketManager.Instance.transform.position);
            }
                itemtype = ItemType.Rare;
                itemspawner.SpawnItem(this.transform.position);


        }
        else if (DecideItem < NormalRate)
            {
            if (MarketManager.Instance != null)
            {
                ItemSpawner.Instance.SpawnNormalItem(MarketManager.Instance.transform.position);
            }
                itemtype = ItemType.Normal;
                itemspawner.SpawnItem(this.transform.position);


        }
    }

    void Update()
    {
        if (CasinoOn)
        {
 
            foreach (GameObject image in Images)
            {

                Vector3 dir = new Vector3(0, 250);
                Vector3 newPosition = (image.transform.position + (Vector3)(dir * Movespeed * Time.deltaTime));
                image.transform.position = newPosition;

            }
        }


        for (int i = 0; i < Images.Length; i++)
        {
            if (Images[i].transform.position.y > 529.11609)
            {
                Images[i].SetActive(true);
            }
            if (Images[i].transform.position.y > 900)
            {
                Images[i].SetActive(false);
            }

        }
        switch (itemtype)
            {
            case ItemType.Default:
              
                break;
            case ItemType.Normal:
                if (Images[10].transform.position.y > 900)
                {
                    CasinoOn = false;
                    StartCoroutine(ItemDelayCoroutine());

                }

                break;
            case ItemType.Rare:
                if (Images[16].transform.position.y > 900)
                {

                    CasinoOn = false;
                    StartCoroutine(ItemDelayCoroutine());

                }

                break;
            case ItemType.Epic:
                if (Images[11].transform.position.y > 900)
                {


                    CasinoOn = false;
                    StartCoroutine(ItemDelayCoroutine());

                }

                break;
            case ItemType.Regend:
                if (Images[15].transform.position.y > 900)
                {   
                    CasinoOn = false;
                    StartCoroutine(ItemDelayCoroutine());

                }

                break;

        }
        
    }
    IEnumerator ItemDelayCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        MarketImage.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
