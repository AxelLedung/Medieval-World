using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    Rigidbody playerRigidbody;
    public float moveSpeed;

    public Transform playerOrientation;

    float xInput;
    float yInput;

    Vector3 moveDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.freezeRotation = true;
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }
    void ProcessInputs()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }
    void MovePlayer()
    {
        moveDirection = playerOrientation.forward * yInput + playerOrientation.right * xInput;
        playerRigidbody.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

}
