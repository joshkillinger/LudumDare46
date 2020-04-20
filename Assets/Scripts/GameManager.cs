using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
  public class GameManager : MonoBehaviour
  {
    public static GameObject Player;
    public static float PlayerSpeed = 0;
    public static int Score = 0;
    public static bool PlayerIsDead = false;

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

    public void Event_SetPlayerDead()
    {
      PlayerIsDead = true;
      StartCoroutine(goToMenuAfterDelay());
    }

    private IEnumerator goToMenuAfterDelay()
    {
      yield return new WaitForSeconds(5);
      SceneManager.LoadScene("MainMenu");
    }
  }
}