using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
  [Serializable]
  public struct GunPreset
  {
    public GameObject shot;
    public AudioClip clip;

    public float energyMax;
    public float regenerationRate;
    public float drainAmount;
    public float cooldown;
    public float maxDeviation;
    public float shotAmount;
  }
  public class SetGunValuesFromPreset : MonoBehaviour
  {
    public GunController gunController;
    public List<AudioSource> gunSources;
    public List<GunPreset> gunPresets;

    public void Event_SwapToGunPreset(int index)
    {
      var preset = gunPresets[index];

      gunController.shot = preset.shot; 
      gunController.energyMax = preset.energyMax;
      gunController.regenerationRate = preset.regenerationRate;
      gunController.drainAmount = preset.drainAmount;
      gunController.cooldown = preset.cooldown;
      gunController.maxDeviation = preset.maxDeviation;
      gunController.shotAmount = preset.shotAmount;
      foreach (var gunSource in gunSources)
      {
        gunSource.clip = preset.clip;
      }

    }
  }
}