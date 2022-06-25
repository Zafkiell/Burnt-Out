using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemetScript : MonoBehaviour
{
    
    public bool ligado;
    public float Velocity,VelocityMin,VeclocityMax;
    public bool corre;
	public bool active;
    [Space]

	public float InputX;
	public float InputZ;
	public Vector3 desiredMoveDirection;
	public bool blockRotationPlayer;
	public float desiredRotationSpeed = 0.1f;
    public CharacterController controller;
    public float Speed;
    public float allowPlayerRotation = 0.1f;
    public Camera cam;
    public bool isGrounded;
    public float verticalVel;
    private Vector3 moveVector;
    public bool invertControl,doente;
    // Start is called before the first frame update
    void Start()
    {
        ligado = true;
        controller = this.GetComponent<CharacterController>();
        cam = Camera.main;
        invertControl = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(ligado)
        {
            //if(Input.GetKey(KeyCode.LeftShift)){
                if(doente == false){
                Velocity = VeclocityMax;
                corre = true;
            }else{
                Velocity = VelocityMin;
                corre = false;
            }

            InputMagnitude ();

            if (!active)
                return;

            isGrounded = controller.isGrounded;
            if (isGrounded)
            {
                verticalVel = 0;
            }
            else
            {
                verticalVel -= 1;
            }
            moveVector = new Vector3(0, verticalVel * .2f * Time.deltaTime, 0);
            controller.Move(moveVector);
        }
    }
     void PlayerMoveAndRotation() {
		InputX = Input.GetAxis ("Horizontal");
		InputZ = Input.GetAxis ("Vertical");

		var forward = cam.transform.forward;
		var right = cam.transform.right;

		forward.y = 0f;
		right.y = 0f;

		forward.Normalize ();
		right.Normalize ();

		desiredMoveDirection = forward * InputZ + right * InputX;

		if (blockRotationPlayer == false) {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (desiredMoveDirection), desiredRotationSpeed);
            
            if(invertControl == false){
            controller.Move(desiredMoveDirection * Time.deltaTime * Velocity);
            }else{
                controller.Move(-desiredMoveDirection * Time.deltaTime * Velocity);
            }
		}
	}
    void InputMagnitude() {
		//Calculate Input Vectors
		InputX = active ? Input.GetAxis ("Horizontal") : 0;
		InputZ = active ? Input.GetAxis ("Vertical") : 0;

		//Calculate the Input Magnitude
		Speed = new Vector2(InputX, InputZ).sqrMagnitude;
        if (Speed > allowPlayerRotation) 
        {
            PlayerMoveAndRotation ();
        }else if (Speed < allowPlayerRotation) 
        {

        }

	}
}
