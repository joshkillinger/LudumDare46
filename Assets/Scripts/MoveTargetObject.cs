using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTargetObject : MonoBehaviour
{
    public float horizontalDistanceLimit = 10;
    public float verticalDistanceLimit = 8;
    public float speed = 5;
    public float smoothNumber = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalSpeed = Input.GetAxis("Horizontal") * speed;
        var horizontalDistance = this.transform.position.x;

        var halfHorizontalLimit = horizontalDistanceLimit / 2;
        if (horizontalDistance > halfHorizontalLimit && horizontalSpeed > 0)
        {
            horizontalSpeed *= smoothFalloff(horizontalDistance - halfHorizontalLimit);
        }
        else if (horizontalDistance < -1 * halfHorizontalLimit && horizontalSpeed < 0)
        {
            horizontalSpeed *= smoothFalloff(Mathf.Abs(horizontalDistance + halfHorizontalLimit));
        }
        
        var verticalSpeed = Input.GetAxis("Vertical") * speed;
        var verticalDistance = this.transform.position.y;

        var halfVerticalLimit = verticalDistanceLimit / 2;
        if (verticalDistance > halfVerticalLimit && verticalSpeed > 0)
        {
            verticalSpeed *= smoothFalloff(verticalDistance - halfVerticalLimit);
        }
        else if (verticalDistance < -halfVerticalLimit && verticalSpeed < 0)
        {
            verticalSpeed *= smoothFalloff(Mathf.Abs(verticalDistance + halfVerticalLimit));
        }
        
        Vector2 move = new Vector2(horizontalSpeed, verticalSpeed) * Time.deltaTime;
        this.transform.Translate(move);

    }

    float smoothFalloff(float x)
    {
        return 1 - Mathf.Pow(x / (horizontalDistanceLimit / 2), smoothNumber);
    }
}
