using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAnimation : MonoBehaviour
{
    private Animator animator;
    bool Colisionando;
    bool sentado = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isIdle", true);
        animator.SetBool("isWalking", false);
        animator.SetBool("isTalking", false);
        animator.SetBool("isWalkingB", false);
        animator.SetBool("isWalkingR", false);
        animator.SetBool("isWalkingL", false);
        Colisionando = false;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("isWalkingB", false);
        animator.SetBool("isWalkingR", false);
        animator.SetBool("isWalkingL", false);
        if (!sentado) animator.SetBool("isIdle", true);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isWalkingL", true);
            animator.SetBool("isWalking", false);
            animator.SetBool("isWalkingB", false);
            animator.SetBool("isWalkingR", false);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isWalking", true);
            animator.SetBool("isWalkingL", false);
            animator.SetBool("isWalkingB", false);
            animator.SetBool("isWalkingR", false);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isWalkingR", true);
            animator.SetBool("isWalking", false);
            animator.SetBool("isWalkingB", false);
            animator.SetBool("isWalkingL", false);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isWalkingB", true);
            animator.SetBool("isWalking", false);
            animator.SetBool("isWalkingL", false);
            animator.SetBool("isWalkingR", false);
        }

        if (Colisionando)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                sentado = true;
            } 
        }
        if (sentado)
        {
            if (Input.GetKey(KeyCode.H))
            {
                sentado = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Floor") && !collision.gameObject.CompareTag("Protagonista"))
        {
            if (collision.gameObject.CompareTag("Silla"))
            {
                Colisionando = true;
          //      Debug.Log(collision.gameObject.tag);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Colisionando = false;
    }
}
