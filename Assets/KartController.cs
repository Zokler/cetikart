﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class KartController : MonoBehaviour
{
    public float speed = 1500f;
    public float rotationSpeed = 12f;

    public WheelJoint2D backWheel;
    public WheelJoint2D frontWheel;

    public Rigidbody2D rb;

    public float movement = 0f;
    public float rotation = 0f;

    private bool canJump;


    public bool item_cohete_fly = false;

    private void Update()
    {
        if (CrossPlatformInputManager.GetButton("Run") || Input.GetKey(KeyCode.D))
            movement = -1 * speed;
        else
            movement = 0;

        if (CrossPlatformInputManager.GetButton("Freno") || Input.GetKey(KeyCode.A))
            movement = 1 * speed;
 

        if ((CrossPlatformInputManager.GetButton("Jump") || Input.GetKeyDown(KeyCode.Space)) && canJump )
        {
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1000f));
        }

        //Si toma el cohete y pulsa el espacio podrá saltar
        if ((CrossPlatformInputManager.GetButton("Jump") || Input.GetKeyDown(KeyCode.Space)) && item_cohete_fly && !canJump)
        {
            StartCoroutine(esperar_milisegundos(.15f));
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300f));
        }
    }

    private void FixedUpdate()
    {
        if (movement == 0f)
        {
            backWheel.useMotor = false;
            frontWheel.useMotor = false;
        }
        else
        {
            backWheel.useMotor = true;
            frontWheel.useMotor = true;

            JointMotor2D motor = new JointMotor2D { motorSpeed = movement, maxMotorTorque = 10000 };
            backWheel.motor = motor;
            frontWheel.motor = motor;
        }

        rb.AddTorque(rotation * rotationSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "grounder")
        {
            canJump = true;
        }
    }

    IEnumerator esperar_milisegundos(float seg)
    {
        yield return new WaitForSeconds(seg);
    }

}
