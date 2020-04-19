using TMPro;
using UnityEngine;

namespace DefaultNamespace.UI
{
  [RequireComponent(typeof(TMP_Text))]
  public class Speed : MonoBehaviour
  {
    private ShipController ship;
    private TMP_Text text;

    private void Start()
    {
      ship = GameObject.FindWithTag("Player").GetComponent<ShipController>();
      text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
      text.text = $"{ship.Velocity} m / s";
    }
  }
}