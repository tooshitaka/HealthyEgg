using UnityEngine;
using System.Collections;

public class CreatureBehavior : MonoBehaviour
{

    private Vector3 velocity = Vector3.zero;
    public bool grounded = true;

    public float speed = 1.5f;

    void Start()
    {
        velocity.x = 1f;
    }

    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        if (pos.x == 1 || pos.x == 0)
            velocity *= -1;

        transform.Translate(velocity * speed);
    }


}
