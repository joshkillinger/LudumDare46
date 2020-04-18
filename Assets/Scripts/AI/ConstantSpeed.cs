using UnityEngine;

namespace AI
{
  public class ConstantSpeed : MonoBehaviour
  {
    public float Speed = 10;

    private void Update()
    {
      transform.position = transform.position + (transform.forward * Speed * Time.deltaTime);
    }
  }
}