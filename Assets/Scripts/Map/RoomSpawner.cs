﻿using UnityEngine;

// Spawns a room on a Spawn Point
public class RoomSpawner : MonoBehaviour
{
    // 1 means need bottom door is needed
    // 2 means need left door is needed
    // 3 means need top door is needed
    // 4 means need right door is needed
    public int openingDirection;

    // Variable that stores all the possible rooms that can be spawned
    private RoomTemplates templates;
    // Variable to store a random integer
    private int rand;
    // Variable that remembers whether this spawn point has already spawned an object or not
    private bool spawned = false;

    public float waitTime = 4f;

    public int map_size_limit = 7;

    void Start()
    {
        // Declutter spawnPoints
        Destroy(gameObject, waitTime);
        // templates contains all the different types of rooms that can be spawned
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        // Calls Spawn() every 0.1 seconds
        Invoke("Spawn", 0.1f);
    }


    // Spawns a room on a Spawn Point based on which door requirement is needed
    void Spawn()
    {
        if (spawned == false) {
            // If we need a bottom door
            if (openingDirection == 1)
            {
                if (!templates.bossRoomSpawned && templates.bossRoomSpawnPlace == 1)
                {
                    rand = Random.Range(0, templates.bossRoomsBottom.Length);
                    Instantiate(templates.bossRoomsBottom[rand], transform.position, templates.bossRoomsBottom[rand].transform.rotation);
                    templates.bossRoomSpawned = true;
                    templates.bottomRoomCount += 2;
                }
                else
                {
                    if (templates.bottomRoomCount <= map_size_limit)
                    {
                        rand = Random.Range(0, templates.bottomRooms.Length);
                        Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                        templates.bottomRoomCount++;
                    }
                    else
                    {
                        Instantiate(templates.bottomClosed, transform.position, templates.bottomClosed.transform.rotation);
                    }
                }
            }
            // If we need a left door
            else if (openingDirection == 2)
            {
                if (!templates.bossRoomSpawned && templates.bossRoomSpawnPlace == 2)
                {
                    rand = Random.Range(0, templates.bossRoomsLeft.Length);
                    Instantiate(templates.bossRoomsLeft[rand], transform.position, templates.bossRoomsLeft[rand].transform.rotation);
                    templates.bossRoomSpawned = true;
                    templates.leftRoomCount += 2;
                }
                else
                {
                    if (templates.leftRoomCount <= map_size_limit)
                    {
                        rand = Random.Range(0, templates.leftRooms.Length);
                        Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                        templates.leftRoomCount++;
                    }
                    else
                    {
                        Instantiate(templates.leftClosed, transform.position, templates.leftClosed.transform.rotation);
                    }
                }
            }
            // If we need a top door
            else if (openingDirection == 3)
            {
                if (!templates.bossRoomSpawned && templates.bossRoomSpawnPlace == 3)
                {
                    rand = Random.Range(0, templates.bossRoomsTop.Length);
                    Instantiate(templates.bossRoomsTop[rand], transform.position, templates.bossRoomsTop[rand].transform.rotation);
                    templates.bossRoomSpawned = true;
                    templates.topRoomCount += 2;
                }
                else
                {
                    if (templates.topRoomCount <= map_size_limit)
                    {
                        rand = Random.Range(0, templates.topRooms.Length);
                        Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                        templates.topRoomCount++;
                    }
                    else
                    {
                        Instantiate(templates.topClosed, transform.position, templates.topClosed.transform.rotation);
                    }
                }
            }
            // If we need a right door
            else if (openingDirection == 4)
            {
                if (!templates.bossRoomSpawned && templates.bossRoomSpawnPlace == 4)
                {
                    rand = Random.Range(0, templates.bossRoomsRight.Length);
                    Instantiate(templates.bossRoomsRight[rand], transform.position, templates.bossRoomsRight[rand].transform.rotation);
                    templates.bossRoomSpawned = true;
                    templates.rightRoomCount += 2;
                }
                else
                {
                    if (templates.rightRoomCount <= map_size_limit)
                    {
                        rand = Random.Range(0, templates.rightRooms.Length);
                        Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                        templates.rightRoomCount++;
                    }
                    else
                    {
                        Instantiate(templates.rightClosed, transform.position, templates.rightClosed.transform.rotation);
                    }
                }
            }
            // Something has been spawned, remember that
            spawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Close off any paths that lead to nowhere with a closed room
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        if (other.CompareTag("SpawnPoint"))
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && !spawned)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
