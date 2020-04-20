using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace.UI
{
  public class StartButton : MonoBehaviour
  {
    public void Event_OnClick()
    {
      SceneManager.LoadScene("GameScene");
    }
  }
}