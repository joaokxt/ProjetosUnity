﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{ 
    void Update()
    {
        Destroy(this.gameObject, 2.5f);
    }
}
