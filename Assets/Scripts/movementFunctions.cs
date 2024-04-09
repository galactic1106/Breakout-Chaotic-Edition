using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementFunctions : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private bool leftPressed = false, rightPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.FindGameObjectWithTag("Paddle").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || leftPressed) { moveLeft(); }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || rightPressed) { moveRight(); }
    }

    public void moveLeft()
    {
        //Debug.Log("left");
        rb.AddForce(Vector2.left * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    public void moveRight()
    {
        //Debug.Log("right");
        rb.AddForce(Vector2.right * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    public void onAttackRight()
    {
        rightPressed = !rightPressed;
    }

    public void onAttackLeft()
    {
        leftPressed = !leftPressed;
    }
}
