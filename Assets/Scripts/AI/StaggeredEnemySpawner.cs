using System.Collections;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Serialization;

namespace AI
{
  public class StaggeredEnemySpawner : MonoBehaviour
  {
    [FormerlySerializedAs("Prefab")] public GameObject Prototype;
    public int MinCount;
    public int MaxCount;
    public float Stagger;

    private IEnumerator Start()
    {
      int count = Random.Range(MinCount, MaxCount);

      for (int i = 0; i < count; ++i)
      {
        var instance = Instantiate(Prototype, transform);
        instance.SetActive(true);
        yield return new WaitForSeconds(Stagger);
      }
    }
  }
}