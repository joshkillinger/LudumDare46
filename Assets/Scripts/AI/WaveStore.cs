using System;
using System.Collections.Generic;
using UnityEditor.U2D;
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
      public float Duration;
      public GameObject Wave;
    }

    public List<WaveEntry> Waves;

    public WaveEntry GetRandom()
    {
      var index = Random.Range(0, Waves.Count);
      return Waves[index];
    }

    private Dictionary<string, WaveEntry> _entriesByName;

    private Dictionary<string, WaveEntry> entriesByName
    {
      get
      {
        if (_entriesByName == null)
        {
          _entriesByName = new Dictionary<string, WaveEntry>();
          foreach (var entry in Waves)
          {
            _entriesByName[entry.Name] = entry;
          }
        }

        return _entriesByName;
      }
    }
    
    public bool GetByName(string name, out WaveEntry wave)
    {
      if (!entriesByName.TryGetValue(name, out wave))
      {
        Debug.LogError($"Invalid name {name}");
        return false;
      }

      return true;
    }
  }
}