using UnityEngine;

namespace AI
{
  public class WaveGod : MonoBehaviour
  {
    public WaveStore Waves;
    public float SpawnFrequency = 4;
    public float SpawnVariance = 1;
    
    private GameObject player;

    private void Start()
    {
      player = GameObject.FindWithTag("Player");
    }

    private float nextWave = 3;

    private void Update()
    {
      if (nextWave <= Time.time)
      {
        spawnWave();
        var variance = Random.Range(-SpawnVariance, SpawnVariance);
        nextWave = Time.time + variance + SpawnFrequency;
        Debug.Log($"Next wave at {nextWave}");
      }
    }

    private void spawnWave()
    {
      var wave = Waves.GetRandom();
      Instantiate(wave.Wave, new Vector3(0, 0, player.transform.position.z), Quaternion.identity);
      Debug.Log($"Instantated wave {wave.Name}");
    }
  }
}