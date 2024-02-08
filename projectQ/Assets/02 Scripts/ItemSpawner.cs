using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemSpawner : MonoBehaviour
{
    public GameObject ItemPrefab_Health; // DropItem
    public GameObject ItemPrefab_Fire;
    public GameObject ItemPrefab_Blood;
        
    public GameObject ItemPrefab_Knife;
    public GameObject ItemPrefab_Laser;
    public GameObject ItemPrefab_Boom;
    public GameObject ItemPrefab_BulletUp;

    public GameObject ItemPrefab_Money; // 상점에 꼭 필요
    public GameObject ItemPrefab_CardKey; // 다음 층으로 넘어갈 수 있는 카드키
    public static ItemSpawner Instance;

    private void Awake()
    {
        // 싱글톤 패턴 : 오직 한개의 클래스 인스턴스를 갖도록 보장
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void SpawnItem(Vector3 position)
    {
        int ItemPercent = Random.Range(0, 100);
        if (ItemPercent < 45)
        {
            SpawnNormalItem(position);
        }
        else if (ItemPercent < 70)
        {
            SpawnRareItem(position);
        }
        else if (ItemPercent < 85)
        {
            SpawnEpicItem(position);
        }
        else
        {
            SpawnRegendItem(position);
        }

    }

    public void SpawnNormalItem(Vector3 position)
    {
        int ItemPercentNormal = Random.Range(0, 100);
        GameObject itemToSpawn;

        if (ItemPercentNormal < 25)
        {
            itemToSpawn = ItemPrefab_Money;
        }
        else if (ItemPercentNormal < 50)
        {
            itemToSpawn = ItemPrefab_Money;
        }
        else if (ItemPercentNormal < 75)
        {
            itemToSpawn = ItemPrefab_Boom;
        }
        else
        {
            itemToSpawn = ItemPrefab_Health;
        }

        Instantiate(itemToSpawn, position, Quaternion.identity);
    }
    public void SpawnRareItem(Vector3 position)
    {
        int ItemPercentRare = Random.Range(0, 100);
        GameObject itemToSpawn;

        if (ItemPercentRare < 20)
        {
            itemToSpawn = ItemPrefab_BulletUp;
        }
        else if (ItemPercentRare < 40)
        {
            itemToSpawn = ItemPrefab_Knife;
        }
        else if (ItemPercentRare < 60)
        {
            itemToSpawn = ItemPrefab_Blood;
        }
        else if (ItemPercentRare < 80)
        {
            itemToSpawn = ItemPrefab_Blood;
        }
        else
        {
            itemToSpawn = ItemPrefab_Knife;
        }

        Instantiate(itemToSpawn, position, Quaternion.identity);
    }
    public void SpawnEpicItem(Vector3 position)
    {
        int ItemPercentEpic = Random.Range(0, 100);

        GameObject itemToSpawn;

        if (ItemPercentEpic < 25)
        {
            itemToSpawn = ItemPrefab_Fire;
        }
        else if (ItemPercentEpic < 50)
        {
            itemToSpawn = ItemPrefab_Fire;
        }
        else if (ItemPercentEpic < 75)
        {
            itemToSpawn = ItemPrefab_CardKey;
        }
        else
        {
            itemToSpawn = ItemPrefab_CardKey;
        }

        Instantiate(itemToSpawn, position, Quaternion.identity);
    }
    public void SpawnRegendItem(Vector3 position)
    {
        int ItemPercentRegend = Random.Range(0, 100);
        GameObject itemToSpawn;

        if (ItemPercentRegend < 60)
        {
            itemToSpawn = ItemPrefab_CardKey;
        }
      
     
        else
        {
            itemToSpawn = ItemPrefab_Laser;


        }

        Instantiate(itemToSpawn, position, Quaternion.identity);
    }
}
