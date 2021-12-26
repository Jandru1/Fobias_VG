using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ToggleSystem : MonoBehaviour
{
    public ToggleGroup TGroup;


    private void Start()
    {
      //  TGroup = GetComponent<ToggleGroup>();
    }

    public void CheckGender()
    {
        Toggle toggle = TGroup.ActiveToggles().FirstOrDefault();
        Debug.Log(toggle.name + " __ " + toggle.GetComponentInChildren<Text>().text);
    }
}
