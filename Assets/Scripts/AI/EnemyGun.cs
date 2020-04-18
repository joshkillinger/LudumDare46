using System;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AI
{
  public class EnemyGun : MonoBehaviour
  {
    public GameObject shot;
    public bool onlyShootOnPlayerVisible = false;
    public float maxScatterAngle = 1;
    
    public void Event_Shoot()
    {
      var transPos = this.transform.position;
      var transRot = this.transform.rotation;
      if (onlyShootOnPlayerVisible)
      {
        Ray ray = new Ray(transPos, transPos - GameManager.Player.transform.position);
        if (Physics.Raycast(ray, out var hit))
        {
          if (!hit.collider.gameObject.CompareTag("Player"))
          {
            return;
          }
        }
        else
        {
          return;
        }
      }

      var obj = Instantiate(shot);
      obj.transform.position = transPos;
      obj.transform.rotation = transRot;
      obj.transform.Rotate(Random.Range(-maxScatterAngle, maxScatterAngle), Random.Range(-maxScatterAngle, maxScatterAngle), 0);

    }
  }
}