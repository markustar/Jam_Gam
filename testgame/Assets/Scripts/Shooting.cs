﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public static Shooting Instance { get; private set; }
    public AudioSource PewPlayer;
    public AudioClip Pew;
    public Rigidbody projectile;
    public float speed = 20;
    public bool AbleToShoot;

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
        AbleToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && AbleToShoot == true)
        {
            AudioManager.PlayAudio("Pew");
            Rigidbody instantiatedProjectile = Instantiate(projectile,
                                                           transform.position,
                                                           transform.rotation)
                as Rigidbody;

            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        }
    }

    // OnCollisionEnter is called when the projectile collides with another object

   

}
