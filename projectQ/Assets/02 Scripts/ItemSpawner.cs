using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject ItemPrefab_Health; // DropItem
    public GameObject ItemPrefab_Speed;
    public GameObject ItemPrefab_Money; // 상점에 꼭 필요
    public GameObject ItemPrefab_CardKey; // 다음 층으로 넘어갈 수 있는 카드키

    public void SpawnItem(Vector3 position)
    {
        int ItemPercent = Random.Range(0, 100);
        GameObject itemToSpawn;

        if (ItemPercent < 25)
        {
            itemToSpawn = ItemPrefab_CardKey;
        }
        else if (ItemPercent < 50)
        {
            itemToSpawn = ItemPrefab_Money;
        }
        else if (ItemPercent < 75)
        {
            itemToSpawn = ItemPrefab_Health;
        }
        else
        {
            itemToSpawn = ItemPrefab_Speed;
        }

        Instantiate(itemToSpawn, position, Quaternion.identity);
    }
}
