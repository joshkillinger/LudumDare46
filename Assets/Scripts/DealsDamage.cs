using System;
using UnityEngine;

namespace DefaultNamespace
{
  [RequireComponent(typeof(Collider))]
  public class DealsDamage : MonoBehaviour
  {
    public void OnTriggerEnter(Collider other)
    {
      var healthComp = other.gameObject.GetComponent<Health>();
      if(healthComp != null)
      {
        healthComp.TakeDamage();
      }

      var explodes = this.gameObject.GetComponent<ExplodeAfterDealingDamage>();
      if (explodes != null)
      {
        explodes.Event_Explode();
      }
    }
  }
}