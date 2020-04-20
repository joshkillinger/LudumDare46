using UnityEngine;

namespace DefaultNamespace.UI
{
  public class ExitButton : MonoBehaviour
  {
    public void Event_OnClick()
    {
      Application.Quit();
    }
  }
}