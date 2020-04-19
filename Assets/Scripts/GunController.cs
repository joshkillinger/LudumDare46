using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    public int Version = 0;
    
    public List<AudioSource> barrels = new List<AudioSource>();
    public GameObject shot = null;

    public float energyMax = 100;
    public float regenerationRate = 5;
    [HideInInspector]public float drainAmount = 5f;
    [HideInInspector]public float cooldown = 0.2f;
    [HideInInspector]public float maxDeviation = 0.4f;
    [HideInInspector]public float shotAmount = 2;

    private float _currentEnergy;
    public float CurrentEnergy
    {
        get => _currentEnergy;
        private set
        {
            ++Version;
            _currentEnergy = value;
        }
    }
    
    private int barrelIndex = 0;
    private float curCooldown = 0;


    // Start is called before the first frame update
    void Start()
    {
        CurrentEnergy = energyMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire1") > 0 && curCooldown <= 0)
        {

            for (int i = 0; i < shotAmount; i++)
            {
                var targetBarrel = barrels[++barrelIndex % barrels.Count];
                targetBarrel.Play();
                var obj = Instantiate(shot);
                obj.transform.position = targetBarrel.transform.position;
                obj.transform.rotation = targetBarrel.transform.rotation;
                obj.transform.Rotate(Random.Range(-maxDeviation, maxDeviation), Random.Range(-maxDeviation, maxDeviation), 0);
            }

            curCooldown = cooldown +  3 * cooldown * (1 - (CurrentEnergy / energyMax));
            CurrentEnergy -= drainAmount;
            if (CurrentEnergy < 0)
            {
                CurrentEnergy = 0;
            }
        }
        else
        {
            curCooldown -= Time.deltaTime;
        }
        
        if (CurrentEnergy < energyMax)
        {
            CurrentEnergy += regenerationRate * Time.deltaTime;
        }
    }

    public void AddEnergy(float energy)
    {
        CurrentEnergy = Mathf.Clamp(CurrentEnergy + energy, 0, energyMax);
    }
}
