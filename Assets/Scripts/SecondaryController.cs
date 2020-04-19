using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
  public class SecondaryController : MonoBehaviour
  {
    public List<GameObject> weapons;
    public List<int> weaponAmmo;
    public int curWeapon;

    private float cooldown = 0f;
    private float weaponswapCooldown = 0f;

    private void Update()
    {
      if (Input.GetAxis("Fire2") > 0 && cooldown <= 0)
      {
        if (weaponAmmo[curWeapon] > 0)
        {
          var obj = Instantiate(weapons[curWeapon]);

          obj.transform.position = this.transform.position;
          obj.transform.rotation = this.transform.rotation;
          cooldown = 4;
          weaponAmmo[curWeapon]--;
        }
      }
      else
      {
        cooldown -= Time.deltaTime;
      }

      if (Input.GetAxis("SecondarySwap") > 0 && weaponswapCooldown <= 0)
      {
        curWeapon++;
        curWeapon %= weapons.Count;
        weaponswapCooldown = 1.0f;
      }
      else if (Input.GetAxis("SecondarySwap") < 0 && weaponswapCooldown <= 0)
      {
        curWeapon--;
        curWeapon %= weapons.Count;
        weaponswapCooldown = 1.0f;
      }

      if (weaponswapCooldown > 0)
      {
        weaponswapCooldown -= Time.deltaTime;
      }
    }

    public void Event_AddAmmo(int ammo)
    {
      for (int i = 0; i < weaponAmmo.Count; i++)
      {
        weaponAmmo[i]++;
      }
    }
  }
}