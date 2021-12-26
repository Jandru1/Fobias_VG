using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoAndTalk : MonoBehaviour
{
    public GameObject Character;
    bool Colisionando;
    private Animator animator;
    private GameObject WaypointColisionando;
    // Start is called before the first frame update
    void Start()
    {
        //Character = GetComponent<GameObject>();
        animator = GetComponent<Animator>();
        Colisionando = false;
        animator.SetBool("isWalking", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Colisionando)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isTalking", true);

            float x, y, z;
            z = WaypointColisionando.transform.position.z;
            y = Character.transform.position.y;
            x = WaypointColisionando.transform.position.x;
            // silla.GetComponent<BoxCollider>().enabled = !silla.GetComponent<BoxCollider>().enabled;
            Character.transform.position = new Vector3(x, y, z);

            float xs = Character.transform.rotation.x;
            float zs = Character.transform.rotation.z;
            Character.transform.rotation = Quaternion.Euler(new Vector3(xs, -180f, zs));
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "WayPoints")
        {
            //   Debug.Log("Entra Trigger toTalk");
            Colisionando = true;
            WaypointColisionando = collision.gameObject;
        }
    }

}
