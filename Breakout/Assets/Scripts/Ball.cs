using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed=1;
    private Rigidbody2D rb;
    private GameObject lose;
    private GameObject reloadButton;
    void Start()
    {
        gameObject.transform.rotation = Quaternion.EulerRotation(new Vector3(0, 0, Random.Range(-225, -125)));
        rb = gameObject.GetComponent<Rigidbody2D>();
        lose=GameObject.FindGameObjectWithTag("Lose");
        lose.SetActive(false);
        reloadButton = GameObject.FindGameObjectWithTag("Reset");
        reloadButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddRelativeForce(Vector2.up * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Ground":
                lose.SetActive(true);
                reloadButton.SetActive(true);
                Destroy(gameObject);
                break;
            case "Block":
                Destroy(collision.gameObject);
                break;
        }
    }
}
