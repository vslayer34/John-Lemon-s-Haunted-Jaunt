using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // player movement vector and inputs variables
    private float horizontal;
    private float vertical;

    private Vector3 movement;

    // animator of the player gameobject
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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
    }
}
