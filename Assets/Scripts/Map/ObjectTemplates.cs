﻿using UnityEngine;

// Stores all the possible objects that can be spawned
public class ObjectTemplates : MonoBehaviour
{
    // Tiles that can be placed in a room
    public GameObject[] roomTiles;

    // Objects that can be placed in a room
    public GameObject[] roomObjects;

    // Environment objects that can be placed in a room
    public GameObject[] environmentObjects;

    // PowerUp objects that can spawn in the room
    public GameObject[] powerUpObjects;

    public GameObject bossNDoor;
    public GameObject bossSDoor;
    public GameObject bossEWDoor;

}
