using UnityEngine;

namespace AI
{
  public class Rollable : MonoBehaviour
  {
    public float Roll;

    private void LateUpdate()
    {
      lateUpdate();
      
      var rot = Roll - transform.rotation.eulerAngles.z;
      transform.Rotate(transform.forward, rot, Space.World);
    }

    protected virtual void lateUpdate()
    {
    }
  }
}