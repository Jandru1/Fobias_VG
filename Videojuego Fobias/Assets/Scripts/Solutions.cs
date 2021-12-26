using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solutions : MonoBehaviour
{
    private GameObject Woman;
    public static bool PresentedHerself = false;
    public static bool CalledTheWairtress = false;
    // Start is called before the first frame update
    void Start()
    {
        if(Beginning.isWoman) Woman = GameObject.FindGameObjectWithTag("Woman");
        else Woman = GameObject.FindGameObjectWithTag("Man");
       // PresentedHerself = Woman.GetComponent<UI>().ClickedSpacebarPresentation;
    }
    // Update is called once per frame
    void Update()
    {
       // PresentedHerself = Woman.GetComponent<UI>().ClickedSpacebarPresentation;
      //  if (PresentedHerself) Debug.Log("Se ha presentado!!!"); //Funciona
    }

    public void setPresentedHerself()
    {
        PresentedHerself = true;
    }

    public void setCalledTheWairtress()
    {
        CalledTheWairtress = true;
    }
}
