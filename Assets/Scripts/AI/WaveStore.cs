using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AI
{
  [CreateAssetMenu(fileName = "WaveStore", menuName = "Scriptables/Wave Store")]
  public class WaveStore : ScriptableObject
  {
    [Serializable]
    public struct WaveEntry
    {
      public string Name;
      public GameObject Wave;
    }

    public List<WaveEntry> Waves;

    public WaveEntry GetRandom()
    {
      var index = Random.Range(0, Waves.Count);
      return Waves[index];
    }
  }
}