using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // player movement vector and inputs variables
    private float horizontal;
    private float vertical;

    private Vector3 movement;
    private Quaternion rotation = Quaternion.identity;

    // animator of the player gameobject
    private Animator animator;

    public float turnSpeed = 20.0f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxis(InputsTags.horizontalTag);
        vertical = Input.GetAxis(InputsTags.verticalTag);

        movement.Set(horizontal, 0.0f, vertical);
        movement.Normalize();

        // check for the user input
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0.0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0.0f);

        bool isWalking = hasHorizontalInput || hasVerticalInput;
        animator.SetBool(AnimatorTags.isWalkingTag, isWalking);

        // Vector for the direction the player is gonna rotate to
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.deltaTime, 0.0f);

        // create a rotation aiming at the rotation distenation
        rotation = Quaternion.LookRotation(desiredForward);
    }

    private void OnAnimatorMove()
    {
        rb.MovePosition(rb.position + movement * animator.deltaPosition.magnitude);
        rb.MoveRotation(rotation);
    }
}
