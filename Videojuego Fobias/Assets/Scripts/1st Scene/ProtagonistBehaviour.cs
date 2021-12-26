using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtagonistBehaviour : MonoBehaviour
{

    //bool Colisionando;
    private Animator animator;
   // bool sentado = false;
    private GameObject silla;
    public GameObject Character;
    public GameObject Camara;

    float mx, my, mz;

    //WPActor
    private float speed = 1f;
    private bool WPActor = false;
    public GameObject targetGameObject;
    private Transform target;
    private bool keepwalking;
    Vector3 v3;
    // Start is called before the first frame update
    public UI UIScript;

    void Start()
    {
        animator = GetComponent<Animator>();
     //   Colisionando = false;
    //    if (animator.GetBool("isSitting")) sentado = true;
     //   animator.SetBool("isIdle", true);
        mx = Camara.transform.position.x;
        my = Camara.transform.position.y;
        mz = Camara.transform.position.z;

        //WPActor
        target = targetGameObject.GetComponent<Transform>();
        keepwalking = true;
        StartCoroutine(CoroutineStandUp());
    //    StartCoroutine(Spacebar());

        // Debug.Log(target.gameObject.name);
        //   transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (WPActor) //Comenzamos con la ruta de WayPoints
        {
            if (keepwalking)
            {
                v3.x = target.position.x;
                v3.y = transform.position.y;
                v3.z = target.position.z;
           //     Debug.Log("Vector 3 = " + v3);

                var targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);

                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);

                //  transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));

                animator.SetBool("isIdle", false);
                //      animator.SetBool("StandsUp", false);
                animator.SetBool("isWalking", true);
         //       Debug.Log("Mi target es " + target.name);
            }

        }
    }

    public void ActiveSpaceBar()
    {
        UIScript.ActiveSpacebar();
    }

    IEnumerator Spacebar()
    {
        yield return new WaitForSeconds(45);
     //   Debug.Log("Mando a spacebar");
        UIScript.ActiveSpacebar();
    }
    IEnumerator CoroutineStandUp()
    {
        yield return new WaitForSeconds(36);//36
        animator.SetBool("isSitting", false);
        animator.SetBool("StartsSitted", false);
        animator.SetBool("StandsUp", true);

        yield return new WaitForSeconds(1);
        animator.SetBool("StandsUp", false);
        animator.SetBool("isIdle", true);
        yield return new WaitForSeconds(0.1f);

        //   sentado = false;

        float px, py, pz;
        px = Character.transform.parent.position.x;
        py = Character.transform.parent.position.y - 0.75f;
        pz = Character.transform.parent.position.z;

        Character.transform.position = new Vector3(px, py,pz);
       Character.transform.rotation = Character.transform.parent.rotation;

        float pxc, pyc, pzc;
        pxc = Camara.transform.parent.position.x;
        pyc = 1.5f;
        pzc = Camara.transform.parent.position.z;

     //   Debug.Log("Camara.transform.parent.position.z = " + Camara.transform.parent.position.z);
       // Debug.Log("pzc = " + pzc);
        //Debug.Log("mz = " + mz);

        Camara.transform.position = new Vector3(pxc, pyc, pzc);

      //  yield return new WaitForSeconds(3); //Este habra que ponerlo como se deba!!!
        WPActor = true;
     //   Debug.Log("Hasta aqui okey");
        animator.SetBool("isIdle", false);
    }


    IEnumerator CoroutineColision(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Floor") && !collision.gameObject.CompareTag("Protagonista"))
        {
         //   Debug.Log("Colisiono con algo");
            if (collision.gameObject.CompareTag("Silla"))
            {
                silla = collision.gameObject;
               // Colisionando = true;
            }

            if (collision.gameObject.tag == "WayPointsProtagonist")
            {
                //       Debug.Log("Choco con WP");
                if (target.gameObject != collision.gameObject.GetComponent<WayPoints>().nextpoint.gameObject)
                {
              //      Debug.Log("Entreo aqui");
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

                else if (collision.gameObject.name == "WP3")
                {
               //     Debug.Log("WP3");
                    keepwalking = false;
                    animator.SetBool("isWalking", false);
                    animator.SetBool("isIdle", true);
                    yield return new WaitForSeconds(2);
                    animator.SetBool("isWalking", true);
                    animator.SetBool("isIdle", false);
                    keepwalking = true;

                }
            }
        }
        yield return new WaitForSeconds(0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(CoroutineColision(collision));
      
    }
}
