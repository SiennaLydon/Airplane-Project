using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float throttleIncrement = 0.1f; // how much the throttle changes per input

    public float maxThrust = 200f; // maximum thrust value

    public float responsiveness = 10f; // how responsive the plane is to input


   private float throttle; // throttle value of the plane
   private float roll; // rolling left and right
   private float pitch; // tilting up and down
   private float yaw; // turning left and right

   private float responseModifier // value that modifies the responsiveness of the plane based on its mass
   {
    get
    {
        return (rb.mass / 10f) *responsiveness; 
    }
   }

   Rigidbody rb;

   private void Awake()
   {
     rb = GetComponent<Rigidbody>();
   }

   private void HandleInputs()
   {
    //set rotaional values from our axis inputs
    roll = Input.GetAxis("Roll");
    pitch = Input.GetAxis("Pitch");
    yaw = Input.GetAxis("Yaw");


    //Handle throttle value being sure to clamp it between 0 and 100
    if (Input.GetKey(KeyCode.Space)) throttle += throttleIncrement;
    else if (Input.GetKey(KeyCode.LeftControl)) throttle -= throttleIncrement;
    throttle = Mathf.Clamp(throttle, 0f, 100f);

   }

   private void Update()
   {
    HandleInputs();
   }

   private void FixedUpdate()
   {
    //Apply forces to the plane
        rb.AddForce(transform.forward * maxThrust * throttle); 
        rb.AddTorque(transform.right * yaw * responseModifier); 
        rb.AddTorque(transform.forward * pitch * responseModifier);
        rb.AddTorque(transform.up * roll * responseModifier);


   }


}