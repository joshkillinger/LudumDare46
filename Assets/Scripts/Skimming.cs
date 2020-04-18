using System;
using UnityEngine;

namespace DefaultNamespace
{
  public class Skimming : MonoBehaviour
  {
    public GunController gun;
    public ParticleSystem particles;
    public float energyAdd = 10;

    private void OnTriggerEnter(Collider other)
    {
        gun.AddEnergy(energyAdd);
        particles.Emit(1);
    }
  }
}