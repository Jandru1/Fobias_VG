using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public GameObject panel;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //  StartCoroutine(A());
        animator = panel.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator Wait1Second()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("BarScene");
    }
    private void OnCollisionEnter(Collision collision)
    {
      //  Debug.Log("Choco con algo");
        if (collision.gameObject.tag == "Woman" || collision.gameObject.tag == "Man")
        {
            animator.SetBool("FadeOut", false);
            animator.SetBool("FadeIn", true);
            StartCoroutine(Wait1Second());
        }
    }
    /*
    IEnumerator A()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("BarScene");
    }*/
}
