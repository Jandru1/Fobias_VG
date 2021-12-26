using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protagonist1stPosition2ndScene : MonoBehaviour
{

    public GameObject silla;
    public GameObject Camara;
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
        if (Beginning.isWoman) Character.transform.position = new Vector3(x - 0.4f, 2.2f, z - 0.4f);
        else Character.transform.position = new Vector3(x -0.3f, 2.2f, z);
        float ySilla = silla.transform.eulerAngles.y;
        float xs = Character.transform.rotation.x;
        float zs = Character.transform.rotation.z;

        Character.transform.rotation = Quaternion.Euler(new Vector3(xs, ySilla, zs));

        Camara.transform.position = new Vector3(Camara.transform.position.x + 0.05f, 3.2f, Camara.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
