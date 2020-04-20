
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class Death : MonoBehaviour
{

  private TextMeshProUGUI text;

  private void Start()
  {
    text = GetComponent<TextMeshProUGUI>();
    text.enabled = false;
  }

  private void Update()
  {
    if (GameManager.PlayerIsDead)
    {
      text.enabled = true;
    }
  }
}
