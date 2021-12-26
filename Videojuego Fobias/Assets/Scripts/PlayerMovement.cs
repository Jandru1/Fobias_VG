using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    Animator animator;
    public float speed = 3f;

    Vector3 velocity;
    public float gravity = -9.8f;

    // Start is called before the first frame update
    void Start()
    {
        if(CarlosBehaviour2ndScene.isWoman)
        {
            animator = GameObject.FindGameObjectWithTag("Woman").GetComponent<Animator>();
            Debug.Log(animator.name);
        }
        else animator = GameObject.FindGameObjectWithTag("Man").GetComponent<Animator>(); //Debug.Log(animator.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (!animator.GetBool("isSitting"))
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
     
    }
}
