﻿using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[RequireComponent(typeof(Destroyable))]
public class Health : MonoBehaviour
{
    public float maxHealth = 1;

    private float curHealth;

    private Destroyable destroyable;
    // Start is called before the first frame update
    void Start()
    {
        destroyable = this.GetComponent<Destroyable>();
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (curHealth <= 0)
        {
            destroyable.Destroy();
        }
    }

    public void TakeDamage(float damage)
    {
        curHealth -= damage;
    }
}