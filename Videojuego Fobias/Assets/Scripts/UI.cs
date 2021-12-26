using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text Op2Text;
    public Text Op3Text;
    public Text PresentationText;
    public Text PresentationProtagonistText;
    public Text PresentationImageText;
    public RawImage Op2Button;
    public RawImage Op3Button;
    public RawImage PresentationButton;
    public Animator animator;
    public Image MyTimer;
    public Image fillImage;
    public Timer TimerScript;

    public Solutions Solutions;

    bool isVisible = false;
    bool OptionsAreVisible = false;
    public bool HasChosenOption = false;
    public bool TimerExceeded = false;
    public bool HasCalledWairtress = false;
    bool ForPresentationOrWairtress; // 0 Presentation 1 Wairtress

    private string Name;
    private string Age;

    bool LeftPressed = false;

    GameObject Canvas;
    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        //Canvas.SetActive(false);
        MyTimer.enabled = false;
        fillImage.enabled = false;
        Op2Text.enabled = false;
        Op2Button.enabled = false;
        Op3Text.enabled = false;
        Op3Button.enabled = false;
        PresentationButton.enabled = false;
        PresentationText.enabled = false;
        PresentationProtagonistText.enabled = false;
        PresentationImageText.enabled = false;

        Name = Beginning.Name;
        Age = Beginning.Age;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.U))
        {
            Canvas.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            Op2Text.text = "Derecha";
            Op3Text.text = "Izquierda";
        }

        if(Input.GetKey(KeyCode.Space) && (isVisible)){
            if (!ForPresentationOrWairtress) //Presentation
            {
                Solutions.setPresentedHerself();
                StartCoroutine(PresentationProtagonist3Seconds());
            }
            else //Wairtress
            {
                Solutions.setCalledTheWairtress();
                HasCalledWairtress = true;
                HasChosenOption = true;
            }
            MyTimer.enabled = false;
            fillImage.enabled = false;
            PresentationButton.enabled = false;
            PresentationImageText.enabled = false;
       //     Debug.Log("la he pulsado");
        }

        if(Input.GetKey(KeyCode.LeftArrow) & OptionsAreVisible)
        {
            DesactiveOptions();
            LeftPressed = true;
            HasChosenOption = true;
            MyTimer.enabled = false;
            fillImage.enabled = false;
        }
    
        else if (Input.GetKey(KeyCode.RightArrow) & OptionsAreVisible)
        {
            DesactiveOptions();
            LeftPressed = false;
            HasChosenOption = true;
            MyTimer.enabled = false;
            fillImage.enabled = false;
        }

    }

    public void SayThat(string ThingToSay)
    {
        StartCoroutine(TimeOfThingToSayInScreen(ThingToSay));
    }

    public void ProtagonistSayThat(string ThingToSay)
    {
        StartCoroutine(ProtagonistTimeOfThingToSayInScreen(ThingToSay));
    }

    public void PresentYourself()
    {
        StartCoroutine(PresentationProtagonist3Seconds());
    }
    IEnumerator PresentationProtagonist3Seconds()
    {
        PresentationProtagonistText.enabled = true;
        PresentationProtagonistText.text = "Hola, me llamo " + Name + " y tengo " + Age + " años";
        animator.SetBool("isTalking", true);
        yield return new WaitForSeconds(3);
        animator.SetBool("isTalking", false);
        PresentationProtagonistText.enabled = false;

    }
    IEnumerator TimeOfThingToSayInScreen(string ThingToSay)
    {
        PresentationText.enabled = true;
        PresentationText.text = ThingToSay;
        yield return new WaitForSeconds(3);
        PresentationText.enabled = false;
    }

    IEnumerator ProtagonistTimeOfThingToSayInScreen(string ThingToSay)
    {
        PresentationProtagonistText.enabled = true;
        PresentationProtagonistText.text = ThingToSay;
        yield return new WaitForSeconds(3);
        PresentationProtagonistText.enabled = false;
    }

    IEnumerator DesactiveSpacebar()
    {
        if (TimerExceeded)
        {
            isVisible = false;
            PresentationButton.enabled = false;
            PresentationImageText.enabled = false;
        }
        yield return null;
    }

    public void ActiveSpacebar()
    {
        PresentationButton.enabled = true;
        PresentationImageText.enabled = true;
        isVisible = true;
        ForPresentationOrWairtress = false;
        StartTheTimer();
        StartCoroutine(DesactiveSpacebar());
    }
    public void ActiveSpacebarForWairtress()
    {
        PresentationButton.enabled = true;
        PresentationImageText.enabled = true;
        PresentationImageText.text = "Llama al camarero";
        isVisible = true;
        ForPresentationOrWairtress = true;
     //   StartCoroutine(DesactiveSpacebar());
    }

    public void ActiveOptions()
    {
        
        Op2Button.enabled = true;
        Op2Text.enabled = true;
        Op3Button.enabled = true;
        Op3Text.enabled = true;
        OptionsAreVisible = true;
        HasChosenOption = false;
    }

    public void DesactiveOptions()
    {

        Op2Button.enabled = false;
        Op2Text.enabled = false;
        Op3Button.enabled = false;
        Op3Text.enabled = false;
        OptionsAreVisible = false;
    }

    public void Set1stDecisions()
    {
        Op2Text.text = "Lo mío tampoco es madrugar";
        Op3Text.text = "Yo tambien me levanto pronto";
    }

    public void Set2ndDecisions()
    {
        Op2Text.text = "Vocacional";
        Op3Text.text = "Salidas profesionales";
    }

    public void FirstAct()
    {
        ActiveOptions();
    }
    public void StartTheTimer()
    {
        StartCoroutine(StartTimer(10f));
    }
    public IEnumerator StartTimer(float duration)
    {
        TimerExceeded = false;
        MyTimer.enabled = true;
        fillImage.enabled = true;
        fillImage.fillAmount = 1f;
        //Debug.Log("La llamada se hace bien");
        float startTime = Time.time;
        float time = duration;
        float value = 0;

        while (Time.time - startTime < duration)
        {
            time -= Time.deltaTime;
            value = time / duration;
            fillImage.fillAmount = value;
            yield return null;
        }
        MyTimer.enabled = false;
        fillImage.enabled = false;

        DesactiveOptions();
        HasChosenOption = true;
        TimerExceeded = true;
        PresentationButton.enabled = false;
        PresentationImageText.enabled = false;

    }

    public bool LeftOptionChosen()
    {
        if (LeftPressed) return true;
        else return false;
    }

    public bool HasExceededTimer()
    {
        return TimerExceeded;
    }
    public void DesactiveHasChosenOption()
    {
        HasChosenOption = false;
    }
}
