using UnityEngine;

namespace DefaultNamespace
{
  public class PlayOnEvent : MonoBehaviour
  {
    public AudioSource source;

    public void Event_Play()
    {
      source.Play();
    }
  }
}