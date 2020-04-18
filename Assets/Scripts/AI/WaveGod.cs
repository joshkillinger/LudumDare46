using UnityEngine;

namespace AI
{
  public class WaveGod : MonoBehaviour
  {
    public WaveStore Waves;
    public float MinSpawnFrequency = 4;
    public float SpawnVariance = 1;

    public bool AutoSpawn;
    
    private GameObject player;

    private void Start()
    {
      player = GameObject.FindWithTag("Player");
    }

    private float nextWave = 3;

    private void Update()
    {
      if (!AutoSpawn)
      {
        return;
      }
      
      if (nextWave <= Time.time)
      {
        var wave = spawnRandomWave();
        var variance = Random.Range(-SpawnVariance, SpawnVariance);
        nextWave = Time.time + variance + MinSpawnFrequency;
        Debug.Log($"Next wave at {nextWave}");
      }
    }

    private WaveStore.WaveEntry spawnRandomWave()
    {
      var wave = Waves.GetRandom();
      spawnWave(wave);
      return wave;
    }

    public WaveStore.WaveEntry SpawnWave(int index)
    {
      var wave = Waves.Waves[index];
      spawnWave(wave);
      return wave;
    }

    public WaveStore.WaveEntry SpawnWave(string name)
    {
      if (Waves.GetByName(name, out var wave))
      {
        spawnWave(wave);
      }

      return wave;
    }

    private void spawnWave(WaveStore.WaveEntry wave)
    {
      Instantiate(wave.Wave, new Vector3(0, 0, player.transform.position.z), Quaternion.identity);
      Debug.Log($"Instantated wave {wave.Name}");
    }
  }
}