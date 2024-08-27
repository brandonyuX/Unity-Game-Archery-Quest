using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float Speed =8f;

    public Vector3 Velocity;//for you to see the velocity in the inspector
    Rigidbody rb_;
    // Start is called before the first frame update
    public float lookSpeed = 3;
    private Vector2 rotation = Vector2.zero;
    public Vector3 jumpDir = Vector3.zero;
    public float jumpForce = 3.0f;

    public bool isGrounded;

    void Start()
    {
        rb_ = GetComponent<Rigidbody>();
        jumpDir.y = 2f;
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");//capital V, value from -1 to 1, -1 is back, 1 is forward
        float horizontal = Input.GetAxis("Horizontal");
        bool jump = Input.GetButtonDown("Jump");

        Velocity = rb_.velocity;
        float velocityFromGravity = rb_.velocity.y;

        Velocity = transform.forward * Speed * vertical;//forward direction of the tank
        Velocity += transform.right * Speed * horizontal;
        //use this instead of the 2 lines above if you do not want diagonal movement to be faster 
        //Velocity = (transform.forward * vertical + transform.right * horizontal).normalized * Speed;

        Velocity.y = velocityFromGravity;//add the gravity back to the velocity
        rb_.velocity = Velocity;//set rigidbody velocity to the value we calculated

        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, -15f, 15f);
        transform.eulerAngles = new Vector2(0, rotation.y) * lookSpeed;
        Camera.main.transform.localRotation = Quaternion.Euler(rotation.x * lookSpeed, 0, 0);
        if (jump && isGrounded)
        {
            rb_.AddForce(jumpDir * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }


}



