using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverJugador : MonoBehaviour
{
    Animator animator;
    public float velocidad = 3f;
    public float rotationSpeed = 720;
    private int Wx;
    private int Wy;
    private int Wz;

    public bool Colisionando = false;
 //   private int x = 0;
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isIdle", true);
        animator.SetBool("isWalking", false);
    //    animator.SetBool("isTalking", false);

    }

    // Update is called once per frame
    void Update()
    {
        if (!Colisionando)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
             {
                if (animator.GetBool("isTalking")) animator.SetBool("isTalking", false);
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.position += Vector3.left * velocidad * Time.deltaTime;
                    Camera.transform.position += Vector3.left * velocidad * Time.deltaTime;
                    animator.SetBool("isIdle", false);
                    animator.SetBool("isWalking", true);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.position += Vector3.right * velocidad * Time.deltaTime;
                    Camera.transform.position += Vector3.right * velocidad * Time.deltaTime;
                    animator.SetBool("isIdle", false);
                    animator.SetBool("isWalking", true);
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    transform.position += Vector3.forward * velocidad * Time.deltaTime;
                    Camera.transform.position += Vector3.forward * velocidad * Time.deltaTime;
                    animator.SetBool("isIdle", false);
                    animator.SetBool("isWalking", true);
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.position += Vector3.back * velocidad * Time.deltaTime;
                    Camera.transform.position += Vector3.back * velocidad * Time.deltaTime;
                    animator.SetBool("isIdle", false);
                    animator.SetBool("isWalking", true);
                }
            }
            else if (Input.GetKey(KeyCode.AltGr))
            {
                if (animator.GetBool("isIdle"))
                {
                    animator.SetBool("isIdle", false);
                }
                else if (animator.GetBool("isWalking"))
                {
                    animator.SetBool("isWalking", false);
                }
                animator.SetBool("isTalking", true);
            }
            else
            {
                animator.SetBool("isIdle", true);
                animator.SetBool("isWalking", false);
              //  animator.SetBool("isTalking", false);
            }
        }
        else
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isWalking", false);
          //  animator.SetBool("isTalking", false);
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        if(movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        
    //   Debug.Log(Colisionando);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Floor"))
        {
            Colisionando = true;
            if (Colisionando) Debug.Log(collision.gameObject.tag);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Colisionando = false;
        Debug.Log(Colisionando);
    }
}
