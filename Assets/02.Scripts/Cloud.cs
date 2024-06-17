using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public void Init(Vector3 pos)
    {
        SetPos(pos);
    }
    public void SetPos(Vector3 pos)
    {
        transform.position = pos;
    }

    public Vector3 GetPos()
    {
        return transform.position;
    }
}
