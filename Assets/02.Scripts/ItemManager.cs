using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject itemPrefab;
    private List<Item> itemList;
    private Dictionary<int, Vector3> map = new Dictionary<int, Vector3>();


    private void Awake()
    {
        ItemInit();
        itemList = new List<Item>();
        foreach (Vector3 p in map.Values)
        {
            CreateItem(p);
        }
    }

    void ItemInit()
    {
        map.Add(0, new Vector3(-8.449154f, -0.1821596f, 0));
        map.Add(1, new Vector3(-2.58f, 2.25f, 0));
        map.Add(2, new Vector3(3.28f, -0.25f, 0));
        map.Add(3, new Vector3(7.36f, 2.89f, 0));
        map.Add(4, new Vector3(10.08f, 0.25f, 0));
        map.Add(5, new Vector3(14.8f, 1.89f, 0));
        map.Add(6, new Vector3(19.17f, 4.97f, 0));
        map.Add(7, new Vector3(23.75f, 0.39f, 0));
    }

    void CreateItem(Vector3 pos)
    {
        GameObject clone = Instantiate(itemPrefab) as GameObject;
        Item item = clone.GetComponent<Item>();
        item.Init(pos);
        itemList.Add(item);
    }
}


