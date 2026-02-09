using UnityEngine;
using System;
using Random = UnityEngine.Random;

[RequireComponent(typeof(HingeJoint2D))]
public class FlipperScript : MonoBehaviour
{
    private HingeJoint2D myHingeJoint;
    private JointMotor2D myHingeMotor;
    [SerializeField] private bool left = true;
    [SerializeField] private bool right = false;
    [SerializeField] private float motorSpeed = 15000f;

    private void Awake() {
        myHingeJoint = GetComponent<HingeJoint2D>(); //gets a copy of joint
        myHingeMotor = myHingeJoint.motor; //gets a copy of motor from joint
        myHingeJoint.useMotor = true; //makes sure motor is ON
        if (right)
        {
            motorSpeed = -motorSpeed;
            Debug.Log(motorSpeed);
        }
    }

    private void PlayerInput()
    {
        if(myHingeJoint != null){
            
            if (left){ //LEFT FLIPPERS
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    myHingeMotor.motorSpeed = -motorSpeed; //modifies motor to shoot UP                 
                }
                else
                {
                    myHingeMotor.motorSpeed = motorSpeed; //modifies motor to reset DOWN
                }
                myHingeJoint.motor = myHingeMotor; //assigns back
            }

            if (right){ //RIGHT FLIPPERS
                 if (Input.GetKey(KeyCode.RightShift))
                {
                    myHingeMotor.motorSpeed = -motorSpeed; //modifies motor to shoot UP                 
                }
                else
                {
                    myHingeMotor.motorSpeed = motorSpeed; //modifies motor to reset DOWN
                }
                myHingeJoint.motor = myHingeMotor; //assigns back

            }
        }
    }
    void Update()
    {
        PlayerInput();
    }
}
