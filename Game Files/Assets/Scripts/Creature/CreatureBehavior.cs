using UnityEngine;
using System.Collections;

public class CreatureBehavior : MonoBehaviour
{

    private Vector3 velocity = Vector3.zero;
    public bool grounded = true;

    public float speed = 0.25f;

    public int timer = 0;
    public int timer_interval = 25;

    void Start()
    {
    }

    void Update()
    {
        // Move creature left to right
        if (timer < timer_interval)
        {
            transform.Translate(speed, 0, 0);
        }else
        {
            transform.Translate(-speed, 0, 0);
        }
        timer++;
        // Reset timer
        if (timer > 50) 
            timer = 0;

        //Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        //pos.x = Mathf.Clamp01(pos.x);
        //pos.y = Mathf.Clamp01(pos.y);
        //transform.position = Camera.main.ViewportToWorldPoint(pos);

        //if (pos.x == 1 || pos.x == 0)
        //    velocity *= -1;

        //transform.Translate(velocity * speed);
    }


}
