using UnityEditor.Animations;
using UnityEngine;

namespace AI
{
  public class LoadRandomAnimator : MonoBehaviour
  {
    public CurveStore curves;

    private AnimatorController animator;
    
    private void Start()
    {
      animator = curves.Entries[Random.Range(0, curves.Entries.Count)].Animator;
    }
  }
}