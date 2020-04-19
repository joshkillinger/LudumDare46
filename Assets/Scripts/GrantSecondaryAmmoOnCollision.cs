using System;
using UnityEngine;

namespace DefaultNamespace
{
  [RequireComponent(typeof(Collider))]
  public class GrantSecondaryAmmoOnCollision : MonoBehaviour
  {
    public int ammoAmount;

    private void OnTriggerEnter(Collider other)
    {
      var secondary = other.GetComponent<SecondaryController>();
      if (secondary != null)
      {
        secondary.Event_AddAmmo(ammoAmount);
        Destroy(this.gameObject);
      }
    }
  }
}