﻿using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Destroyable))]
public class Health : MonoBehaviour
{
    public int maxHealth = 1;
    public float shieldRestoreTime = 0f;
    
    public AudioClip hitSound;
    public AudioSource source;
    
    public UnityEvent onZeroHp = new UnityEvent();

    private int curHealth;
    public int CurrentHealth => curHealth;
    private bool dying = false;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        source.clip = hitSound;
    }

    // Update is called once per frame
    void Update()
    {
        if (curHealth <= 0 && !dying)
        {
            onZeroHp.Invoke();
            dying = true;
        }
    }

    public void TakeDamage()
    {
        source.Play();
        curHealth -= 1;
        StopAllCoroutines();
        
        if (curHealth > 0 && shieldRestoreTime > 0)
        {
            StartCoroutine(restoreHpAfterDelay());
        }

        var impulse = this.GetComponent<CinemachineImpulseSource>();
        if (impulse != null)
        {
            impulse.GenerateImpulse();
        }
    }

    private IEnumerator restoreHpAfterDelay()
    {
        yield return new WaitForSeconds(shieldRestoreTime);
        if (curHealth > 0 && curHealth < maxHealth)
        {
            curHealth = maxHealth;
        }
    }
}
