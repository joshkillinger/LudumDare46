using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
  public class DeactivateAll : MonoBehaviour
  {
    public void Event_Deactivate()
    {
      StartCoroutine(DeactivateAtEndOfFrame());

    }

    private IEnumerator DeactivateAtEndOfFrame()
    {
      yield return new WaitForEndOfFrame();
            
      foreach (var component in GetComponents<MonoBehaviour>())
      {
        component.enabled = false;
      }
    }
  }
}