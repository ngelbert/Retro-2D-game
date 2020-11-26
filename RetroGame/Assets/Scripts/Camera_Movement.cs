using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public float inverseDelay;
    public Transform target;
    public Vector2 maxBounds;
    public Vector2 minBounds;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != target.position)
        {
            float capped_x = Mathf.Clamp(target.position.x, minBounds.x, maxBounds.x);
            float capped_y = Mathf.Clamp(target.position.y, minBounds.y, maxBounds.y);
            Vector3 dest = new Vector3(capped_x, capped_y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, dest, inverseDelay);
        }
    }
}
