using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarlosBehaviour : MonoBehaviour
{
    Animator animator;
    public GameObject Character;
    public Transform transf;
    UI SayThat;

    float x;
    float y;
    float z;
    int i = 0;

    public float speed = 1f;
    public GameObject targetGameObject;
    private Transform target;
    private GameObject Objeto;
    private bool keepwalking;

    private float j = 0;

    private bool firstdone = false;

    bool isWoman = true;

    // Start is called before the first frame update
    void Start()
    {
        if (Beginning.isWoman)
        {
            GameObject.FindGameObjectWithTag("Man").SetActive(false);
            SayThat = GameObject.FindGameObjectWithTag("Woman").GetComponent<UI>();
        }
        else
        {
            isWoman = false;
            GameObject.FindGameObjectWithTag("Woman").SetActive(false);
            SayThat = GameObject.FindGameObjectWithTag("Man").GetComponent<UI>();
        }
        target = targetGameObject.GetComponent<Transform>();
        Objeto = GetComponent<GameObject>();
        keepwalking = true;
        //  Debug.Log(target.gameObject.name);
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));


        animator = GetComponent<Animator>();
        x = transf.position.x;
        y = transf.position.y;
        z = transf.position.z;
        StartCoroutine(Coroutine1());

    }

    // Update is called once per frame
    void Update()
    {
        if(firstdone)
        {
            if (keepwalking)
            {
            //    Debug.Log("Camino hacia " + target.name);
                animator.SetBool("isIdle", false);
          //      animator.SetBool("StandsUp", false);
                animator.SetBool("isWalking", true);
                transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
                if(j == 0) StartCoroutine(TalkWhileWalking());
            }
        }
    }

    IEnumerator Coroutine1()
    {
        //EMPIEZO AQUI
        yield return new WaitForSeconds(16);
        animator.SetBool("StartsSitted", false);
        animator.SetBool("StandsUp", true);
        StartCoroutine(Coroutine2());
    }

    IEnumerator TalkWhileWalking()
    {
        animator.SetBool("isTalking", true);
        if(isWoman) SayThat.SayThat("Carlos: ¡Hola chicas! Soy Carlos ¿Qúe tal la primera clase?");
        else SayThat.SayThat("Carlos: ¡Hola chicos! Soy Carlos ¿Qúe tal la primera clase?");
        yield return new WaitForSeconds(3);
        SayThat.SayThat("Carlos: ¿Os apuntáis a tomar algo ahora entre clase y clase?");
        yield return new WaitForSeconds(3);
        animator.SetBool("isTalking", false);
        ++j;
    }

    IEnumerator Coroutine2()
    {
        yield return new WaitForSeconds(1);
        // Debug.Log("entro despues de esperar");
       // Debug.Log(x + " " + y + " " + z);
        animator.SetBool("StandsUp", false);
        animator.SetBool("isIdle", true);
        Character.transform.position = new Vector3(x, y, z);
        Character.transform.Rotate(new Vector3(0, 180, 0));
        ++i;
        firstdone = true;
    }

    IEnumerator CoroutineColision(Collision collision)
    {
        if (collision.gameObject.tag == "WayPointsM2")
        {
            //  Debug.Log("Choco con WP");
            if (target.gameObject != collision.gameObject.GetComponent<WayPoints>().nextpoint.gameObject)
            {
              //  Debug.Log("Change Target to " + collision.gameObject.GetComponent<WayPoints>().nextpoint);
                //  Debug.Log("Entro aqui");
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
                animator.SetBool("isIdle", true);
                keepwalking = false;
            }

            if (collision.gameObject.name == "WPStop")
            {
            //    Debug.Log("WPStop");
                keepwalking = false;
                Character.transform.rotation = Quaternion.Euler(new Vector3(0, -135f, 0));
                animator.SetBool("isWalking", false);
                animator.SetBool("isIdle", true);
                yield return new WaitForSeconds(18);
                animator.SetBool("FirstWalkDone", true);        
                keepwalking = true;
            }
            // else transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        }
    }
    private void OnCollisionEnter(Collision c)
    {
        StartCoroutine(CoroutineColision(c));
        //Debug.Log("Me choco");
    }

}
