using UnityEngine;

namespace AI
{
  public class FaceTarget : Rollable
  {
    public GameObject target;
    public float lockRange = 600;
    
    protected override void lateUpdate()
    {
      if (target == null)
      {
        FindTarget();
      }
      else
      {
        transform.LookAt(target.transform);
      }
    }

    private void FindTarget()
    {
      if (target != null)
      {
        return;
      }
      foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
      {
        var cone = Mathf.Cos(45 * Mathf.Deg2Rad);
        var heading = (enemy.transform.position - this.transform.position).normalized;

        if (Vector3.Dot(this.transform.forward, heading) > cone)
        {
          if (Vector3.Distance(this.transform.position, enemy.transform.position) < lockRange)
          {
            target = enemy;
            return;
          }
        }
      }


    }
    
  }
}