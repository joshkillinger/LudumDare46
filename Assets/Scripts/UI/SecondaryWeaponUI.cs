using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DefaultNamespace.UI
{
  public class SecondaryWeaponUI : MonoBehaviour
  {
    public List<GameObject> Indicators;
    public List<TMP_Text> Counts;

    private SecondaryController guns;

    private void Start()
    {
      guns = GameObject.FindWithTag("Player").GetComponent<SecondaryController>();
    }

    private int lastIndex = -1;

    private void Update()
    {
      if (guns.curWeapon != lastIndex)
      {
        for (int i = 0; i < Indicators.Count; ++i)
        {
          Indicators[i].SetActive(i == guns.curWeapon);
        }

        lastIndex = guns.curWeapon;
      }

      for (int i = 0; i < Counts.Count; ++i)
      {
        Counts[i].text = guns.weaponAmmo[i].ToString();
      }
    }
  }
}