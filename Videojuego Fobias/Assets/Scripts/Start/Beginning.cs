using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TMPro;

public class Beginning : MonoBehaviour
{

    public InputField NameField;
    public InputField AgeField;
    public Button BeginButton;

    public static string Name;
    public static string Age;

    public ToggleGroup TGroup;
    public static bool isWoman;

    public GameObject panel;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = panel.GetComponent<Animator>();
        BeginButton.onClick.AddListener(TaskOnClick);
        StartCoroutine(CoroutineWait3seconds());
    }

    IEnumerator CoroutineWait3seconds()
    {
        animator.SetBool("FadeOut", true);
        yield return new WaitForSeconds(2);
        panel.gameObject.SetActive(false);
    }

    private void TaskOnClick()
    {
        Toggle toggle = TGroup.ActiveToggles().FirstOrDefault();

        if (toggle.GetComponentInChildren<TextMeshProUGUI>().text == "Hombre") isWoman = false;
        if (toggle.GetComponentInChildren<TextMeshProUGUI>().text == "Mujer") isWoman = true;

        if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Age))
        {
            panel.gameObject.SetActive(true);
            animator.SetBool("FadeIn", true);
            StartCoroutine(CoroutineChangeScene());
        }
        else Debug.Log("Clikao pero empty");

    }

    IEnumerator CoroutineChangeScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("ClassScene");

    }
    // Update is called once per frame
    void Update()
    {
        Name = NameField.text;

        if (!string.IsNullOrEmpty(Name)) {
            string LastNameLetter = Name.Substring(Name.Length - 1);
            char[] a = LastNameLetter.ToCharArray();
            char chr = a[0];

            if ((chr < 'a' || chr > 'z') && (chr < 'A' || chr > 'Z'))
            {
                Name = Name.Substring(0, Name.Length - 1);
                NameField.text = Name;
            }
        }

        Age = AgeField.text;

        if (!string.IsNullOrEmpty(Age))
        {
            string LastAgeLetter = Age.Substring(Age.Length - 1);
            char[] a = LastAgeLetter.ToCharArray();
            char chr = a[0];

            if (chr < '0' || chr > '9')
            {
                Age = Age.Substring(0, Age.Length - 1);
                AgeField.text = Age;
            }
            else
            {
            }
        }
    }
    

}
