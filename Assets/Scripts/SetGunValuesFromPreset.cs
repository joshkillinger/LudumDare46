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
    public int selectedIndex = 0;

    private float primarySwapCooldown = 0;

    private void Update()
    {
      if (Input.GetAxis("PrimarySwap") > 0 && primarySwapCooldown <= 0)
      {
        selectedIndex++;
        InputDrivenSwap();
      }
      else if (Input.GetAxis("PrimarySwap") < 0 && primarySwapCooldown <= 0)
      {
        selectedIndex--;
        InputDrivenSwap();
      }

      if (primarySwapCooldown > 0)
      {
        primarySwapCooldown -= Time.deltaTime;
      }
    }

    private void InputDrivenSwap()
    {
      selectedIndex %= gunPresets.Count;
      primarySwapCooldown = 1;
      Event_SwapToGunPreset(selectedIndex);
    }

    public void Event_SwapToGunPreset(int index)
    {
      var preset = gunPresets[index];

      gunController.shot = preset.shot; 
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