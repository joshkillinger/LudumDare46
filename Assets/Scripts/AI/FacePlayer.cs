using DefaultNamespace;
using UnityEngine;

namespace AI
{
  public class FacePlayer : Rollable
  {
    private GameObject player;
    public float leadTime = 1.0f;

    protected override void lateUpdate()
    {
      if (player != null)
      {
        transform.LookAt(player.transform.position + leadTime * GameManager.PlayerSpeed * player.transform.forward);
      }
      else
      {
        player = GameManager.Player;
      }
    }
  }
}