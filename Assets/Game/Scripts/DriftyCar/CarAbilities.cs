using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarAbilities : MonoBehaviour
{
    public CarController carController;

    public float dashSpeed;
    public float dashTime;
    public float dashCooldownTime;
    private float defaultMoveSpeed;

    private bool dashCooldown = false;

    public ParticleSystem dashParticle;

    void Start()
    {
        carController = GetComponent<CarController>();

        defaultMoveSpeed = carController.MoveSpeed;

        //dashParticle = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        // Dash ability on left shift
        if (Input.GetKeyDown("left shift"))
        {
            if (dashCooldown == false)
            {

                StartCoroutine(Dash());
                Invoke("ResetDashCooldown", dashCooldownTime);
                dashCooldown = true;

            }

        }
    }



    // Dash
    IEnumerator Dash()
    {
        float startTime = Time.time;

        while (Time.time < startTime + dashTime)
        {
            carController.MoveSpeed = dashSpeed;
            //transform.Translate(Vector3.forward * dashSpeed);
            dashParticle.Play();
            yield return null;
        }
        carController.MoveSpeed = defaultMoveSpeed;
    }


    // Reset dash cooldown
    void ResetDashCooldown()
    {
        dashCooldown = false;
    }
}