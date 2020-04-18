using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveBasedMovement : MonoBehaviour
{
  public AnimationCurve curveX = AnimationCurve.Linear(0, 0, 1, 0);
  public AnimationCurve curveY = AnimationCurve.Linear(0, 1, 1, 0);

  public bool invertX = false;
  public bool invertY = false;

  [SerializeField] bool faceMovementDirection = true;

  float startTime;

  // Use this for initialization
  void Start()
  {
    startTime = Time.time;
    reposition(0);
  }

  // Update is called once per frame
  void Update()
  {
    reposition(Time.time - startTime);
  }

  void reposition(float time)
  {
    Vector3 dest = new Vector3(curveX.Evaluate(time), curveY.Evaluate(time), 0);
    if (invertX)
    {
      dest.x *= -1;
    }
    if (invertY)
    {
      dest.y *= -1;
    }

    if (faceMovementDirection)
    {
      float angle = Vector3.Angle(Vector3.up, dest - transform.localPosition);
      if (dest.x > transform.localPosition.x)
      {
        angle *= -1;
      }
      transform.eulerAngles = new Vector3(0, 0, angle);
    }

    transform.localPosition = dest;
  }
}
