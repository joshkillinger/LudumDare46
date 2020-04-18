using UnityEngine;

namespace AI
{
  [RequireComponent(typeof(Rollable))]
  public class ConstantRoll : MonoBehaviour
  {
    public float RollSpeed = 90f;
    
    private Rollable rollable;
    
    private void Start()
    {
      rollable = GetComponent<Rollable>();
    }

    private void Update()
    {
      rollable.Roll += RollSpeed * Time.deltaTime;
      if (rollable.Roll < 0)
      {
        rollable.Roll += 360;
      }
      else if (rollable.Roll > 360)
      {
        rollable.Roll -= 360;
      }
    }
  }
}