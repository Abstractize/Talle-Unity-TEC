using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 1;
    //Salto
    public float jumpVelocity = 10;

    Rigidbody rb;
    bool goal = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        AxisInput();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            rb.transform.position = Vector3.zero;
        }

        if (collision.gameObject.tag.Equals("Goal"))
        {
            goal = true;
        }
    }

    void OnGUI()
    {
        if (goal)
        {
            GUI.Label(new Rect(Screen.width / 2, (Screen.height / 2) - 80, 200f, 200f), "WINNER");

        }
    }

    //Teclado
    //Otra Manera de Hacerlo
    void AxisInput()
    {
        //Forward
        if (Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(rb.position + Vector3.forward * speed);
        }
        //Back
        if (Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(rb.position + Vector3.back * speed);
        }
        //Left
        if (Input.GetKey(KeyCode.A))
        {
            rb.MovePosition(rb.position + Vector3.left * speed);
        }
        //Right
        if (Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(rb.position + Vector3.right * speed);
        }
        //Front
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpVelocity, rb.velocity.z);
        }
    }
}
