using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonMovement : MonoBehaviour
{
    private float moveSpeed;
    private bool moveRight;
    public static int hp = 5000;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5f;
        moveRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 10f)
        {
            moveRight = false;
        }
        else if (transform.position.x < -10f)
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
    }

    
}
