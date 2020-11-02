﻿using UnityEngine;

// Quits game upon ESC press
public class QuitGame : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
