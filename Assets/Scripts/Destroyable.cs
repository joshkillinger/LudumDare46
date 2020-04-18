using System;
using UnityEngine;

namespace DefaultNamespace
{
  public class Destroyable : MonoBehaviour
  {
    public void Destroy()
    {
      Destroy(this.gameObject);
    }
  }
}