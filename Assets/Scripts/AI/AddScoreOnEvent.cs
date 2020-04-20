using System;
using DefaultNamespace;
using UnityEngine;

namespace AI
{
  public class AddScoreOnEvent : MonoBehaviour
  {
    public int Score = 100;

    public void Event_AddScore()
    {
      GameManager.Score += Score;
    }
  }
}