using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    public GameObject cloudPrefab;
    private List<Cloud> cloudList;
    private Dictionary<int, Vector3> map = new Dictionary<int, Vector3>();


    private void Awake()
    {
        MapInit();
        cloudList = new List<Cloud>();
        foreach(Vector3 p in map.Values)
        {
            CreateMap(p);
        }
    }

    void MapInit()
    {
        map.Add(0, new Vector3(-2.627628f, 1.106791f, 0));
        map.Add(1, new Vector3(3.252372f, -1.323209f, 0));
        map.Add(2, new Vector3(-8.427628f, -1.393209f, 0));
        map.Add(3, new Vector3(9.902372f, -0.97f, 0));
        map.Add(4, new Vector3(7.392372f, 1.746791f, 0));
        map.Add(5, new Vector3(14.83237f, 0.606791f, 0));
        map.Add(6, new Vector3(19.19237f, 3.756791f, 0));
        map.Add(7, new Vector3(23.77237f, -0.893209f, 0));
    }

    void CreateMap(Vector3 pos)
    {
        GameObject clone = Instantiate(cloudPrefab) as GameObject;
        Cloud cloud = clone.GetComponent<Cloud>();
        cloud.Init(pos);
        cloudList.Add(cloud);
    }
}


