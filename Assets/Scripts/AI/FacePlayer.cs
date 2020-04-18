using UnityEngine;

namespace AI
{
  public class FacePlayer : Rollable
  {
    private GameObject player;
    
    private void Start()
    {
      player = GameObject.FindWithTag("Player");
    }

    protected override void lateUpdate()
    {
      transform.LookAt(player.transform);
    }
  }
}