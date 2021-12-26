using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaraBehaviour : MonoBehaviour
{
    Animator animator;
    public GameObject Character;
    public Transform transf;
    UI SayThat;

    float x;
    float y;
    float z;
    int i = 0;
    int j = 0;

    float speed = 1f;
    public GameObject targetGameObject;
    private Transform target;
    private GameObject Objeto;
    private bool keepwalking;

    private bool firstdone = false;


    // Start is called before the first frame update
    void Start()
    {
        if (Beginning.isWoman)
        {
            SayThat = GameObject.FindGameObjectWithTag("Woman").GetComponent<UI>();
        }
        else SayThat = GameObject.FindGameObjectWithTag("Man").GetComponent<UI>();

        target = targetGameObject.GetComponent<Transform>();
        Objeto = GetComponent<GameObject>();
        keepwalking = true;
        //  Debug.Log(target.gameObject.name);
       // transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));


        animator = GetComponent<Animator>();
        x = transf.position.x;
        y = transf.position.y;
        z = transf.position.z;
        StartCoroutine(Coroutine1());

    }

    // Update is called once per frame
    void Update()
    {
        if (firstdone)
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
    }

    IEnumerator Coroutine1()
    {
        //EMPIEZO AQUI
        yield return new WaitForSeconds(23);//23
        //Debug.Log("Ya han pasado 20s");
        animator.SetBool("StartsSitted", false);
        animator.SetBool("isSitting", false);
        animator.SetBool("StandsUp", true);
        StartCoroutine(Coroutine2());


    }
    IEnumerator Coroutine2()
    {
        yield return new WaitForSeconds(1);
        // Debug.Log("entro despues de esperar");
        // Debug.Log(x + " " + y + " " + z);
        Character.transform.position = new Vector3(x, y, z);
        Character.transform.Rotate(new Vector3(0, 180, 0));
        animator.SetBool("StandsUp", false);
        animator.SetBool("SaysHi", true);
    //    StartCoroutine(justsayhi());
        yield return new WaitForSeconds(1);
        StartCoroutine(TalkCoroutine());

    //    yield return new WaitForSeconds(2);
        animator.SetBool("SaysHi", false);
        animator.SetBool("isIdle", true);
        ++i;
        firstdone = true;
    }

    IEnumerator justsayhi()
    {
        SayThat.SayThat("csilycbsdjcscke");
        yield return new WaitForSeconds(3);
    }

    IEnumerator TalkCoroutine()
    {
        animator.SetBool("isTalking", true);
        SayThat.SayThat("Sara: ¡Hola! ¿Qué tal?");
        yield return new WaitForSeconds(3);
        SayThat.SayThat("Sara: Yo soy Sara. Veniros y así nos vamos conociendo!");
        yield return new WaitForSeconds(3);
        animator.SetBool("isTalking", false);
        ++j;
    }

    IEnumerator CoroutineColision(Collision collision)
    {

        //Debug.Log("Me choco");
        if (collision.gameObject.tag == "WayPointsW3")
        {

            //  Debug.Log("Choco con WP");
            if (target.gameObject != collision.gameObject.GetComponent<WayPoints>().nextpoint.gameObject)
            {
                //  Debug.Log("Entro aqui");
                target = collision.gameObject.GetComponent<WayPoints>().nextpoint;
                keepwalking = true;
            }
            else keepwalking = false;

            if (collision.gameObject.name == "WPStop")
            {
                // Debug.Log("Entro al WPEnd");
                //     Character.transform.Rotate(Quaternion.Euler(new Vector3(0, -90f, 0)));
                keepwalking = false;
                Character.transform.rotation = Quaternion.Euler(new Vector3(0, -180f, 0));
                animator.SetBool("isWalking", false);
                animator.SetBool("isIdle", true);
                yield return new WaitForSeconds(10);
                keepwalking = true;
            }
            // else transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(CoroutineColision(collision));
    }


}
