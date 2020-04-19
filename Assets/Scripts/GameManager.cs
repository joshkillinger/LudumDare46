using UnityEngine;

namespace DefaultNamespace
{
  public class GameManager : MonoBehaviour
  {
    public static GameObject Player;
    public static float PlayerSpeed = 0;

    private void Start()
    {
      if (Player == null)
      {
        Player = GameObject.FindWithTag("Player");
      }

      if (PlayerSpeed == 0)
      {
        PlayerSpeed = Player.GetComponent<ShipController>().speed;
      }
    }
  }
}