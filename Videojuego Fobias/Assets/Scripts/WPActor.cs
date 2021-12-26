using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPActor : MonoBehaviour
{
    float speed = 2f;
    public GameObject targetGameObject;
    private Transform target;
    private GameObject Objeto;
    private bool keepwalking;
    Animator animator;
    bool ProtagonistHasDoneBothSituations = false;
    Collision col;
    UI SayThat;
    // Start is called before the first frame update
    void Start()
    {
        if (Beginning.isWoman)
        {
            SayThat = GameObject.FindGameObjectWithTag("Woman").GetComponent<UI>();
        }
        else
        {
            SayThat = GameObject.FindGameObjectWithTag("Man").GetComponent<UI>();
        }
        StartCoroutine(WaitALittle());
        animator = GetComponent<Animator>();
        target = targetGameObject.GetComponent<Transform>();
        Objeto = GetComponent<GameObject>();
        keepwalking = true;
      //  Debug.Log(target.gameObject.name);
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }

    // Update is called once per frame
    void Update()
    {

        ProtagonistHasDoneBothSituations = Behaviours2ndScene.HasDoneBothSituations;
       // ProtagonistHasDoneBothSituations = true;
        if (keepwalking & ProtagonistHasDoneBothSituations)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isIdle", false);
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));

            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }

        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdle", true);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        col = collision;
       // Debug.Log("Me choco con " + collision.gameObject.name);
        if (collision.gameObject.tag == "WayPoints")
        {
           // Debug.Log("Choco con WP");
            if (target.gameObject != collision.gameObject.GetComponent<WayPoints>().nextpoint.gameObject)
            {
                Debug.Log("Entreo aqui");
                target = collision.gameObject.GetComponent<WayPoints>().nextpoint;
                keepwalking = true;
            }

            else
            {
                keepwalking = false;
                transform.rotation = Quaternion.Euler(new Vector3(0, 270f, 0));
            }


            if (collision.gameObject.name == "WPStop")
            {
                Debug.Log("ES WPSTOP");
                keepwalking = false;
            }
            else if (collision.gameObject.name == "WPStop2")
            {
                Debug.Log("ES WPSTOP2");
                keepwalking = false;
            }
            //    transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        }
    }

    IEnumerator WaitALittle()
    {
        yield return new WaitUntil(() => Behaviours2ndScene.HasDoneBothSituations == true);
        ProtagonistHasDoneBothSituations = true;
    }

    public void TheyCalledMe()
    {
     //   target = col.gameObject.GetComponent<WayPoints>().nextpoint;
        keepwalking = true;
    }

    public void AskedForBill()
    {
        StartCoroutine(GoForBill());
    }
    IEnumerator GoForBill()
    {
        SayThat.SayThat("Camarero: ¡Enseguida!");
        yield return new WaitForSeconds(3);
        keepwalking = true;
    }


}
