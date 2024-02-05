using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceItem : MonoBehaviour
{
    public GameObject ItemPrefab_Health; // DropItem
    public GameObject ItemPrefab_Speed;
    public GameObject ItemPrefab_Money; // 상점에 꼭 필요
    public GameObject ItemPrefab_CardKey; // 다음 층으로 넘어갈 수 있는 카드키
    private static int Item; // 정적 변수

    public PlaceItem(string name)
    {
        //Name = name;

        // 클래스가 공유하는 정적 변수의 값을 수정한다. 
        //Name++;
    }

    public void MakeItem()
    {
        int ItemPercent = Random.Range(0, 100);
        // 목표: 25% 확률로 다음 층으로 넘어갈 수 있는 카드키, 머니, 체력, 스피드 아이템(확률넣기)
        if (ItemPercent < 25)
        {
            // -다음 층으로 넘어갈 수 있는 카드키 만들고
            GameObject item_CardKey = Instantiate(ItemPrefab_CardKey);
            // -위치를 나의 위치로 수정
            item_CardKey.transform.position = transform.position;
        }
        else if (ItemPercent < 50)
        {
            // -머니주는 아이템 만들고
            GameObject item_Money = Instantiate(ItemPrefab_Money);
            // -위치를 나의 위치로 수정
            item_Money.transform.position = transform.position;
        }
        else if (ItemPercent < 75)
        {
            // -체력 아이템 만들고
            GameObject item_Health = Instantiate(ItemPrefab_Health);
            // -위치를 나의 위치로 수정
            item_Health.transform.position = transform.position;
        }
        else
        {
            // -스피드 아이템 만들고
            GameObject item_Speed = Instantiate(ItemPrefab_Speed);
            // -위치를 나의 위치로 수정
            item_Speed.transform.position = transform.position;
        }

        //return Item;
    }
    public void GetMakeItem()
    {

        MakeItem();
    }
}
