using System;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float speed;
    public float lifetime = 5;
    private float curLifetime = 5;

    private void Start()
    {
        curLifetime = lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        curLifetime -= Time.deltaTime;

        if (curLifetime <= 0)
        {
            Destroy(this.gameObject);
        }
        
        this.transform.Translate(Time.deltaTime * speed * Vector3.forward);
    }
}
