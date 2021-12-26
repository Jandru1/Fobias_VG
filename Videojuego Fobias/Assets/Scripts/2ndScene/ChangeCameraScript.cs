using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class ChangeCameraScript : MonoBehaviour
{

    public Camera C1;
    public Camera C2;
    public CinemachineSmoothPath CMPath;
    public CinemachineVirtualCamera CMVC;
    // Start is called before the first frame update
    void Start()
    {
        C1.enabled = true;
        C2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //C1.gameObject.transform.position == 
        if (CMVC.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition == 15)
         //CMPath.m_Waypoints[15].position)
        {
           // Debug.Log("FUNCIONA");
            C1.enabled = false;
            C2.enabled = true;
        }
    }
}
