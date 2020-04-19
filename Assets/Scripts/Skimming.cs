using System;
using UnityEngine;

namespace DefaultNamespace
{
  [RequireComponent(typeof(CapsuleCollider))]
  public class Skimming : MonoBehaviour
  {
    public GunController gun;
    public ParticleSystem particles;
    public AudioSource audioSource;

    private CapsuleCollider skimmingCollider;
    public Collider hitboxCollider;
    public float energyAdd = 10;
    public float invincibleSkimmingMult = 2.0f;
    public float invincibleDuration = 1.0f;
    public float invincibleCooldown = 5.0f;
    private float baseSkimmingSize;
    private float curCooldown;
    private float curDuration;
    

    private void Start()
    {
      skimmingCollider = this.GetComponent<CapsuleCollider>();
      baseSkimmingSize = skimmingCollider.radius;
      curCooldown = 0;
      curDuration = 0;
    }

    private void Update()
    {
      if ((Input.GetAxis("Invincible") > 0 && curCooldown <= 0) || curDuration > 0)
      {
        skimmingCollider.radius = baseSkimmingSize * invincibleSkimmingMult;
        if (curDuration <= 0)
        {
          curDuration = invincibleDuration;
          curCooldown = invincibleCooldown;
          hitboxCollider.enabled = false;
        }
        else
        {
          curDuration -= Time.deltaTime;
        }
      }
      else
      {
        skimmingCollider.radius = baseSkimmingSize;
        hitboxCollider.enabled = true;
      }
      
      if (curCooldown >= 0)
      {
        curCooldown -= Time.deltaTime;
      }
    }

    private void OnTriggerEnter(Collider other)
    {
        gun.AddEnergy(energyAdd);
        particles.Emit(1);
        audioSource.Play();
    }
  }
}