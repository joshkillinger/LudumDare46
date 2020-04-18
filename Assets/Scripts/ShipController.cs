using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed = 10f;
    private float velocity = 0;
    public float boostMult = 1.2f;

    public bool go = false;

    public GameObject targetObject = null;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            velocity = speed; //TODO: smooth ramp up/ ramp down

            if (Input.GetAxis("Boost") > 0)
            {
                velocity *= boostMult;
            }

            this.transform.position += Time.deltaTime * velocity * this.transform.forward;
        }
        
        this.transform.LookAt(targetObject.transform);
    }
}
