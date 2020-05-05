using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public KeyCode shoot;
    public GameObject bullet;
    private Rigidbody2D playerRigidbody;
    private Vector3 changepos;
    public VectorValue playerSave;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        changepos = Vector3.zero;
        changepos.x = Input.GetAxisRaw("Horizontal");
        changepos.y = Input.GetAxisRaw("Vertical");
        MoveChar();

        if (Input.GetKeyDown("space"))
        {
            // Create a new bullet at “transform.position” which is the current position of the ship 
            Instantiate(bullet, transform.position, Quaternion.identity);
        }       
    }

    private void MoveChar()
    {
        playerRigidbody.MovePosition(
                transform.position + changepos * speed * Time.deltaTime
            );
    }
}