﻿using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed = 10f;
    private float velocity = 0;
    public float Velocity => velocity;
    public float boostMult = 1.2f;
    public float boostDrain = 5;
    public GunController gunController;

    public bool go = false;

    public GameObject targetObject = null;
    public Animator boostAnimator;
    public CinemachineImpulseSource engineImpulse;

    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            velocity = speed; //TODO: smooth ramp up/ ramp down

            if (Input.GetAxis("Boost") > 0)
            {
                gunController.AddEnergy(-1 * boostDrain * Time.deltaTime);
                velocity *= boostMult;
                boostAnimator.SetBool("isBoosting", true);
                if (engineImpulse != null)
                {
                    engineImpulse.GenerateImpulse();
                }
            }
            else
            {
                boostAnimator.SetBool("isBoosting", false);
            }

            this.transform.position += Time.deltaTime * velocity * this.transform.forward;
        }
        
        this.transform.LookAt(targetObject.transform);
    }
}
