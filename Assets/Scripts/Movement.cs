using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 1;
    //Salto
    public float jumpVelocity = 10;
    public float gravityScale = 1;

    CharacterController controller;

    //Movimiento
    Vector3 moveDirection;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Use this for initialization
    void Start () {
        
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        AxisInput();
        controller.Move(moveDirection*Time.deltaTime);

    }

    void AxisInput()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, 0f, Input.GetAxis("Vertical") * speed);
        if (Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpVelocity;
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y *  gravityScale);
    }
}
