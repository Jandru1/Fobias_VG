using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbaBehaviour : MonoBehaviour
{
    bool waited = false;
    Animator animator;

    UI UISayThat;

    //WPA
    float speed = 1f;
    public GameObject targetGameObject;
    private Transform target;
    private GameObject Objeto;
    private bool keepwalking;
    public GameObject Character;
    public Transform transf;
    float x, y, z;

    ProtagonistBehaviour ProtaBehaviourScript;
 //   private float j = 0;

 //   private bool firstdone = false;

    // Start is called before the first frame update
    void Start()
    {

        if (Beginning.isWoman)
        {
            UISayThat = GameObject.FindGameObjectWithTag("Woman").GetComponent<UI>();
            ProtaBehaviourScript = GameObject.FindGameObjectWithTag("Woman").GetComponent<ProtagonistBehaviour>();
        }
        else
        {
            UISayThat = GameObject.FindGameObjectWithTag("Man").GetComponent<UI>();
            ProtaBehaviourScript = GameObject.FindGameObjectWithTag("Man").GetComponent<ProtagonistBehaviour>();
        }
        target = targetGameObject.GetComponent<Transform>();
        Objeto = GetComponent<GameObject>();
        keepwalking = true;
        animator = GetComponent<Animator>();
        StartCoroutine(Coroutine1());

        x = transf.position.x;
        y = transf.position.y;
        z = transf.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if(waited)
        {
            if (keepwalking)
            {
              //  Debug.Log("Camino hacia " + target.name);
                animator.SetBool("isIdle", false);
                //      animator.SetBool("StandsUp", false);
                animator.SetBool("isWalking", true);
                transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
          //      if (j == 0) StartCoroutine(TalkWhileWalking());
            }
        }
    }

    IEnumerator Coroutine1()
    {
    //    Debug.Log("Voy a esperar");
        yield return new WaitForSeconds(5);
       // Debug.Log("Ya han pasado 5s");
        animator.SetBool("isSitting", false);
        animator.SetBool("isTalkingSitted", true);
        UISayThat.SayThat("Alba: ¡Madre mía, es el primer día de clase y ya nos han puesto trabajos");
        yield return new WaitForSeconds(3);
        UISayThat.SayThat("Alba: y nos han dado fechas de exámenes! Ya me habían dicho que ");
        yield return new WaitForSeconds(3);
        UISayThat.SayThat("Alba: la universidad es complicada pero me esperaba un inicio ");
        yield return new WaitForSeconds(3);
        UISayThat.SayThat("Alba: más tranquilo. ¡Qué nerviosa me he puesto!");
        yield return new WaitForSeconds(3);
        StartCoroutine(Coroutine2());
      
    }
    IEnumerator Coroutine2()
    {
        //waited = true;
        yield return new WaitForSeconds(1);
        //     Debug.Log("Y 5s mas");
        animator.SetBool("isSitting", true);
        animator.SetBool("isTalkingSitted", false);
        yield return new WaitForSeconds(15);
        animator.SetBool("isSitting", false);
        animator.SetBool("isTalkingSitted", true);
        UISayThat.SayThat("Alba: ¡Venga vale! Vamos");
        yield return new WaitForSeconds(3);
        animator.SetBool("isSitting", true);
        animator.SetBool("isTalkingSitted", false);
        yield return new WaitForSeconds(1);
        animator.SetBool("isSitting", false);
        animator.SetBool("StandsUp", true);
        yield return new WaitForSeconds(1);

        animator.SetBool("StandsUp", false);
        animator.SetBool("isIdle", true);
        Character.transform.position = new Vector3(x, y, z);
        waited = true;
    }

    IEnumerator CoroutineColision(Collision collision)
    {

        //Debug.Log("Me choco");
        if (collision.gameObject.tag == "WayPointsW2")
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
                yield return new WaitForSeconds(15);
                keepwalking = true;
            }

            if (collision.gameObject.name == "WP4")
            {
                StartCoroutine(TalkDuringWalk());
                //animator.SetBool("isTalking", true);

            }
            // else transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(CoroutineColision(collision));
    }
    
    IEnumerator TalkDuringWalk()
    {
        animator.SetBool("isTalking", true);
        UISayThat.SayThat("Alba: Me alegro de poder conocer gente el primer día. Por cierto, ");
        yield return new WaitForSeconds(3);
        UISayThat.SayThat("Alba: soy Alba, que antes con los nervios no me he presentado. ");
        yield return new WaitForSeconds(3);
        animator.SetBool("isTalking", false);
        Debug.Log("En el sscript de alba el portabehaviour es: " + ProtaBehaviourScript.name);
        ProtaBehaviourScript.ActiveSpaceBar();
    }

}
