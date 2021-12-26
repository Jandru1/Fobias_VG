using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Beginning : MonoBehaviour
{

    public InputField NameField;
    public InputField AgeField;
    public Button BeginButton;

    public static string Name;
    public static string Age;

    public ToggleGroup TGroup;
    public static bool isWoman;
    // Start is called before the first frame update
    void Start()
    {
        BeginButton.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        Toggle toggle = TGroup.ActiveToggles().FirstOrDefault();
     //   Debug.Log(toggle.name + " __ " + toggle.GetComponentInChildren<Text>().text);
        if (toggle.GetComponentInChildren<Text>().text == "Hombre") isWoman = false;
        if (toggle.GetComponentInChildren<Text>().text == "Mujer") isWoman = true;
     //   Debug.Log(isWoman);
        if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Age))
        {
          //  Debug.Log("Clikao y no empty");
            SceneManager.LoadScene("ClassScene");
        }
        else Debug.Log("Clikao pero empty");

    }
    // Update is called once per frame
    void Update()
    {
        Name = NameField.text;
        Age = AgeField.text;
    }
}
