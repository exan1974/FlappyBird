using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpPower = 1f;
    public float jumpInterval = 0.5f;
    private float jumpCooldown = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        jumpCooldown -= Time.deltaTime;
        bool canJump = jumpCooldown <= 0;

        bool isGameActive = GameManager.Instance.IsGameActive();
        if(canJump && isGameActive)
        {
        bool jumpInput = Input.GetKey(KeyCode.Space);
        if(jumpInput)
        {
            Jump();
        }
        }
        rb.useGravity = isGameActive;
    }

    private void OnTriggerEnter(Collider other)
    {
        bool isSensor = other.gameObject.CompareTag("Sensor");
        if(isSensor)
        {
            GameManager.Instance.score++;
            Debug.Log("Score: " + GameManager.Instance.score);
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
         GameManager.Instance.EndGame();
    }

    private void Jump()
    {
        jumpCooldown = jumpInterval;
            rb.AddForce(new Vector3(0,jumpPower,0), ForceMode.Impulse);

    }
}
