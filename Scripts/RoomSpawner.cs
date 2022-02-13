using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    private RoomTemplates templates;
    private int rand;
    public bool spawned = false;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 5f);
    }

    void Spawn()
    {
        if(spawned == false)
        {
            rand = Random.Range(0, templates.Rooms.Length);
            Instantiate(templates.Rooms[rand], transform.position, templates.Rooms[rand].transform.rotation);
            spawned = true;
        }
    }
}
