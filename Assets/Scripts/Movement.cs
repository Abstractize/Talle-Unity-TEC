using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {
    //Velocidad de moviemiento de personaje
    public float speed = 1;
    //Velocidad de salto de personaje
    public float jumpVelocity = 10;
    //Nivel
    int level = 0;
    //Rigidbody
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        AxisInput();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Devuelve al punto inicial y elimina el puntaje
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            ResetScore();
            rb.transform.position = Vector3.zero;
        }
        //Paso de escena
        if (collision.gameObject.tag.Equals("Goal"))
        {
            SceneManager.LoadScene(++level);
        }
    }
    //Agrega Score cuando el trigger con enemigos
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            AddScore();
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
            //Ojo
            rb.velocity = new Vector3(rb.velocity.x, jumpVelocity, rb.velocity.z);
        }
    }
    //Score
    void AddScore()
    {
       GameObject.FindGameObjectWithTag("Text").GetComponent<Score>().AddScore();
    }
    void ResetScore()
    {
        GameObject.FindGameObjectWithTag("Text").GetComponent<Score>().ResetScore();
    }
}
