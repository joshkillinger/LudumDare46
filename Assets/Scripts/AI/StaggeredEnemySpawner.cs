using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

namespace AI
{
  public class StaggeredEnemySpawner : MonoBehaviour
  {
    public Animator Prefab;
    public AnimatorController path;
    public int MinCount;
    public int MaxCount;
    public float Stagger;

    private IEnumerator Start()
    {
      int count = Random.Range(MinCount, MaxCount);

      for (int i = 0; i < count; ++i)
      {
        var instance = Instantiate(Prefab, transform);
        instance.runtimeAnimatorController = path;
        
        yield return new WaitForSeconds(Stagger);
      }
    }
  }
}