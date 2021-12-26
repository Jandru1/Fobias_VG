using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protagonist1stPosition : MonoBehaviour
{

    public GameObject silla;
    public GameObject Camara;
    public GameObject Character;
    private Animator animator;

  //  public GameObject Man;
//    public GameObject Woman;

    // Start is called before the first frame update
    void Start()
    {


        animator = GetComponent<Animator>();
        float x, y, z;
        z = silla.transform.position.z;
        y = silla.transform.position.y;
        x = silla.transform.position.x;
        // silla.GetComponent<BoxCollider>().enabled = !silla.GetComponent<BoxCollider>().enabled;
        if (Beginning.isWoman) Character.transform.position = new Vector3(x, -0.05f, z - 0.05f);
        else Character.transform.position = new Vector3(x, 0.05f, z + 0.01f);

        float ySilla = silla.transform.rotation.y;
        float xs = Character.transform.rotation.x;
        float zs = Character.transform.rotation.z;

        Character.transform.rotation = Quaternion.Euler(new Vector3(xs, ySilla, zs));

        Camara.transform.position = new Vector3(Camara.transform.position.x, 1.1f, Camara.transform.position.z);
    
        /*
        animator.SetBool("isIdle", false);
        animator.SetBool("isWalking", false);
        animator.SetBool("isWalkingB", false);
        animator.SetBool("isWalkingR", false);
        animator.SetBool("isWalkingL", false);
        animator.SetBool("isSitting", true);*/

       // sentado = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
