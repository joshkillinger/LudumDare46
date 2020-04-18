using System;
using UnityEngine;

namespace DefaultNamespace
{
  public class GameManager : MonoBehaviour
  {
    public static GameObject Player;

    private void Start()
    {
      if (Player == null)
      {
        Player = GameObject.FindWithTag("Player");
      }
    }
  }
}