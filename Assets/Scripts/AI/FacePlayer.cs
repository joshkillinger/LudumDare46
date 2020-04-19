using System;
using DefaultNamespace;
using UnityEngine;

namespace AI
{
  public class FacePlayer : Rollable
  {
    private GameObject player;
    public EnemyGun gun = null;
    private float bulletSpeed;

    protected void Start()
    {
      var shot = gun.shot;
      bulletSpeed = shot.GetComponent<Shot>().speed;
    }

    protected override void lateUpdate()
    {
      if (player != null)
      {
        var playerPos = player.transform.position;
        Vector3 lookpos = playerPos;
        float travelTime = Vector3.Distance(this.transform.position, lookpos) / bulletSpeed;
        Vector3 newLookPos = playerPos + travelTime * GameManager.PlayerSpeed * player.transform.forward;
        float newTravelTime = Vector3.Distance(this.transform.position, newLookPos) / bulletSpeed;
        transform.LookAt(playerPos + newTravelTime * GameManager.PlayerSpeed * player.transform.forward);
      }
      else
      {
        player = GameManager.Player;
      }
    }
  }
}