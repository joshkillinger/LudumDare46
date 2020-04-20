using UnityEngine;

namespace DefaultNamespace
{
  public class DeactivateAll : MonoBehaviour
  {
    public void Event_Deactivate()
    {
      foreach (var component in GetComponents<MonoBehaviour>())
      {
        component.enabled = false;
      }
    }
  }
}