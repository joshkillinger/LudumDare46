using UnityEngine;

namespace AI
{
  public class FaceMovementDirection : Rollable
  {
    private Vector3? lastPos = null;
    
    protected override void lateUpdate()
    {
      if (lastPos.HasValue)
      {
        var dir = (transform.position - lastPos.Value) * 10;
        if (!Mathf.Approximately(dir.sqrMagnitude, 0))
        {
          transform.LookAt(transform.position + dir);
        }
      }

      lastPos = transform.position;
    }
  }
}