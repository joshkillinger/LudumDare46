using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
  public class EnergyMeter : MonoBehaviour
  {
    private GunController controller;
    private int version = -1;

    public Slider slider;
    
    private void Start()
    {
      controller = GameObject.FindWithTag("Player").GetComponent<GunController>();
    }

    private void Update()
    {
      if (controller.Version != version)
      {
        slider.value = controller.CurrentEnergy / controller.energyMax;
        
        version = controller.Version;
      }
    }
  }
}