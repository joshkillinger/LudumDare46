using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
  public class DestroyAfterSeconds : MonoBehaviour
  {
    public float TimeToLive = 5f;
    
    private void Start()
    {
      StartCoroutine(delay());
    }

    private IEnumerator delay()
    {
      yield return new WaitForSeconds(TimeToLive);
      Destroy(gameObject);
    }
  }
}