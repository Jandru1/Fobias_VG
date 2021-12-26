using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitDownNPC : MonoBehaviour
{
    bool Colisionando;
    private Animator animator;
  //  bool sentado = false;
    public GameObject silla;
    public GameObject Character;
  //  public GameObject Camara;

    float mx, my, mz;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Colisionando = false;
        animator.SetBool("isWalking", true);
    //    mx = Camara.transform.position.x;
    //    my = Camara.transform.position.y;
     //   mz = Camara.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (Colisionando)
        {
            float x, y, z;
            z = silla.transform.position.z;
            y = Character.transform.position.y;
            x = silla.transform.position.x;
            // silla.GetComponent<BoxCollider>().enabled = !silla.GetComponent<BoxCollider>().enabled;
            Character.transform.position = new Vector3(x, y, z + 0.25f);

            float ySilla = silla.transform.rotation.y;
            float xs = Character.transform.rotation.x;
            float zs = Character.transform.rotation.z;

            Character.transform.rotation = Quaternion.Euler(new Vector3(xs, ySilla, zs));
       //    mx = Camara.transform.position.x;
         //   mz = Camara.transform.position.z;

          //  Camara.transform.position = new Vector3(Camara.transform.position.x, my - 0.315f, Camara.transform.position.z);

            animator.SetBool("isSitting", true);
            animator.SetBool("isWalking", false);
         //   sentado = true;
        }
        /*
        if (sentado)
        {
            if (Input.GetKey(KeyCode.A))
            {
                float px, py, pz;
                px = Character.transform.parent.position.x;
                py = Character.transform.parent.position.y - 0.8f;
                pz = Character.transform.parent.position.z;

                Character.transform.position = new Vector3(px, py, pz);
                Character.transform.rotation = Character.transform.parent.rotation;

           //     Camara.transform.position = new Vector3(Camara.transform.position.x, my, Camara.transform.position.z);

                animator.SetBool("isSitting", false);
                animator.SetBool("isIdle", true);

                sentado = false;

            }
        }
        */
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Silla")
        {
            Colisionando = true;
        }
    }
   
}
