using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitDown : MonoBehaviour
{
    bool Colisionando;
    private Animator animator;
    bool sentado = false;
    private GameObject silla;
    public GameObject Character;
    public GameObject Camara;

    float mx, my, mz;

    //WPActor
    private float speed = 3f;
    private bool WPActor = false;
    public GameObject targetGameObject;
    private Transform target;
    private bool keepwalking;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Colisionando = false;
        if (animator.GetBool("isSitting")) sentado = true;
        animator.SetBool("isIdle", true);
        mx = Camara.transform.position.x;
        my = Camara.transform.position.y;
        mz = Camara.transform.position.z;

        //WPActor
        
        target = targetGameObject.GetComponent<Transform>();
        keepwalking = true;
        // Debug.Log(target.gameObject.name);
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if(WPActor) //Comenzamos con la ruta de WayPoints
        {
            if (keepwalking)
            {
                animator.SetBool("isIdle", false);
                //      animator.SetBool("StandsUp", false);
                animator.SetBool("isWalking", true);
                transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));

                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            }
        }
        else //Aun no hay ruta de waypoints
        {
            if (!sentado)
            {
                mx = Camara.transform.position.x;
                my = Camara.transform.position.y;
                mz = Camara.transform.position.z;
            }
            if (Colisionando) //Chocamos con silla
            {
                if (Input.GetKey(KeyCode.Space))
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


                    Camara.transform.position = new Vector3(Camara.transform.position.x, 1.1f, Camara.transform.position.z);

                    animator.SetBool("isIdle", false);
                    animator.SetBool("isWalking", false);
                    animator.SetBool("isWalkingB", false);
                    animator.SetBool("isWalkingR", false);
                    animator.SetBool("isWalkingL", false);
                    animator.SetBool("isSitting", true);

                    sentado = true;

                }

            } //Todo esto no lo hacemos en el behaviour del la Escena Clase
            if (sentado) //Al principio estamos sentados
            {

                if (Input.GetKey(KeyCode.H))
                {

                    animator.SetBool("isSitting", false);
                    animator.SetBool("StartsSitted", false);
                    animator.SetBool("isIdle", true);

                    StartCoroutine(Wait1Second());

                    sentado = false;

                }
            }
            IEnumerator Wait1Second()
            {
                yield return new WaitForSeconds(1);
                float px, py, pz;
                px = Character.transform.parent.position.x;
                py = Character.transform.parent.position.y - 0.75f;
                pz = Character.transform.parent.position.z;

                Character.transform.position = new Vector3(px, py, pz);
                Character.transform.rotation = Character.transform.parent.rotation;

                float pxc, pyc, pzc;
                pxc = Camara.transform.parent.position.x;
                pyc = 1.5f;
                pzc = Camara.transform.parent.position.z;

                Debug.Log("Camara.transform.parent.position.z = " + Camara.transform.parent.position.z);
                Debug.Log("pzc = " + pzc);
                Debug.Log("mz = " + mz);

                Camara.transform.position = new Vector3(pxc, pyc, pzc);

                StartCoroutine(WPActorCoroutine());

            }

            IEnumerator WPActorCoroutine()
            {
                yield return new WaitForSeconds(3); //Este habra que ponerlo como se deba!!!
                WPActor = true;


            }
        }


    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Floor") && !collision.gameObject.CompareTag("Protagonista"))
        {
            Debug.Log("Colisiono con algo");
            if (collision.gameObject.CompareTag("Silla"))
            {
                silla = collision.gameObject;
                Colisionando = true;
            }

            if (collision.gameObject.tag == "WayPoints")
            {
                //       Debug.Log("Choco con WP");
                if (target.gameObject != collision.gameObject.GetComponent<WayPoints>().nextpoint.gameObject)
                {
                    Debug.Log("Choco con WP y es el objeto " + target.name + " y collision = " + collision.gameObject.name);
                    target = collision.gameObject.GetComponent<WayPoints>().nextpoint;
                    keepwalking = true;
                }
                else keepwalking = false;

                if (collision.gameObject.name == "WPEnd")
                {
                    // Debug.Log("Entro al WPEnd");
                    //     Character.transform.Rotate(Quaternion.Euler(new Vector3(0, -90f, 0)));
                    Character.transform.rotation = Quaternion.Euler(new Vector3(0, -180f, 0));
                    animator.SetBool("isWalking", false);
                    animator.SetBool("isTalking", true);
                    keepwalking = false;
                }
            }
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Dejo de colisionar");
        Colisionando = false;
    }

}
