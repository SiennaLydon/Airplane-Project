using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BetterPlane : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] TextMeshProUGUI hud;


    [Header("Plane Stats")]
    [Tooltip("How much the throttle increases or decreases when pressing the throttle keys")]
    public float throttleIncrement = 0.1f;
    [Tooltip("Maximum engine thrust when at 100% throttle")]
    public float maxThrust = 200f;
    [Tooltip("How responsive the plane is when rolling, pitching and yawing.")]
    public float responsiveness = 10f;
    [Tooltip("How much lift force the plane makes as it goes faster")]
    public float lift = 135f;

    private float throttle; // 
    private float roll; // 
    private float pitch; // 
    private float yaw; // 

    void Start()
    {
        Physics.gravity = new Vector3(0, -9.81f, 0); // Default gravity
    }

// 
private float ResponseModifier 
{
    get {   
        return (rb.mass / 10f) * responsiveness;
    }
}


private void Awake() 
{
  rb = GetComponent<Rigidbody>();
}


private void HandleInputs() {

    // 
    roll = Input.GetAxis("Roll");
    pitch = Input.GetAxis("Pitch");
    yaw = Input.GetAxis("Yaw");


    // 
    if (Input.GetKey(KeyCode.Space)) throttle += throttleIncrement;
    else if (Input.GetKey(KeyCode.LeftControl)) throttle -= throttleIncrement;
    //else if (Input.GetKeyDown(KeyCode.X)) throttle = 0f;
   // else if (Input.GetKeyDown(KeyCode.Z)) throttle= 100f;

    //clamps the throttle so it doesnt go below 0 or above 100
    throttle = Mathf.Clamp(throttle, 0f, 100f);
}

private void Update()
{
    HandleInputs();
   UpdateHUD();
}

private void FixedUpdate() {

    //applying force to the plane
    rb.AddForce(-transform.right * maxThrust * throttle);
    rb.AddTorque(transform.up * yaw * ResponseModifier);
    rb.AddTorque(transform.right * pitch * ResponseModifier);
    rb.AddTorque(transform.forward * roll * ResponseModifier);
    rb.AddForce(Vector3.up * rb.linearVelocity.magnitude * lift);
}

private void UpdateHUD() {

        
    hud.text = "Throttle: " + throttle.ToString("F0") + "%\n";
     hud.text += "Airspeed: " + (rb.linearVelocity.magnitude * 3.6f).ToString("F0") + "mph\n";
    hud.text += "Altitude: " + transform.position.y.ToString("F0") + " m";

        
   }
   
}
