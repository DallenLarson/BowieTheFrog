using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBound : MonoBehaviour
{
    public GameObject TopBound;
    void OnTriggerEnter2D(Collider2D col)
    {
        col.transform.position = new Vector3(col.transform.position.x, TopBound.transform.position.y, col.transform.position.z);
    }
}
