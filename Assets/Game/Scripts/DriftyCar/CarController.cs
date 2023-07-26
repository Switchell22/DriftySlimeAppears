using System;
using System.Collections;
using UnityEngine;
using Game.Scripts;

public class CarController : MonoBehaviour
{
    public float MoveSpeed = 50;
    public float MaxSpeed = 15;
    public float Drag = 0.98f;
    public float SteerAngle = 20;
    public float Traction = 1;

    private Vector3 MoveForce;
    public Rigidbody rb;

    public GameDataManager gameDataManager;
    public CombatManager combatManager;

    private bool isCoroutineRunning = false;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

    }



    private void FixedUpdate()
    {
        // Move
        MoveForce += transform.forward * MoveSpeed * Input.GetAxis("Vertical") * Time.fixedDeltaTime;
        rb.velocity = MoveForce * 50 * Time.fixedDeltaTime;
    }



    void Update()
    {
        // Steer
        float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerInput * MoveForce.magnitude * SteerAngle * Time.deltaTime);

        // Drag
        MoveForce *= Drag;

        // Max speed limit
        MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed);

        // Traction
        MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, Traction * Time.deltaTime) * MoveForce.magnitude;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DrawCardPickup") && !isCoroutineRunning)
        {
            StartCoroutine(DrawCards(1)); // Assuming combatManager is correctly assigned and valid
            Destroy(other.gameObject);
        }
    }

    private IEnumerator DrawCards(int amountToDraw)
    {
        isCoroutineRunning = true;

        yield return combatManager.DrawCards(amountToDraw);

        isCoroutineRunning = false;
    }
}
