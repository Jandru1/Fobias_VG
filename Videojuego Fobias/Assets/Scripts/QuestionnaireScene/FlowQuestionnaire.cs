using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class FlowQuestionnaire : MonoBehaviour
{

    public TextMeshProUGUI TextoEscenas;
    public TextMeshProUGUI TextoPrincipio;
    
    public TextMeshProUGUI Emoción1;
    public TextMeshProUGUI Emoción2;
    public TextMeshProUGUI Emoción3;
    public TextMeshProUGUI Emoción4;
    public TextMeshProUGUI Emoción5;
    public TextMeshProUGUI Emoción6;
    
    public Slider SliderEmocion1;
    public Slider SliderEmocion2;
    public Slider SliderEmocion3;
    public Slider SliderEmocion4;
    public Slider SliderEmocion5;
    public Slider SliderEmocion6;

    public TextMeshProUGUI SliderEmocion1Text;
    public TextMeshProUGUI SliderEmocion2Text;
    public TextMeshProUGUI SliderEmocion3Text;
    public TextMeshProUGUI SliderEmocion4Text;
    public TextMeshProUGUI SliderEmocion5Text;
    public TextMeshProUGUI SliderEmocion6Text;
    
    public Button ComenzarButton;
    public Button SiguienteButton;
    public Button AtrasButton;

    public Button EnviarButton;

    public GameObject Panel;
    Animator animator;

    public static float Emocion1Escena1Valor = 0;
    public static float Emocion1Escena2Valor = 0;
    public static float Emocion1Escena3Valor = 0;
    public static float Emocion1Escena4Valor = 0;

    public static float Emocion2Escena1Valor = 0;
    public static float Emocion2Escena2Valor = 0;
    public static float Emocion2Escena3Valor = 0;
    public static float Emocion2Escena4Valor = 0;

    public static float Emocion3Escena1Valor = 0;
    public static float Emocion3Escena2Valor = 0;
    public static float Emocion3Escena3Valor = 0;
    public static float Emocion3Escena4Valor = 0;

    public static float Emocion4Escena1Valor = 0;
    public static float Emocion4Escena2Valor = 0;
    public static float Emocion4Escena3Valor = 0;
    public static float Emocion4Escena4Valor = 0;

    public static float Emocion5Escena1Valor = 0;
    public static float Emocion5Escena2Valor = 0;
    public static float Emocion5Escena3Valor = 0;
    public static float Emocion5Escena4Valor = 0;

    public static float Emocion6Escena1Valor = 0;
    public static float Emocion6Escena2Valor = 0;
    public static float Emocion6Escena3Valor = 0;
    public static float Emocion6Escena4Valor = 0;

    bool EstamosEnEscena1 = false;
    bool EstamosEnEscena2 = false;
    bool EstamosEnEscena3 = false;
    bool EstamosEnEscena4 = false;

    int CuandoSeLLamaStart = 0;
    int CuandoSeLLamaAwake = 0;

    // Start is called before the first frame update

    private void Awake()
    {
        ++CuandoSeLLamaAwake;
    }
    void Start()
    {
        SlidersTo0();
        ++CuandoSeLLamaStart;
        animator = Panel.GetComponent<Animator>();
        animator.SetBool("FadeOut", true);
        StartCoroutine(PanelC());
    }
    IEnumerator PanelC()
    {
       
        EnviarButton.gameObject.SetActive(false);

        ComenzarButton.onClick.AddListener(PrimeraSituacion);
        disableEmotions();
        yield return new WaitForSeconds(2);
        Panel.SetActive(false);
        Cursor.visible = true;
    //    Screen.lockCursor = false;

        Cursor.lockState = CursorLockMode.None;


        //     Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (EstamosEnEscena1)
        {
            Emocion1Escena1Valor = SliderEmocion1.value;
            Emocion2Escena1Valor = SliderEmocion2.value;
            Emocion3Escena1Valor = SliderEmocion3.value;
            Emocion4Escena1Valor = SliderEmocion4.value;
            Emocion5Escena1Valor = SliderEmocion5.value;
            Emocion6Escena1Valor = SliderEmocion6.value;
        }
        else if (EstamosEnEscena2)
        {
            Emocion1Escena2Valor = SliderEmocion1.value;
            Emocion2Escena2Valor = SliderEmocion2.value;
            Emocion3Escena2Valor = SliderEmocion3.value;
            Emocion4Escena2Valor = SliderEmocion4.value;
            Emocion5Escena2Valor = SliderEmocion5.value;
            Emocion6Escena2Valor = SliderEmocion6.value;
        }
        else if (EstamosEnEscena3)
        {
            Emocion1Escena3Valor = SliderEmocion1.value;
            Emocion2Escena3Valor = SliderEmocion2.value;
            Emocion3Escena3Valor = SliderEmocion3.value;
            Emocion4Escena3Valor = SliderEmocion4.value;
            Emocion5Escena3Valor = SliderEmocion5.value;
            Emocion6Escena3Valor = SliderEmocion6.value;
        }
        else if (EstamosEnEscena4)
        {
            Emocion1Escena4Valor = SliderEmocion1.value;
            Emocion2Escena4Valor = SliderEmocion2.value;
            Emocion3Escena4Valor = SliderEmocion3.value;
            Emocion4Escena4Valor = SliderEmocion4.value;
            Emocion5Escena4Valor = SliderEmocion5.value;
            Emocion6Escena4Valor = SliderEmocion6.value;
        }

        SliderEmocion1Text.text = SliderEmocion1.value.ToString();
        SliderEmocion2Text.text = SliderEmocion2.value.ToString();
        SliderEmocion3Text.text = SliderEmocion3.value.ToString();
        SliderEmocion4Text.text = SliderEmocion4.value.ToString();
        SliderEmocion5Text.text = SliderEmocion5.value.ToString();
        SliderEmocion6Text.text = SliderEmocion6.value.ToString();
    }

    private void PrimeraSituacion()
    {
        SiguienteButton.gameObject.SetActive(true);
        EnviarButton.gameObject.SetActive(false);

        DebugElValorDeLosSliders();

        enableEmotions();

        WeAreInFirstScene();

        inicialiceEscena1Values();

        TextoEscenas.text = "En la primera situación, cuando \n debería haberme presentado, he sentido:";

        SiguienteButton.onClick.AddListener(SegundaSituacion);
        AtrasButton.onClick.AddListener(BackToFirst);
    }

    private void BackToFirst()
    {
        disableEmotions();
    }

    private void SegundaSituacion()
    {
        SiguienteButton.gameObject.SetActive(true);
        EnviarButton.gameObject.SetActive(false);
        DebugElValorDeLosSliders();

        WeAreInSecondScene();
        inicialiceEscena2Values();
        TextoEscenas.text = "En la segunda situación, cuando \n hablaban sobre madrugar, he sentido:";

        SiguienteButton.onClick.AddListener(TerceraSituacion);
        AtrasButton.onClick.AddListener(PrimeraSituacion);
    }

    private void TerceraSituacion()
    {
        SiguienteButton.gameObject.SetActive(true);
        EnviarButton.gameObject.SetActive(false);

        WeAreInThirdsScene();
        inicialiceEscena3Values();
        TextoEscenas.text = "En la tercera situación, cuando hablaban \n  sobre por qué hemos escogido la carrera, he sentido:";

        Emoción3.text = "Enfado";
        DebugElValorDeLosSliders();

        SiguienteButton.onClick.AddListener(CuartaSituacion);
        AtrasButton.onClick.AddListener(SegundaSituacion);
    }

    private void CuartaSituacion()
    {
        WeAreInFourthScene();
        inicialiceEscena4Values();

        TextoEscenas.text = "En la cuarta situación, cuando \n debía llamar al camarero, he sentido:";

        Emoción3.text = "Indecisión";
        Emoción6.text = "Tensión";
        DebugElValorDeLosSliders();

        SiguienteButton.gameObject.SetActive(false);
        EnviarButton.gameObject.SetActive(true);
        EnviarButton.onClick.AddListener(FinDelCuestionario);
        AtrasButton.onClick.AddListener(TerceraSituacion);
    }

    private void DebugElValorDeLosSliders()
    {
        Debug.Log("Valor Slider 1 = " + SliderEmocion1.value);
        Debug.Log("Valor Slider 2 = " + SliderEmocion2.value);
        Debug.Log("Valor Slider 3 = " + SliderEmocion3.value);
        Debug.Log("Valor Slider 4 = " + SliderEmocion4.value);
        Debug.Log("Valor Slider 5 = " + SliderEmocion5.value);
        Debug.Log("Valor Slider 6 = " + SliderEmocion6.value);
    }

    private void FinDelCuestionario()
    {
        Panel.SetActive(true);
        animator.SetBool("FadeIn", true);
        StartCoroutine(ChangeToResultsScene());

        //IR A RESULTADOS SCENE
    }

    IEnumerator ChangeToResultsScene()
    {
        Debug.Log("Valor de la CuandoSeLLamaStart: " + CuandoSeLLamaStart);
        Debug.Log("Valor de la CuandoSeLLamaAwake: " + CuandoSeLLamaAwake);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("ResultsScene");

    }

    private void enableEmotions()
    {
        ComenzarButton.gameObject.SetActive(false);
        TextoPrincipio.enabled = false;

        TextoEscenas.enabled = true;

        Emoción1.enabled = true;
        Emoción2.enabled = true;
        Emoción3.enabled = true;
        Emoción4.enabled = true;
        Emoción5.enabled = true;
        Emoción6.enabled = true;

        SliderEmocion1.gameObject.SetActive(true);
        SliderEmocion2.gameObject.SetActive(true);
        SliderEmocion3.gameObject.SetActive(true);
        SliderEmocion4.gameObject.SetActive(true);
        SliderEmocion5.gameObject.SetActive(true);
        SliderEmocion6.gameObject.SetActive(true);

        SliderEmocion1Text.enabled = true;
        SliderEmocion2Text.enabled = true;
        SliderEmocion3Text.enabled = true;
        SliderEmocion4Text.enabled = true;
        SliderEmocion5Text.enabled = true;
        SliderEmocion6Text.enabled = true;

        SiguienteButton.gameObject.SetActive(true);
        AtrasButton.gameObject.SetActive(true);
    }

    private void disableEmotions()
    {
        ComenzarButton.gameObject.SetActive(true);
        TextoPrincipio.enabled = true;

        TextoEscenas.enabled = false;

        Emoción1.enabled = false;
        Emoción2.enabled = false;
        Emoción3.enabled = false;
        Emoción4.enabled = false;
        Emoción5.enabled = false;
        Emoción6.enabled = false;

        SliderEmocion1.gameObject.SetActive(false);
        SliderEmocion2.gameObject.SetActive(false);
        SliderEmocion3.gameObject.SetActive(false);
        SliderEmocion4.gameObject.SetActive(false);
        SliderEmocion5.gameObject.SetActive(false);
        SliderEmocion6.gameObject.SetActive(false);

        SliderEmocion1Text.enabled = false;
        SliderEmocion2Text.enabled = false;
        SliderEmocion3Text.enabled = false;
        SliderEmocion4Text.enabled = false;
        SliderEmocion5Text.enabled = false;
        SliderEmocion6Text.enabled = false;

        SiguienteButton.gameObject.SetActive(false);
        AtrasButton.gameObject.SetActive(false);
        

    }

    private void SlidersTo0()
    {
        int a = 0;

        SliderEmocion1.value = 0;
        SliderEmocion1Text.text = a.ToString();
        SliderEmocion2.value = 0;
        SliderEmocion2Text.text = a.ToString();
        SliderEmocion3.value = 0;
        SliderEmocion4Text.text = a.ToString();
        SliderEmocion4.value = 0;
        SliderEmocion4Text.text = a.ToString();
        SliderEmocion5.value = 0;
        SliderEmocion5Text.text = a.ToString();
        SliderEmocion6.value = 0;
        SliderEmocion6Text.text = a.ToString();

        Debug.Log("entro en sliders to 0");

        Emocion1Escena1Valor = 0;
        Emocion1Escena2Valor = 0;
        Emocion1Escena3Valor = 0;
        Emocion1Escena4Valor = 0;

        Emocion2Escena1Valor = 0;
        Emocion2Escena2Valor = 0;
        Emocion2Escena3Valor = 0;
        Emocion2Escena4Valor = 0;

        Emocion3Escena1Valor = 0;
        Emocion3Escena2Valor = 0;
        Emocion3Escena3Valor = 0;
        Emocion3Escena4Valor = 0;

        Emocion4Escena1Valor = 0;
        Emocion4Escena2Valor = 0;
        Emocion4Escena3Valor = 0;
        Emocion4Escena4Valor = 0;

        Emocion5Escena1Valor = 0;
        Emocion5Escena2Valor = 0;
        Emocion5Escena3Valor = 0;
        Emocion5Escena4Valor = 0;

        Emocion6Escena1Valor = 0;
        Emocion6Escena2Valor = 0;
        Emocion6Escena3Valor = 0;
        Emocion6Escena4Valor = 0;
    }

    private void inicialiceEscena1Values()
    {
        SliderEmocion1.value = Emocion1Escena1Valor;
        SliderEmocion2.value = Emocion2Escena1Valor;
        SliderEmocion3.value = Emocion3Escena1Valor;
        SliderEmocion4.value = Emocion4Escena1Valor;
        SliderEmocion5.value = Emocion5Escena1Valor;
        SliderEmocion6.value = Emocion6Escena1Valor;
    }

    private void inicialiceEscena2Values()
    {
        SliderEmocion1.value = Emocion1Escena2Valor;
        SliderEmocion2.value = Emocion2Escena2Valor;
        SliderEmocion3.value = Emocion3Escena2Valor;
        SliderEmocion4.value = Emocion4Escena2Valor;
        SliderEmocion5.value = Emocion5Escena2Valor;
        SliderEmocion6.value = Emocion6Escena2Valor;
    }

    private void inicialiceEscena3Values()
    {
        SliderEmocion1.value = Emocion1Escena3Valor;
        SliderEmocion2.value = Emocion2Escena3Valor;
        SliderEmocion3.value = Emocion3Escena3Valor;
        SliderEmocion4.value = Emocion4Escena3Valor;
        SliderEmocion5.value = Emocion5Escena3Valor;
        SliderEmocion6.value = Emocion6Escena3Valor;
    }

    private void inicialiceEscena4Values()
    {
        SliderEmocion1.value = Emocion1Escena4Valor;
        SliderEmocion2.value = Emocion2Escena4Valor;
        SliderEmocion3.value = Emocion3Escena4Valor;
        SliderEmocion4.value = Emocion4Escena4Valor;
        SliderEmocion5.value = Emocion5Escena4Valor;
        SliderEmocion6.value = Emocion6Escena4Valor;
    }

    private void WeAreInFirstScene()
    {
        EstamosEnEscena1 = true;
        EstamosEnEscena2 = false;
        EstamosEnEscena3 = false;
        EstamosEnEscena4 = false;

        Emoción1.text = "Vergüenza";
        Emoción2.text = "Miedo";
        Emoción3.text = "Indecisión";
        Emoción4.text = "Intranquilidad";
        Emoción5.text = "Paralización";
        Emoción6.text = "Indiferencia";
    }

    private void WeAreInSecondScene()
    {
        EstamosEnEscena1 = false;
        EstamosEnEscena2 = true;
        EstamosEnEscena3 = false;
        EstamosEnEscena4 = false;

        Emoción1.text = "Vergüenza";
        Emoción2.text = "Miedo";
        Emoción3.text = "Indecisión";
        Emoción4.text = "Intranquilidad";
        Emoción5.text = "Paralización";
        Emoción6.text = "Indiferencia";
    }

    private void WeAreInThirdsScene()
    {
        EstamosEnEscena1 = false;
        EstamosEnEscena2 = false;
        EstamosEnEscena3 = true;
        EstamosEnEscena4 = false;

        Emoción1.text = "Vergüenza";
        Emoción2.text = "Miedo";
        Emoción3.text = "Enfado";
        Emoción4.text = "Intranquilidad";
        Emoción5.text = "Paralización";
        Emoción6.text = "Indiferencia";
    }

    private void WeAreInFourthScene()
    {
        EstamosEnEscena1 = false;
        EstamosEnEscena2 = false;
        EstamosEnEscena3 = false;
        EstamosEnEscena4 = true;

        Emoción1.text = "Vergüenza";
        Emoción2.text = "Miedo";
        Emoción3.text = "Indecisión";
        Emoción4.text = "Intranquilidad";
        Emoción5.text = "Paralización";
        Emoción6.text = "Tensión";
    }
}
