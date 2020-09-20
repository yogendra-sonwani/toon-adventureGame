﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPreFab;
    // Update is called once per frame
    void Update()
    {
        if(Player.skills == true)
        {   if(Input.GetButtonDown("Fire1")) {
                Shoot();
            }
        }
    }

    void Shoot ()
    {
        Instantiate(bulletPreFab, firePoint.position, firePoint.rotation);
    }
}
