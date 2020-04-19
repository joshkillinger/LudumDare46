using System;
using System.Collections;
using AI;
using UnityEngine;

namespace DefaultNamespace
{
  public class SecondaryController : MonoBehaviour
  {
    public int curAmmo = 1;
    public GameObject curWeapon;

    private float cooldown = 0f;

    private void Update()
    {
      if (Input.GetAxis("Fire2") > 0 && cooldown <= 0)
      {
        if (curAmmo > 0)
        {
          var obj = Instantiate(curWeapon);

          obj.transform.position = this.transform.position;
          obj.transform.rotation = this.transform.rotation;
          cooldown = 4;
          curAmmo--;

        }
      }
      else
      {
        cooldown -= Time.deltaTime;
      }
    }
  }
}