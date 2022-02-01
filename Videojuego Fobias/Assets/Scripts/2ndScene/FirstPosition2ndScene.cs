using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPosition2ndScene : MonoBehaviour
{

    public GameObject silla;
   // public GameObject Camara;
    public GameObject Character;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        float x, y, z;
        z = silla.transform.position.z;
        y = silla.transform.position.y;
        x = silla.transform.position.x;
        // silla.GetComponent<BoxCollider>().enabled = !silla.GetComponent<BoxCollider>().enabled;
        //   Debug.Log("zSilla = " + zSilla + " xSilla = " + silla.transform.eulerAngles.x + " ySilla = "+ silla.transform.eulerAngles.y);
        float ys = silla.transform.eulerAngles.y;
        Debug.Log("Con ys = " + ys + " el caracter es " + Character.name);

        if (ys == 90) //Carlos
        {
            Character.transform.position = new Vector3(x + 0.4f, 2.2f, z);

        }
        else if (ys == 0) //Sara
        {
            Character.transform.position = new Vector3(x, 2.2f, z+0.4f);

        }
        else if (ys == 180) //Alba
        {
            Character.transform.position = new Vector3(x,2.2f, z-0.4f);

        }
        float xs = Character.transform.rotation.x;
        float zs = Character.transform.rotation.z;

       // Debug.Log(Character.name + " ys = " + ys + ", zSilla = " + zSilla + " xSilla = " + silla.transform.eulerAngles.x + " ySilla = " + silla.transform.eulerAngles.y + " la silla es: " + silla.name);

        Character.transform.rotation = Quaternion.Euler(new Vector3(xs, ys, zs));

 //       Camara.transform.position = new Vector3(Camara.transform.position.x, 1.1f, Camara.transform.position.z);

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
