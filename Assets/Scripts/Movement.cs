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
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator animator;
    float tempX = 0; //1 y -1
    float tempY = 0; //1 y -1 
    Vector3 axis;
    [SerializeField] bool isGrounded = true;
        

    private void Awake()
    {

    }
    // Use this for initialization
    void Start ()
    {

    }
	void Update()
    {
        tempX = Input.GetAxis(Actions.Horizontal.ToString()); //1 y -1
        tempY = Input.GetAxis(Actions.Vertical.ToString()); //1 y -1 
        if (Input.GetButtonDown(Actions.Jump.ToString())  && isGrounded)
        {
            animator.SetTrigger("Jump");
            isGrounded = false;
            rb.velocity = new Vector3(rb.velocity.x,jumpVelocity,rb.velocity.z);
        }
        //Animacion
        
        animator.SetFloat("X&Z",axis.magnitude);
        animator.SetBool("NoGrounded",!isGrounded);
    }
	// Update is called once per frame
	void FixedUpdate ()
    {
        axis = new Vector3(tempX, 0 ,tempY);
        rb.MovePosition(rb.position + axis * speed);
        
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
            animator.SetTrigger("Win");
        }
        if(collision.gameObject.layer.Equals(9))
            isGrounded = true;
    }
    //Agrega Score cuando el trigger con enemigos
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            AddScore();
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
    public enum Actions
    {
        Horizontal, Vertical, Jump
    }
    public void Next()
    {
        SceneManager.LoadScene(++level);
    }
}
