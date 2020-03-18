using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform target;
    public float smoothing;
    public Vector2 max_xy;
    public Vector2 min_xy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // LateUpdate is called the last
    void LateUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
            targetPos.x = Mathf.Clamp(targetPos.x, min_xy.x, max_xy.x);
            targetPos.y = Mathf.Clamp(targetPos.y, min_xy.y, max_xy.y);
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        }
    }
}
