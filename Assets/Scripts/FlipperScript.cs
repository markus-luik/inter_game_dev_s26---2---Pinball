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
    [SerializeField] private float motorSpeedUP = 15000f;
    [SerializeField] private float motorSpeedDOWN = 1000f;

    private AudioSource audioSource;
    private bool keyBeingPressed = false;
    private bool isUp = false;

    private void Awake() {
        myHingeJoint = GetComponent<HingeJoint2D>(); //gets a copy of joint
        myHingeMotor = myHingeJoint.motor; //gets a copy of motor from joint
        myHingeJoint.useMotor = true; //makes sure motor is ON
        if (right)
        {
            motorSpeedUP = -motorSpeedUP;
            motorSpeedDOWN = -motorSpeedDOWN;
            Debug.Log(motorSpeedUP);
            Debug.Log(motorSpeedDOWN);
            //gives motor starting down movement
            myHingeMotor.motorSpeed = motorSpeedDOWN;
            myHingeJoint.motor = myHingeMotor; 
        }
        audioSource = GetComponent<AudioSource>(); //Gets audio source
    }

    private void PlaySound()
    {
        if (audioSource != null && audioSource.clip != null)
            {
                audioSource.PlayOneShot(audioSource.clip); //plays the clip assigned
            }else{
                Debug.Log("AudioSource or AudioResource is missing on flipper!");
                return;
            }
    }

    private void PlayerInput()
    {
        if(myHingeJoint != null){

            //---Checking Input---
            if (left)
            {
                keyBeingPressed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
            }else if (right)
            {
                keyBeingPressed = Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
            }

            //---Direction State Change---
            if(keyBeingPressed && !isUp)
            {
                //Flipper goes UP
                myHingeMotor.motorSpeed = -motorSpeedUP; //temp hingejoint given speed
                myHingeJoint.motor = myHingeMotor; //temp hingejoint applied to real hingejoint
                //Sound playing
                PlaySound();
                isUp = true;
            }else if(!keyBeingPressed && isUp){
                //Flipper goes DOWN
                myHingeMotor.motorSpeed = motorSpeedDOWN;
                myHingeJoint.motor = myHingeMotor; 
                //Sound playing
                // PlaySound();
                isUp = false;
            }
        }else{
            Debug.Log("HingeJoint2D is missing on flipper!");
            return;
        }
    }
    void FixedUpdate()
    {
        PlayerInput();
    }
}
