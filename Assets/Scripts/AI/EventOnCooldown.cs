using System;
using UnityEngine;
using UnityEngine.Events;

namespace AI
{
  
  public class EventOnCooldown : MonoBehaviour
  {
    public UnityEvent newEvent;
    public float cooldown;
    public float initialCooldown;
    private float curCooldown;

    private void Start()
    {
      curCooldown = initialCooldown;
    }

    private void Update()
    {
      if (curCooldown > 0)
      {
        curCooldown -= Time.deltaTime;
      }
      else
      {
        newEvent.Invoke();
        curCooldown = cooldown;
      }
    }
  }
}