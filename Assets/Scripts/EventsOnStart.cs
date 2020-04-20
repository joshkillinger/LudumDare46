using System;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
  public class EventsOnStart : MonoBehaviour
  {
    public UnityEvent events;

    private void Start()
    {
      events.Invoke();
    }
  }
}