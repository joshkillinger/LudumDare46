using System.Collections;
using TMPro;
using UnityEngine;

namespace DefaultNamespace.UI
{
  [RequireComponent(typeof(TMP_Text))]
  public class ShieldStatus : MonoBehaviour
  {
    public Color DamagedColor = Color.red;
    public Color ChargingColor = Color.yellow;
    public Color ActiveColor = Color.green;
    public Color Overcharged = Color.cyan;

    public string DamagedText = "DAMAGED";
    public string ChargingText = "CHARGING";
    public string ActiveText = "ACTIVE";
    public string OverchargedText = "OVERCHARGED";

    public float DamagedBlinkRate = .15f;
    public float ChargingBlinkRate = .25f;
    public float DamagedTime = 2f;
    public float OverchargedTime = 2f;

    private TMP_Text text;
    private Health health;
    private Skimming skimming;
    private Coroutine overchargedCoroutine = null;

    private int cachedHp = 0;
    
    private void Start()
    {
      text = GetComponent<TMP_Text>();
      health = GameObject.FindWithTag("Player").GetComponent<Health>();
      skimming = GameObject.FindWithTag("Player").GetComponentInChildren<Skimming>();
    }
    
    private void Update()
    {
      if (skimming.invincible && overchargedCoroutine == null)
      {
        StopAllCoroutines();
        overchargedCoroutine = StartCoroutine(overcharged());
      }
      
      if (health.CurrentHealth == cachedHp)
      {
        return;
      }
      cachedHp = health.CurrentHealth;
      if (health.CurrentHealth < health.maxHealth)
      {
        StopAllCoroutines();
        if (health.CurrentHealth > 0)
        {
          StartCoroutine(damaged());
        }
      }
      else
      {
        StopAllCoroutines();
        text.color = ActiveColor;
        text.text = ActiveText;
        text.enabled = true;
      }
    }

    private IEnumerator damaged()
    {
      text.color = DamagedColor;
      text.text = DamagedText;
      text.enabled = true;

      var rechargeAt = Time.time + DamagedTime;
      while (Time.time < rechargeAt)
      {
        yield return new WaitForSeconds(DamagedBlinkRate);
        text.enabled = !text.enabled;
      }

      text.color = ChargingColor;
      text.text = ChargingText;

      while (true)
      {
        yield return new WaitForSeconds(DamagedBlinkRate);
        text.enabled = !text.enabled;
      }
    }

    private IEnumerator overcharged()
    {
      text.color = Overcharged;
      text.text = OverchargedText;
      text.enabled = true;

      var rechargeAt = Time.time + OverchargedTime;
      while (Time.time < rechargeAt)
      {
        yield return new WaitForSeconds(DamagedBlinkRate);
        text.enabled = !text.enabled;
      }
      
      text.color = ActiveColor;
      text.text = ActiveText;
      text.enabled = true;
      overchargedCoroutine = null;
    }
  }
}