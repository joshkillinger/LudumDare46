using System;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace AI
{
  [CreateAssetMenu(fileName = "CurveStore", menuName = "Scriptables/CurveStore")]
  public class CurveStore : ScriptableObject
  {
    [Serializable]
    public struct CurveEntry
    {
      public string Name;
      public AnimatorController Animator;
    }

    public List<CurveEntry> Entries;
  }
}