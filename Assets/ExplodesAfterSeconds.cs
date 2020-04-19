using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodesAfterSeconds : MonoBehaviour
{
    public float seconds = 2.0f;
    public GameObject explosion;

    private float countdown;
    // Start is called before the first frame update
    void Start()
    {
        countdown = seconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown >= 0)
        {
            countdown -= Time.deltaTime;
        }
        else
        {
            Boom();
        }
    }

    protected void Boom()
    {
        var shot = this.GetComponent<Shot>();
        if (shot != null)
        {
            shot.enabled = false;
        }
        var obj = Instantiate(explosion);
        obj.transform.position = this.transform.position;
        obj.transform.rotation = this.transform.rotation;
        Destroy(this.gameObject);
    }
}
