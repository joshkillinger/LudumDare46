using System;
using UnityEngine;

namespace DefaultNamespace
{
  [RequireComponent(typeof(Collider))]
  public class DealsDamage : MonoBehaviour
  {
    public float damage;

    public void OnTriggerEnter(Collider other)
    {
      var healthComp = other.gameObject.GetComponent<Health>();
      if(healthComp != null)
      {
        healthComp.TakeDamage(damage);
      }
    }
  }
}