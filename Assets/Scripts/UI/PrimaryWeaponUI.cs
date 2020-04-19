using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.UI
{
  public class PrimaryWeaponUI : MonoBehaviour
  {
    public List<GameObject> Indicators;

    private SetGunValuesFromPreset guns;

    private void Start()
    {
      guns = GameObject.FindWithTag("Player").GetComponent<SetGunValuesFromPreset>();
    }

    private int lastIndex = -1;

    private void Update()
    {
      if (guns.selectedIndex != lastIndex)
      {
        for (int i = 0; i < Indicators.Count; ++i)
        {
          Indicators[i].SetActive(i == guns.selectedIndex);
        }

        lastIndex = guns.selectedIndex;
      }
    }
  }
}