using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    public List<AudioSource> barrels = new List<AudioSource>();
    public GameObject shot = null;
    public Slider slider;

    public float energyMax = 100;
    public float regenerationRate = 5;
    [HideInInspector]public float drainAmount = 5f;
    [HideInInspector]public float cooldown = 0.2f;
    [HideInInspector]public float maxDeviation = 0.4f;
    [HideInInspector]public float shotAmount = 2;

    private float currentEnergy;
    private int barrelIndex = 0;
    private float curCooldown = 0;


    // Start is called before the first frame update
    void Start()
    {
        currentEnergy = energyMax;
        slider.minValue = 0;
        slider.maxValue = 1;
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

            curCooldown = cooldown +  3 * cooldown * (1 - (currentEnergy / energyMax));
            currentEnergy -= drainAmount;
            if (currentEnergy < 0)
            {
                currentEnergy = 0;
            }
        }
        else
        {
            curCooldown -= Time.deltaTime;
        }
        
        if (currentEnergy < energyMax)
        {
            currentEnergy += regenerationRate * Time.deltaTime;
        }

        slider.value = currentEnergy / energyMax;
    }

    public void AddEnergy(float energy)
    {
        currentEnergy = Mathf.Clamp(currentEnergy + energy, 0, energyMax);
    }
}
