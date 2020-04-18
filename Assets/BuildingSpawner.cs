using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public List<GameObject> buildings;
    public float minDistanceBetweenSpawns = 100;
    public float maxDistanceBetweenSpawns = 250;
    public float verticalLevelOfGround = -16;
    
    private Vector3 lastSpawnPos;
    
    // Start is called before the first frame update
    void Start()
    {
        lastSpawnPos = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        var randomPos = this.transform.position;

        Vector2 displacement = Random.insideUnitCircle * maxDistanceBetweenSpawns;
        
        randomPos = new Vector3(randomPos.x + displacement.x, verticalLevelOfGround, randomPos.z + displacement.y);

        if (Vector3.Distance(lastSpawnPos, randomPos) > minDistanceBetweenSpawns && randomPos.z > lastSpawnPos.z)
        {
            var obj = Instantiate(buildings[Random.Range(0, buildings.Count)]);
            obj.transform.position = randomPos;
            lastSpawnPos = randomPos;
        }
    }
}
