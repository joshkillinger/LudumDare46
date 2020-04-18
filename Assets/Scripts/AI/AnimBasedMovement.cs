using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimBasedMovement : MonoBehaviour
{
  public Transform StartAnchor;
  public Transform EndAnchor;

  public float StartBlend = 1;
  public float EndBlend = 0;

  private void LateUpdate()
  {
    var localPos = transform.localPosition;
    var pos1 = Vector3.Lerp(localPos, StartAnchor.localPosition, StartBlend);
    var pos2 = Vector3.Lerp(localPos, EndAnchor.localPosition, EndBlend);
    transform.localPosition = (pos1 + pos2) / 2;
    
    var localRot = transform.localRotation;
    var rot1 = Quaternion.Slerp(localRot, StartAnchor.localRotation, StartBlend);
    var rot2 = Quaternion.Slerp(localRot, EndAnchor.localRotation, EndBlend);
    transform.localRotation = Quaternion.Slerp(rot1, rot2, .5f);
  }
}
