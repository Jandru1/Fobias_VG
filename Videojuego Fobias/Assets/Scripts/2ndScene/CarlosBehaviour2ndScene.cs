using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarlosBehaviour2ndScene : MonoBehaviour
{
    UI SayThat;
    public static bool isWoman;
    // Start is called before the first frame update
    void Start()
    {
        isWoman = Beginning.isWoman;
        //isWoman = Beginning.isWoman;
        if (isWoman)
        {
            GameObject.FindGameObjectWithTag("Man").SetActive(false);
            SayThat = GameObject.FindGameObjectWithTag("Woman").GetComponent<UI>();
        }
        else
        {
            //Debug.Log("Entro aqui");
            GameObject.FindGameObjectWithTag("Woman").SetActive(false);
            SayThat = GameObject.FindGameObjectWithTag("Man").GetComponent<UI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
