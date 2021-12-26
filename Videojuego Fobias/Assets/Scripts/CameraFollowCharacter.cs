using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCharacter : MonoBehaviour
{
    public Camera FPSCamera;
    public float HS;
    public float VS;
    public float velocidad = 3f;

    float h;
    float v;

    private MoverJugador Woman;
    private bool WomanColliding;
    private float WomanVelocidad;
    // Start is called before the first frame update
    void Start()
    {
        Woman = FindObjectOfType<MoverJugador>();
       // Woman = GameObject.FindGameObjectWithTag("Woman");
    }

    // Update is called once per frame
    void Update()
    {
        WomanColliding = Woman.Colisionando;
        WomanVelocidad = Woman.velocidad;
        h = HS * Input.GetAxis("Mouse X");
        v = VS * Input.GetAxis("Mouse Y");
        /*
        transform.Rotate(0, h, 0);
        FPSCamera.transform.Rotate(-v, 0, 0);
        */
        /*
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            if (!WomanColliding)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    transform.position += Vector3.forward * velocidad * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.position += Vector3.left * velocidad * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.position += Vector3.right * velocidad * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.position += Vector3.back * velocidad * Time.deltaTime;
                }
            }
        }*/
    }

}
