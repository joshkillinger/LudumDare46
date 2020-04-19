using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[RequireComponent(typeof(Destroyable))]
public class Health : MonoBehaviour
{
    public int maxHealth = 1;
    public float shieldRestoreTime = 0f;
    
    public AudioClip hitSound;
    public AudioSource source;

    private int curHealth;
    public int CurrentHealth => curHealth;

    private Destroyable destroyable;
    // Start is called before the first frame update
    void Start()
    {
        destroyable = this.GetComponent<Destroyable>();
        curHealth = maxHealth;
        source.clip = hitSound;
    }

    // Update is called once per frame
    void Update()
    {
        if (curHealth <= 0)
        {
            destroyable.Destroy();
        }
    }

    public void TakeDamage()
    {
        source.Play();
        curHealth -= 1;
        StopAllCoroutines();
        
        if (curHealth > 0 && shieldRestoreTime > 0)
        {
            StartCoroutine(restoreHpAfterDelay());
        }
    }

    private IEnumerator restoreHpAfterDelay()
    {
        yield return new WaitForSeconds(shieldRestoreTime);
        if (curHealth > 0 && curHealth < maxHealth)
        {
            curHealth = maxHealth;
        }
    }
}
