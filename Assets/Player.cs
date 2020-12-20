﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public JoyStick joyStick;

    private void Awake()
    {
        joyStick.move = Move;
    }

    public void Move(Vector3 dir)
    {
        transform.forward = dir;
        transform.Translate(dir * 3 * Time.deltaTime, Space.World);
    }
}
