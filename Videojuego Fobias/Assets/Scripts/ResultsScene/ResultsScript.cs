using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultsScript : MonoBehaviour
{
    float Emocion1Escena1Valor;
    float Emocion1Escena2Valor;
    float Emocion1Escena3Valor;
    float Emocion1Escena4Valor;

    float Emocion2Escena1Valor;
    float Emocion2Escena2Valor;
    float Emocion2Escena3Valor;
    float Emocion2Escena4Valor;

    float Emocion3Escena1Valor;
    float Emocion3Escena2Valor;
    float Emocion3Escena3Valor;
    float Emocion3Escena4Valor;

    float Emocion4Escena1Valor;
    float Emocion4Escena2Valor;
    float Emocion4Escena3Valor;
    float Emocion4Escena4Valor;

    float Emocion5Escena1Valor;
    float Emocion5Escena2Valor;
    float Emocion5Escena3Valor;
    float Emocion5Escena4Valor;

    float Emocion6Escena1Valor;
    float Emocion6Escena2Valor;
    float Emocion6Escena3Valor;
    float Emocion6Escena4Valor;

    public static bool PresentedHerself = false;
    public static bool TalkInFirstScene = false;
    public static bool TalkInSecondScene = false;
    public static bool CalledTheWairtess= false;

    // public Text Diagnostico;
    public TextMeshProUGUI Diagnostico;

    int Escena1MAL = 0;
    int Escena1NORMAL = 0;
    int Escena1BIEN = 0;

    int Escena2MAL = 0;
    int Escena2NORMAL = 0;
    int Escena2BIEN = 0;

    int Escena3MAL = 0;
    int Escena3NORMAL = 0;
    int Escena3BIEN = 0;

    int Escena4MAL = 0;
    int Escena4NORMAL = 0;
    int Escena4BIEN = 0;

    bool DiagnosticoGlobalAlto = false;
    bool DiagnosticoGlobalMedio = false;
    bool DiagnosticoGlobalBajo = false;

    List<string> EmocionesAltasEscena1 = new List<string>();
    List<string> EmocionesMediasEscena1 = new List<string>();
    List<string> EmocionesAltasEscena2 = new List<string>();
    List<string> EmocionesMediasEscena2 = new List<string>();
    List<string> EmocionesAltasEscena3 = new List<string>();
    List<string> EmocionesMediasEscena3 = new List<string>();
    List<string> EmocionesAltasEscena4 = new List<string>();
    List<string> EmocionesMediasEscena4 = new List<string>();

    List<int> EscenasAltasss = new List<int>();
    List<int> EscenasMediasss = new List<int>();
    List<int> EscenasBajasss = new List<int>();

    public GameObject Panel;
    Animator animator;

    public Button PlayAgainButton;


    // Start is called before the first frame update
    void Start()
    {
        PlayAgainButton.gameObject.SetActive(false);
        animator = Panel.GetComponent<Animator>();
        animator.SetBool("FadeOut", true);
        StartCoroutine(CoroutineFadeOUT());
        StartCoroutine(CoroutinePlayAgain());

        Emocion1Escena1Valor = FlowQuestionnaire.Emocion1Escena1Valor;
        Emocion1Escena2Valor = FlowQuestionnaire.Emocion1Escena2Valor;
        Emocion1Escena3Valor = FlowQuestionnaire.Emocion1Escena3Valor;
        Emocion1Escena4Valor = FlowQuestionnaire.Emocion1Escena4Valor;

        Emocion2Escena1Valor = FlowQuestionnaire.Emocion2Escena1Valor;
        Emocion2Escena2Valor = FlowQuestionnaire.Emocion2Escena2Valor;
        Emocion2Escena3Valor = FlowQuestionnaire.Emocion2Escena3Valor;
        Emocion2Escena4Valor = FlowQuestionnaire.Emocion2Escena4Valor;

        Emocion3Escena1Valor = FlowQuestionnaire.Emocion3Escena1Valor;
        Emocion3Escena2Valor = FlowQuestionnaire.Emocion3Escena2Valor;
        Emocion3Escena3Valor = FlowQuestionnaire.Emocion3Escena3Valor;
        Emocion3Escena4Valor = FlowQuestionnaire.Emocion3Escena4Valor;

        Emocion4Escena1Valor = FlowQuestionnaire.Emocion4Escena1Valor;
        Emocion4Escena2Valor = FlowQuestionnaire.Emocion4Escena2Valor;
        Emocion4Escena3Valor = FlowQuestionnaire.Emocion4Escena3Valor;
        Emocion4Escena4Valor = FlowQuestionnaire.Emocion4Escena4Valor;

        Emocion5Escena1Valor = FlowQuestionnaire.Emocion5Escena1Valor;
        Emocion5Escena2Valor = FlowQuestionnaire.Emocion5Escena2Valor;
        Emocion5Escena3Valor = FlowQuestionnaire.Emocion5Escena3Valor;
        Emocion5Escena4Valor = FlowQuestionnaire.Emocion5Escena4Valor;

        Emocion6Escena1Valor = FlowQuestionnaire.Emocion6Escena1Valor;
        Emocion6Escena2Valor = FlowQuestionnaire.Emocion6Escena2Valor;
        Emocion6Escena3Valor = FlowQuestionnaire.Emocion6Escena3Valor;
        Emocion6Escena4Valor = FlowQuestionnaire.Emocion6Escena4Valor;

        HacerDiagnosticoGlobal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPresentedHerself()
    {
        PresentedHerself = true;
    }
    
    public void setNotPresentedHerself()
    {
        PresentedHerself = false;
    }

    private void HacerDiagnosticoGlobal()
    {
        CuantosEnEscena1();
        CuantosEnEscena2();
        CuantosEnEscena3();
        CuantosEnEscena4();

        int CuantasEscenasAltas = 0;
        int CuantasEscenasMedias = 0;
        int CuantasEscenasBajas = 0;

        List<int> EscenasAltas = new List<int>();
        List<int> EscenasMedias = new List<int>();
        List<int> EscenasBajas = new List<int>();

        string valorEscena1 = EvaluameLaEscena1();
        string valorEscena2 = EvaluameLaEscena2();
        string valorEscena3 = EvaluameLaEscena3();
        string valorEscena4 = EvaluameLaEscena4();

        if (valorEscena1.Equals("Alta"))
        {
            ++CuantasEscenasAltas;
            EscenasAltasss.Add(1);
        }
        else if (valorEscena1.Equals("Media"))
        {
            EscenasMediasss.Add(1);
            ++CuantasEscenasMedias;
        }
        else
        {
            ++CuantasEscenasBajas;
            EscenasBajasss.Add(1);
        }

        if (valorEscena2.Equals("Alta"))
        {
            ++CuantasEscenasAltas;
            EscenasAltasss.Add(2);
        }
        else if (valorEscena2.Equals("Media"))
        {
            EscenasMediasss.Add(2);
            ++CuantasEscenasMedias;
        }
        else
        {
            ++CuantasEscenasBajas;
            EscenasBajasss.Add(2);
        }

        if (valorEscena3.Equals("Alta"))
        {
            ++CuantasEscenasAltas;
            EscenasAltasss.Add(3);
        }
        else if (valorEscena3.Equals("Media"))
        {
            EscenasMediasss.Add(3);
            ++CuantasEscenasMedias;
        }
        else
        {
            ++CuantasEscenasBajas;
            EscenasBajasss.Add(3);
        }

        if (valorEscena4.Equals("Alta"))
        {
            ++CuantasEscenasAltas;
            EscenasAltasss.Add(4);
        }
        else if (valorEscena4.Equals("Media"))
        {
            EscenasMediasss.Add(4);
            ++CuantasEscenasMedias;
        }
        else
        {
            ++CuantasEscenasBajas;
            EscenasBajasss.Add(4);
        }

        string ValorFinalDelCuestionario;

        if (CuantasEscenasAltas >= 3) ValorFinalDelCuestionario = "Alta"; //Hay 3 o 4 Escenas con una emoción alta. 
        else if (CuantasEscenasAltas == 2) ValorFinalDelCuestionario = "Media";
        else if (CuantasEscenasAltas == 1)
        {
            if (CuantasEscenasMedias == 3 || CuantasEscenasMedias == 2) ValorFinalDelCuestionario = "Media";
            else ValorFinalDelCuestionario = "Baja";
        }
        else
        {
            if (CuantasEscenasMedias == 4 || CuantasEscenasMedias == 3) ValorFinalDelCuestionario = "Media";
            else ValorFinalDelCuestionario = "Baja";
        }

        int valorFinalDelCuestionario;
        if (ValorFinalDelCuestionario.Equals("Alta")) valorFinalDelCuestionario = 4;
        else if (ValorFinalDelCuestionario.Equals("Media")) valorFinalDelCuestionario = 2;
        else valorFinalDelCuestionario = 0;

        Debug.Log("ValorFinalDelCuestionario: " + valorFinalDelCuestionario);
        int valorDeLasDecisiones = 0;

        if (!PresentedHerself) ++valorDeLasDecisiones;
        if (!TalkInFirstScene) ++valorDeLasDecisiones;
        if (!TalkInSecondScene) ++valorDeLasDecisiones;
        if (!CalledTheWairtess) ++valorDeLasDecisiones;

        Debug.Log("Valor de las decisiones: " + valorDeLasDecisiones);

        int ValorGlobalDefinitivo = valorDeLasDecisiones + valorFinalDelCuestionario;

        if (ValorGlobalDefinitivo >= 6 & ValorGlobalDefinitivo <= 8) DiagnosticoGlobalAlto = true;
        else if (ValorGlobalDefinitivo >= 3 & ValorGlobalDefinitivo <= 5) DiagnosticoGlobalMedio = true;
        else DiagnosticoGlobalBajo = true;


        Debug.Log("EscenasAltasss " + EscenasAltasss.Count);
        Debug.Log("EscenasMediasss " + EscenasMediasss.Count);
        Debug.Log("EscenasBajasss " + EscenasBajasss.Count);


        if (DiagnosticoGlobalAlto) { Debug.Log("Escenas medias AL LLAMAR COUNT = " + EscenasMediasss.Count); WriteDiagnosticoAlto(); }
        else if (DiagnosticoGlobalMedio)WriteDiagnosticoMedio(); 
        else WriteDiagnosticoBajo();


        /*
        if (Escena1MAL > 1) ValorarDiagnosticoGlobal(EscenasAltas, 1, CuantasEscenasAltas);
        if (Escena2MAL > 1) ValorarDiagnosticoGlobal(EscenasAltas, 2, CuantasEscenasAltas);
        if (Escena3MAL > 1) ValorarDiagnosticoGlobal(EscenasAltas, 3, CuantasEscenasAltas);
        if (Escena4MAL > 1) ValorarDiagnosticoGlobal(EscenasAltas, 4, CuantasEscenasAltas);

        if (Escena1NORMAL > 1) ValorarDiagnosticoGlobal(EscenasMedias, 1, CuantasEscenasMedias);
        if (Escena2NORMAL > 1) ValorarDiagnosticoGlobal(EscenasMedias, 2, CuantasEscenasMedias);
        if (Escena3NORMAL > 1) ValorarDiagnosticoGlobal(EscenasMedias, 3, CuantasEscenasMedias);
        if (Escena4NORMAL > 1) ValorarDiagnosticoGlobal(EscenasMedias, 4, CuantasEscenasMedias);

        if (Escena1BIEN> 1) ValorarDiagnosticoGlobal(EscenasBajas, 1, CuantasEscenasBajas);
        if (Escena2BIEN> 1) ValorarDiagnosticoGlobal(EscenasBajas, 2, CuantasEscenasBajas);
        if (Escena3BIEN> 1) ValorarDiagnosticoGlobal(EscenasBajas, 3, CuantasEscenasBajas);
        if (Escena4BIEN> 1) ValorarDiagnosticoGlobal(EscenasBajas, 4, CuantasEscenasBajas);
        */
    }

    private string EvaluameLaEscena1()
    {
        int emocionesAltas = 0;
        int emocionesMedias = 0;
        int emocionesBajas = 0;

        string valor = evaluameLaEmocion(Emocion1Escena1Valor);
        if (valor.Equals("Alta")) ++emocionesAltas;
        else if (valor.Equals("Media")) ++emocionesMedias;
        else ++emocionesBajas;

        valor = evaluameLaEmocion(Emocion2Escena1Valor);
        if (valor.Equals("Alta")) ++emocionesAltas;
        else if (valor.Equals("Media")) ++emocionesMedias;
        else ++emocionesBajas;

        valor = evaluameLaEmocion(Emocion3Escena1Valor);
        if (valor.Equals("Alta")) ++emocionesAltas;
        else if (valor.Equals("Media")) ++emocionesMedias;
        else ++emocionesBajas;

        valor = evaluameLaEmocion(Emocion4Escena1Valor);
        if (valor.Equals("Alta")) ++emocionesAltas;
        else if (valor.Equals("Media")) ++emocionesMedias;
        else ++emocionesBajas;

        valor = evaluameLaEmocion(Emocion5Escena1Valor);
        if (valor.Equals("Alta")) ++emocionesAltas;
        else if (valor.Equals("Media")) ++emocionesMedias;
        else ++emocionesBajas;

        valor = evaluameLaEmocion(Emocion6Escena1Valor);
        if (valor.Equals("Alta")) ++emocionesAltas;
        else if (valor.Equals("Media")) ++emocionesMedias;
        else ++emocionesBajas;

        if (emocionesAltas >= 2)
        {
            return "Alta";
        }
        else if (emocionesMedias >= 2)
        {
            return "Media";
        }
        else
        {
            return "Baja";
        }
    }

    private string EvaluameLaEscena2()
    {
        int emocionesAltas = 0;
        int emocionesMedias = 0;
        int emocionesBajas = 0;

        string valor = evaluameLaEmocion(Emocion1Escena2Valor);
        if (valor.Equals("Alta")) ++emocionesAltas;
        else if (valor.Equals("Media")) ++emocionesMedias;
        else ++emocionesBajas;

        valor = evaluameLaEmocion(Emocion2Escena2Valor);
        if (valor.Equals("Alta")) ++emocionesAltas;
        else if (valor.Equals("Media")) ++emocionesMedias;
        else ++emocionesBajas;

        valor = evaluameLaEmocion(Emocion3Escena2Valor);
        if (valor.Equals("Alta")) ++emocionesAltas;
        else if (valor.Equals("Media")) ++emocionesMedias;
        else ++emocionesBajas;

        valor = evaluameLaEmocion(Emocion4Escena2Valor);
        if (valor.Equals("Alta")) ++emocionesAltas;
        else if (valor.Equals("Media")) ++emocionesMedias;
        else ++emocionesBajas;

        valor = evaluameLaEmocion(Emocion5Escena2Valor);
        if (valor.Equals("Alta")) ++emocionesAltas;
        else if (valor.Equals("Media")) ++emocionesMedias;
        else ++emocionesBajas;

        valor = evaluameLaEmocion(Emocion6Escena2Valor);
        if (valor.Equals("Alta")) ++emocionesAltas;
        else if (valor.Equals("Media")) ++emocionesMedias;
        else ++emocionesBajas;

        if (emocionesAltas >= 2)
        {
            return "Alta";
        }
        else if (emocionesMedias >= 2)
        {
            return "Media";
        }
        else
        {
            return "Baja";
        }
    }

    private string EvaluameLaEscena3()
    {
        int emocionesAltas = 0;
        int emocionesMedias = 0;
        int emocionesBajas = 0;

        string valor = evaluameLaEmocion(Emocion1Escena3Valor);
        if (valor.Equals("Alta")) ++emocionesAltas;
        else if (valor.Equals("Media")) ++emocionesMedias;
        else ++emocionesBajas;

        valor = evaluameLaEmocion(Emocion2Escena3Valor);
        if (valor.Equals("Alta")) ++emocionesAltas;
        else if (valor.Equals("Media")) ++emocionesMedias;
        else ++emocionesBajas;

        valor = evaluameLaEmocion(Emocion3Escena3Valor);
        if (valor.Equals("Alta")) ++emocionesAltas;
        else if (valor.Equals("Media")) ++emocionesMedias;
        else ++emocionesBajas;

        valor = evaluameLaEmocion(Emocion4Escena3Valor);
        if (valor.Equals("Alta")) ++emocionesAltas;
        else if (valor.Equals("Media")) ++emocionesMedias;
        else ++emocionesBajas;

        valor = evaluameLaEmocion(Emocion5Escena3Valor);
        if (valor.Equals("Alta")) ++emocionesAltas;
        else if (valor.Equals("Media")) ++emocionesMedias;
        else ++emocionesBajas;

        valor = evaluameLaEmocion(Emocion6Escena3Valor);
        if (valor.Equals("Alta")) ++emocionesAltas;
        else if (valor.Equals("Media")) ++emocionesMedias;
        else ++emocionesBajas;

        if (emocionesAltas >= 2)
        {
            return "Alta";
        }
        else if (emocionesMedias >= 2)
        {
            return "Media";
        }
        else
        {
            return "Baja";
        }
    }

    private string EvaluameLaEscena4()
    {
        int emocionesAltas = 0;
        int emocionesMedias = 0;
        int emocionesBajas = 0;

        string valor = evaluameLaEmocion(Emocion1Escena4Valor);
        if (valor.Equals("Alta")) ++emocionesAltas;
        else if (valor.Equals("Media")) ++emocionesMedias;
        else ++emocionesBajas;

        valor = evaluameLaEmocion(Emocion2Escena4Valor);
        if (valor.Equals("Alta")) ++emocionesAltas;
        else if (valor.Equals("Media")) ++emocionesMedias;
        else ++emocionesBajas;

        valor = evaluameLaEmocion(Emocion3Escena4Valor);
        if (valor.Equals("Alta")) ++emocionesAltas;
        else if (valor.Equals("Media")) ++emocionesMedias;
        else ++emocionesBajas;

        valor = evaluameLaEmocion(Emocion4Escena4Valor);
        if (valor.Equals("Alta")) ++emocionesAltas;
        else if (valor.Equals("Media")) ++emocionesMedias;
        else ++emocionesBajas;

        valor = evaluameLaEmocion(Emocion5Escena4Valor);
        if (valor.Equals("Alta")) ++emocionesAltas;
        else if (valor.Equals("Media")) ++emocionesMedias;
        else ++emocionesBajas;

        valor = evaluameLaEmocion(Emocion6Escena4Valor);
        if (valor.Equals("Alta")) ++emocionesAltas;
        else if (valor.Equals("Media")) ++emocionesMedias;
        else ++emocionesBajas;

        if (emocionesAltas >= 2)
        {
            return "Alta";
        }
        else if (emocionesMedias >= 2)
        {
            return "Media";
        }
        else
        {
            return "Baja";
        }
    }

    private string evaluameLaEmocion(float emocion)
    {
        if (emocion >= 8 & emocion <= 10)
        {
            return "Alta";
        }
        else if (emocion >= 5 & emocion <= 7) return "Media";
        else return "Baja";
    }

    private void ValorarDiagnosticoGlobal(List<int> EscenasPoNivel, int escena, int countEscenasPorNivel)
    {
        EscenasPoNivel.Add(escena);
        ++countEscenasPorNivel;
    }

    private void WriteDiagnosticoAlto()
    {
        
        Debug.Log("Y AQUI ESCENASMEDIACOUNT = " + EscenasMediasss.Count);
        Debug.Log("Y AQUI ESCENASAltasCOUNT = " + EscenasAltasss.Count);
        Debug.Log("Y AQUI ESCENASBajasCOUNT = " + EscenasBajasss.Count);

     /*   Diagnostico.text = "En el resultado de esta prueba se han detectado niveles muy altos de ciertas emociones. Esto puede significar que" +
                           "dichas emociones se vean alteradas cuando el jugador se encuentra ante estas situaciones en la vida real. Se le recomendaría  " +
                           "que recurriera a ayuda ya que probablemente la necesite. "; */

        Diagnostico.text = "\n En esta prueba se han detectado niveles de intesidad muy elevados de algunas emociones. Estos niveles de intensidad emocional " +
            "indican malestar psicológico significativo en el jugador. En base a esto, se deduce que el jugador podría estar experimentando este nivel de " +
            "malestar en situaciones similares de la vida real. Se recomienda que el jugador acuda a un profesional.";

        List<int> EscenasAltas1 = new List<int>(); //Guardar escenas con emociones altas para no repetirlas en emociones medias
        int size = EmocionesAltasEscena1.Count;
        Debug.Log("EmocionesAltasEscena1.count = " + EmocionesAltasEscena1.Count);
        string toAdd = "";
        /*
        if (size > 1)
        {
            EscenasAltas1.Add(1);
            for (int i = 0; i < size; ++i)
            {
                if (i + 1 == size) toAdd += EmocionesAltasEscena1[i];
                else if (i + 2 == size) toAdd += EmocionesAltasEscena1[i] + " y ";
                else toAdd += EmocionesAltasEscena1[i] + ", ";
            }
            Diagnostico.text += "Los altos niveles en " + toAdd + " indican un alto grado de inestabilidad a la hora de presentarse ante alguien.";
        }
          
        size = EmocionesAltasEscena2.Count;
        toAdd = "";
        
        if (size > 1)
        {
            EscenasAltas1.Add(2);
            for (int i = 0; i < size; ++i)
            {
                if (i + 1 == size) toAdd += EmocionesAltasEscena2[i];
                else if (i + 2 == size) toAdd += EmocionesAltasEscena2[i] + " y ";
                else toAdd += EmocionesAltasEscena2[i] + ", ";
            }
            Diagnostico.text += "Los altos niveles en " + toAdd + "   indican un alto grado de inestabilidad a la hora de entablar una conversación.  ";

        }

        size = EmocionesAltasEscena3.Count;
        toAdd = "";
        if(size > 1)
        {
            EscenasAltas1.Add(3);
            for (int i = 0; i < size; ++i)
            {
                if (i + 1 == size) toAdd += EmocionesAltasEscena3[i];
                else if (i + 2 == size) toAdd += EmocionesAltasEscena3[i] + " y ";
                else toAdd += EmocionesAltasEscena3[i] + ", ";
            }
            Diagnostico.text += "Los altos niveles en " + toAdd + "   indican un alto grado de inestabilidad a la hora de entablar una segunda conversación.  ";
        }

        size = EmocionesAltasEscena4.Count;
        toAdd = "";
        if (size > 1)
        {
            EscenasAltas1.Add(4);
            for (int i = 0; i < size; ++i)
            {
                if (i + 1 == size) toAdd += EmocionesAltasEscena4[i];
                else if (i + 2 == size) toAdd += EmocionesAltasEscena4[i] + " y ";
                else toAdd += EmocionesAltasEscena4[i] + ", ";
            }

            Diagnostico.text += "Los altos niveles en " + toAdd + " indican un alto grado de inestabilidad a la hora de llamar al camarero.";
        }
        */
        int CuantasEscenasAltasHay = EscenasAltas1.Count;

        toAdd = " Los altos niveles de ";
        Debug.Log("EscenasAltasss:" + EscenasAltasss.Count);
        if (EscenasAltasss.Count > 0)
        {

            for (int i = 0; i < EscenasAltasss.Count; ++i)
            {
                List<string> EscenaIJ = new List<string>();
                if (EscenasAltasss[i] == 1) EscenaIJ = EmocionesAltasEscena1;
                else if (EscenasAltasss[i] == 2) EscenaIJ = EmocionesAltasEscena2;
                else if (EscenasAltasss[i] == 3) EscenaIJ = EmocionesAltasEscena3;
                else EscenaIJ = EmocionesAltasEscena4;

                size = EscenaIJ.Count;
                for (int j = 0; j < size; ++j)
                {
                    if (j + 1 == size) toAdd += EscenaIJ[j];
                    else if (j + 2 == size) toAdd += EscenaIJ[j] + " y ";
                    else toAdd += EscenaIJ[j] + ", ";
                }
                if ( i == 0) toAdd += " indican un alto grado de malestar psicológico";
                if (EscenasAltasss[i] == 1) toAdd += " a la hora de presentarse a su compañera";
                else if (EscenasAltasss[i] == 2) toAdd += " a la hora de intervenir en la primera conversación";
                else if (EscenasAltasss[i] == 3) toAdd += " a la hora de intervenir en la conversación en la que se le interpela";
                else toAdd += " a la hora de llamar al camarero";

                if (i + 1 == EscenasAltasss.Count) toAdd += ".";
                else if (i + 2 == EscenasAltasss.Count) toAdd += " y los de ";
                else toAdd += ", los de ";
            }
            Diagnostico.text += toAdd;

            /*
            size = EmocionesAltasEscena1.Count;
            if(EmocionesAltasEscena1.Count > 1)
            {
                for(int i = 0; i > size; ++i)
                {
                    if (i + 1 == size) toAdd += EmocionesAltasEscena1[i];
                    else if (i + 2 == size) toAdd += EmocionesAltasEscena1[i] + " y ";
                    else toAdd += EmocionesAltasEscena1[i] + ", ";
                }

            }

            if(EmocionesAltasEscena2.Count > 0)
            {
                size = EmocionesAltasEscena2.Count;
                for (int i = 0; i < size; ++i)
                {
                    if (i + 1 == size) toAdd += EmocionesAltasEscena2[i];
                    else if (i + 2 == size) toAdd += EmocionesAltasEscena2[i] + " y ";
                    else toAdd += EmocionesAltasEscena2[i] + ", ";
                }
            }
            */

        }
        //HAY Escenas MEDIAS?
        if(EscenasMediasss.Count > 0)
        {
            Debug.Log("Escenas medias > 2");
            toAdd = " Además, aunque en menor medida, tambien se ha detectado cierto malestar a la hora de";
            for(int i = 0; i < EscenasMediasss.Count; ++i)
            {
                int a = EscenasMediasss[i];


                if (a == 1) toAdd += " presentarse a su compañera";
                else if (a == 2) toAdd += " intervenir en la primera conversación";
                else if (a == 3) toAdd += " intervenir en la conversación en la que se le interpela";
                else toAdd += " llamar al camarero";

                if (i + 1 == EscenasMediasss.Count) toAdd += ".";
                else if (i + 2 == EscenasMediasss.Count) toAdd += " y";
                else if (i + 1 < EscenasMediasss.Count) toAdd += ", ";
            }
            Diagnostico.text += toAdd;
        }
        /*
        int aux1, aux2, aux3, aux4 = 0;

        //AL COMBINAR CON DECISIONES LAS ESCENAS ALTAS PUEDEN SER INCLUSO 1, NO solo 3 O 4

        if(EscenasAltas.Count == 3)
        {
            aux1 = EscenasAltas[0];
            aux2 = EscenasAltas[1];
            aux3 = EscenasAltas[2];
        }
        else if (EscenasAltas.Count == 2)
        {
            aux1 = EscenasAltas[0];
            aux2 = EscenasAltas[1];
        }
        else if (EscenasAltas.Count == 1)
        {
            aux1 = EscenasAltas[0];
        }
        else if (EscenasAltas.Count == 4)
        {
            aux1 = EscenasAltas[0];
            aux2 = EscenasAltas[1];
            aux3 = EscenasAltas[2];
            aux4 = EscenasAltas[3];
        }

        int EscenaMedia = 0;

        if (EmocionesMediasEscena1.Count > 1)
        {
            if (aux4 == 0 & aux1 != 1 & aux2 != 1 & aux3 != 1)
            {
                EscenaMedia = 1;
            }
        }

        if (EmocionesMediasEscena2.Count > 1)
        {
            if (aux4 == 0 & aux1 != 2 & aux2 != 2 & aux3 != 2)
            {
                EscenaMedia = 2;
            }
        }

        if (EmocionesMediasEscena3.Count > 1)
        {
            if (aux4 == 0 & aux1 != 3 & aux2 != 3 & aux3 != 3)
            {
                EscenaMedia = 3;
            }
        }

        if (EmocionesMediasEscena4.Count > 1)
        {
            if (aux4 == 0 & aux1 != 4 & aux2 != 4 & aux3 != 4)
            {
                EscenaMedia = 4;
            }
        }
        Debug.Log("Llego a encontrar la escena media?");


        if (EscenaMedia != 0)
        {
            toAdd = "Además, también se han detectado ciertos síntomas a la hora de ";
            if (EscenaMedia == 1) toAdd += "presentarse a su compañera";
            else if (EscenaMedia == 2) toAdd += "intervenir en la primera conversación";
            else if (EscenaMedia == 3) toAdd += "intervenir en la segunda conversación";
            else if (EscenaMedia == 4) toAdd += "llamar al camarero";
            toAdd += " que, si bien el resultado no es del todo negativo, sí podría llegar a empeorar si no se trata el caso. ";

            Diagnostico.text += toAdd;
        }
        */
    }

    private void WriteDiagnosticoMedio()
    {
     /*   Diagnostico.text = "Si bien no se han detectado resultados realmente significativos, al jugador le podría ayudar acudir a profesionales para" +
            "profundizar en su caso. Lo ideal sería observar cómo va evolucionando su situación ya que puede ser" +
            "propenso a empeorar. Se recomendaría repetir la prueba más adelante.";*/

        Diagnostico.text = "En esta prueba se han detectado resultados que indican un posible malestar psicológico en base a las emociones experimentadas." +
            " No obstante, el nivel de malestar no es clínicamente significativo. Sin embargo, se recomienda que el jugador consulte con un profesional para" +
            " evaluar su caso en profundidad y observar su evolución, ya que puede ser propenso a empeorar.";

        string toAdd = " Los altos niveles de ";
        int size;
        Debug.Log("EscenasAltasss:" + EscenasAltasss.Count);
        bool HayEscenasAltas = false;
        if (EscenasAltasss.Count > 0)
        {
            HayEscenasAltas = true;
            for (int i = 0; i < EscenasAltasss.Count; ++i)
            {
                List<string> EscenaIJ = new List<string>();
                if (EscenasAltasss[i] == 1) EscenaIJ = EmocionesAltasEscena1;
                else if (EscenasAltasss[i] == 2) EscenaIJ = EmocionesAltasEscena2;
                else if (EscenasAltasss[i] == 3) EscenaIJ = EmocionesAltasEscena3;
                else EscenaIJ = EmocionesAltasEscena4;

                size = EscenaIJ.Count;
                for (int j = 0; j < size; ++j)
                {
                    if (j + 1 == size) toAdd += EscenaIJ[j];
                    else if (j + 2 == size) toAdd += EscenaIJ[j] + " y ";
                    else toAdd += EscenaIJ[j] + ", ";
                }
                if (i == 0) toAdd += " indican un alto grado de malestar psicológico";
                if (EscenasAltasss[i] == 1) toAdd += " a la hora de presentarse a su compañera";
                else if (EscenasAltasss[i] == 2) toAdd += " a la hora de intervenir en la primera conversación";
                else if (EscenasAltasss[i] == 3) toAdd += " a la hora de intervenir en la conversación en la que se le interpela";
                else toAdd += " a la hora de llamar al camarero";

                if (i + 1 == EscenasAltasss.Count) toAdd += ".";
                else if (i + 2 == EscenasAltasss.Count) toAdd += " y los de ";
                else toAdd += ", los de ";
            }
            Diagnostico.text += toAdd;
        }

        if (EscenasMediasss.Count > 0)
        {
            Debug.Log("Escenas medias > 2");
            if(HayEscenasAltas) toAdd = " Además, aunque en menor medida, tambien se ha detectado cierto malestar a la hora de";
            else toAdd = " Se ha detectado cierto malestar a la hora de";

            for (int i = 0; i < EscenasMediasss.Count; ++i)
            {
                int a = EscenasMediasss[i];


                if (a == 1) toAdd += " presentarse a su compañera";
                else if (a == 2) toAdd += " intervenir en la primera conversación";
                else if (a == 3) toAdd += " intervenir en la conversación en la que se le interpela";
                else toAdd += " llamar al camarero";

                if (i + 1 == EscenasMediasss.Count) toAdd += ".";
                else if (i + 2 == EscenasMediasss.Count) toAdd += " y";
                else if (i + 1 < EscenasMediasss.Count) toAdd += ", ";
            }
            Diagnostico.text += toAdd;
        }
        /*
        List<int> QueEscenasNum = new List<int>();
        List<List<string>> EmocionesAltasTotales = new List<List<string>>();
        if (EmocionesAltasEscena1.Count > 1)
        {
            EmocionesAltasTotales.Add(EmocionesAltasEscena1);
            QueEscenasNum.Add(1);
        }
        if (EmocionesAltasEscena2.Count > 1)
        {
            EmocionesAltasTotales.Add(EmocionesAltasEscena2);
            QueEscenasNum.Add(2);
        }
        if (EmocionesAltasEscena3.Count > 1)
        {
            EmocionesAltasTotales.Add(EmocionesAltasEscena3);
            QueEscenasNum.Add(3);
        }
        if (EmocionesAltasEscena4.Count > 1)
        {
            EmocionesAltasTotales.Add(EmocionesAltasEscena4);
            QueEscenasNum.Add(4);
        }

        //El mismo error, no tiene porque haber 2 escenas altas exactamente
        string toAdd = "";

        bool HayEscenasAltas = false;
        if(EscenasAltasss.Count > 0)
        {
            HayEscenasAltas = true;
            toAdd = "Donde mayores problebas se han detectado ha sido cuando el jugador debía";

            for(int i = 0; i < EscenasAltasss.Count; ++i)
            {
                int a = EscenasAltasss[i];

                if (i + 1 == EscenasAltasss.Count & i!= 0) toAdd += " y";

                if (a == 1) toAdd += " presentarse a su compañera";
                else if (a == 2) toAdd += " intervenir en la primera conversación";
                else if (a == 3) toAdd += " intervenir en la segunda conversación";
                else toAdd += " llamar al camarero";

                if (i + 1 == EscenasAltasss.Count) toAdd += ".";
                else if (i + 1 < EscenasAltasss.Count) toAdd += ", ";
            }
            Diagnostico.text += toAdd;
        }
        if (EscenasMediasss.Count> 0)
        {
            if (HayEscenasAltas) toAdd += " Además, también se ";
            else toAdd += " Se ha encontrado ciertos niveles a la hora de ";

            for (int i = 0; i < EscenasMediasss.Count; ++i)
            {
                int a = EscenasMediasss[i];

                if (i + 1 == EscenasMediasss.Count) toAdd += " y";

                if (a == 1) toAdd += " presentarse a su compañera";
                else if (a == 2) toAdd += " intervenir en la primera conversación";
                else if (a == 3) toAdd += " intervenir en la segunda conversación";
                else toAdd += " llamar al camarero";

                if (i + 1 == EscenasMediasss.Count) toAdd += ".";
                else if (i + 1 < EscenasMediasss.Count) toAdd += ", ";
            }
            Diagnostico.text += toAdd;
        }



        /*
        int aux = QueEscenasNum[0];
        if (aux == 1) toAdd += "debía presentarse a su compañera y cuando ";
        else if (aux == 2) toAdd += "debía participar en la 1a conversación y cuando ";
        else if (aux == 3) toAdd += "debía participar en la 2a conversación y cuando ";
        else if (aux == 4) toAdd += "debía llamar al camerero y cuando ";

        aux = QueEscenasNum[1];
        if (aux == 1) toAdd += "debía presentarse a su compañera.";
        else if (aux == 2) toAdd += "debía participar en la 1a conversación.";
        else if (aux == 3) toAdd += "debía participar en la 2a conversación.";
        else if (aux == 4) toAdd += "debía llamar al camerero.";

        Diagnostico.text += toAdd;

        toAdd = "";
        for (int i = 0; i < EmocionesAltasTotales.Count; ++i)
        {
            if (i == 0)
            {
                toAdd += " En ambas se han detectado ciertas emociones considerablemente alteradas," +
                    " como  ";
            }
            else toAdd += " y ";

            for (int j = 0; j < EmocionesAltasTotales[i].Count; ++j)
            {
                if (j + 1== EmocionesAltasTotales[i].Count) toAdd += EmocionesAltasTotales[i][j];
                else if (j + 2 == EmocionesAltasTotales[i].Count) toAdd += EmocionesAltasTotales[i][j]+ " y ";
                else toAdd += EmocionesAltasTotales[i][j] + ", ";

            }
            if (i == 0) toAdd += " en el primer caso";
            else toAdd += " en el segundo.";
        }

        Diagnostico.text += toAdd;

        //EMOCIONES MEDIAS 

        //HAY EMOCIONES MEDIAS?

        int aux1, aux2;

        aux1 = QueEscenasNum[0];
        aux2 = QueEscenasNum[1];

        int EscenaMedia1 = 0;
        int EscenaMedia2 = 0;

        if (EmocionesMediasEscena1.Count > 1)
        {
            if (aux1 != 1 & aux2 != 1) EscenaMedia1 = 1;
        }

        if (EmocionesMediasEscena2.Count > 1)
        {
            if (aux1 != 2 & aux2 != 2)
            {
                if (EscenaMedia1 == 0) EscenaMedia1 = 2;
                else EscenaMedia2 = 2;
            }
        }

        if (EmocionesMediasEscena3.Count > 1)
        {
            if (aux1 != 3 & aux2 != 3)
            {
                if (EscenaMedia1 == 0) EscenaMedia1 = 3;
                else EscenaMedia2 = 3;
            }
        }

        if (EmocionesMediasEscena4.Count > 1)
        {
            if (aux1 != 4 & aux2 != 4)
            {
                if (EscenaMedia1 == 0) EscenaMedia1 = 4;
                else EscenaMedia2 = 4;
            }
        }

        int size = 0;
        if (EscenaMedia1 != 0) ++size;
        if (EscenaMedia2 != 0) ++size;  

        if(size > 0)
        {
            toAdd = "Además, también se han detectado ciertos síntomas a la hora de ";
            if (EscenaMedia1 == 1) toAdd += "presentarse a su compañera";
            else if (EscenaMedia1 == 2) toAdd += "intervenir en la primera conversación";
            else if (EscenaMedia1 == 3) toAdd += "intervenir en la segunda conversación";
            else if (EscenaMedia1 == 4) toAdd += "llamar al camarero";


            if (size == 2)
            {
                toAdd += " y de ";
                if (EscenaMedia2 == 1) toAdd += "presentarse a su compañera ";
                else if (EscenaMedia2 == 2) toAdd += "intervenir en la primera conversación";
                else if (EscenaMedia2 == 3) toAdd += "intervenir en la segunda conversación ";
                else if (EscenaMedia2 == 4) toAdd += "llamar al camarero ";
            }

            toAdd += " que, si bien el resultado no es del todo negativo, sí podría llegar a empeorar si no se trata el caso. ";
            Diagnostico.text += toAdd;

        }
        */
    }

    private void WriteDiagnosticoBajo()
    {
        Diagnostico.text = "\nEl jugador no muestra síntomas de padecer fobia social. Los resultados son positivos y no se han detectado alteraciones en "+
            "las emociones del jugador. En base a esto, se deduce que el jugador no experimenta malestar psicológico en situaciones similares de la vida real.";/*
        Diagnostico.text += "El jugador no muestra síntomas de padecer fobia social. Los resultados son positivos y no se han detectado alteraciones en " +
    "las emociones del jugador ni decisiones fuera de lo común. ";        Diagnostico.text += "El jugador no muestra síntomas de padecer fobia social. Los resultados son positivos y no se han detectado alteraciones en " +
    "las emociones del jugador ni decisiones fuera de lo común. ";        Diagnostico.text += "El jugador no muestra síntomas de padecer fobia social. Los resultados son positivos y no se han detectado alteraciones en " +
    "las emociones del jugador ni decisiones fuera de lo común. ";        Diagnostico.text += "El jugador no muestra síntomas de padecer fobia social. Los resultados son positivos y no se han detectado alteraciones en " +
    "las emociones del jugador ni decisiones fuera de lo común. ";        Diagnostico.text += "El jugador no muestra síntomas de padecer fobia social. Los resultados son positivos y no se han detectado alteraciones en " +
    "las emociones del jugador ni decisiones fuera de lo común. \n ";*/

    }

    private void CuantosEnEscena1()
    {
        Calcula_BIEN_NORMAL_MAL_Escena1(Emocion1Escena1Valor, "vergüenza");
        Calcula_BIEN_NORMAL_MAL_Escena1(Emocion2Escena1Valor, "miedo");
        Calcula_BIEN_NORMAL_MAL_Escena1(Emocion3Escena1Valor, "indecisión");
        Calcula_BIEN_NORMAL_MAL_Escena1(Emocion4Escena1Valor, "intranquilidad");
        Calcula_BIEN_NORMAL_MAL_Escena1(Emocion5Escena1Valor, "paralización");
        Calcula_BIEN_NORMAL_MAL_Escena1(Emocion6Escena1Valor, "indiferencia");
    }

    private void CuantosEnEscena2()
    {
        Calcula_BIEN_NORMAL_MAL_Escena2(Emocion1Escena2Valor, "vergüenza");
        Calcula_BIEN_NORMAL_MAL_Escena2(Emocion2Escena2Valor, "miedo");
        Calcula_BIEN_NORMAL_MAL_Escena2(Emocion3Escena2Valor, "indecisión");
        Calcula_BIEN_NORMAL_MAL_Escena2(Emocion4Escena2Valor, "intranquilidad");
        Calcula_BIEN_NORMAL_MAL_Escena2(Emocion5Escena2Valor, "paralización");
        Calcula_BIEN_NORMAL_MAL_Escena2(Emocion6Escena2Valor, "indiferencia");
    }

    private void CuantosEnEscena3()
    {
        Calcula_BIEN_NORMAL_MAL_Escena3(Emocion1Escena3Valor, "vergüenza");
        Calcula_BIEN_NORMAL_MAL_Escena3(Emocion2Escena3Valor, "miedo");
        Calcula_BIEN_NORMAL_MAL_Escena3(Emocion3Escena3Valor, "enfado");
        Calcula_BIEN_NORMAL_MAL_Escena3(Emocion4Escena3Valor, "intranquilidad");
        Calcula_BIEN_NORMAL_MAL_Escena3(Emocion5Escena3Valor, "paralización");
        Calcula_BIEN_NORMAL_MAL_Escena3(Emocion6Escena3Valor, "indiferencia");
    }

    private void CuantosEnEscena4()
    {
        Calcula_BIEN_NORMAL_MAL_Escena4(Emocion1Escena4Valor, "vergüenza");
        Calcula_BIEN_NORMAL_MAL_Escena4(Emocion2Escena4Valor, "miedo");
        Calcula_BIEN_NORMAL_MAL_Escena4(Emocion3Escena4Valor, "indecisión");
        Calcula_BIEN_NORMAL_MAL_Escena4(Emocion4Escena4Valor, "intranquilidad");
        Calcula_BIEN_NORMAL_MAL_Escena4(Emocion5Escena4Valor, "paralización");
        Calcula_BIEN_NORMAL_MAL_Escena4(Emocion6Escena4Valor, "tensión");
    }

    private void Calcula_BIEN_NORMAL_MAL_Escena1(float Emocion, string EmocionString)
    {
        if (Emocion >= 0f & Emocion <= 4f) ++Escena1BIEN;
        else if (Emocion >= 5f & Emocion <= 7) { ++Escena1NORMAL; EmocionesMediasEscena1.Add(EmocionString); }
        else if (Emocion >= 8f & Emocion <= 10){ ++Escena1MAL; EmocionesAltasEscena1.Add(EmocionString);}
    }

    private void Calcula_BIEN_NORMAL_MAL_Escena2(float Emocion, string EmocionString)
    {
        if (Emocion >= 0f & Emocion <= 4f) ++Escena2BIEN;
        else if (Emocion >= 5f & Emocion <= 7) { ++Escena2NORMAL; EmocionesMediasEscena2.Add(EmocionString); }
        else if (Emocion >= 8f & Emocion <= 10) {++Escena2MAL; EmocionesAltasEscena2.Add(EmocionString);}
    }

    private void Calcula_BIEN_NORMAL_MAL_Escena3(float Emocion, string EmocionString)
    {
        if (Emocion >= 0f & Emocion <= 4f) ++Escena3BIEN;
        else if (Emocion >= 5f & Emocion <= 7) { ++Escena3NORMAL; EmocionesMediasEscena3.Add(EmocionString); }
        else if (Emocion >= 8f & Emocion <= 10) { ++Escena3MAL; EmocionesAltasEscena3.Add(EmocionString); }
    }

    private void Calcula_BIEN_NORMAL_MAL_Escena4(float Emocion, string EmocionString)
    {
        if (Emocion >= 0f & Emocion <= 4f) ++Escena4BIEN;
        else if (Emocion >= 5f & Emocion <= 7) { ++Escena4NORMAL; EmocionesMediasEscena4.Add(EmocionString); }
        else if (Emocion >= 8f & Emocion <= 10) { ++Escena4MAL; EmocionesAltasEscena4.Add(EmocionString); }
    }
    
    IEnumerator CoroutineFadeOUT()
    {
        yield return new WaitForSeconds(2);
        Panel.SetActive(false);
    }

    IEnumerator CoroutinePlayAgain()
    {
        yield return new WaitForSeconds(10);
        PlayAgainButton.gameObject.SetActive(true);
        PlayAgainButton.onClick.AddListener(StartGameAgain);
    }

    private void StartGameAgain()
    {
        Panel.SetActive(true);
        animator.SetBool("FadeIn", true);
        StartCoroutine(PlayAgain());
    }

    IEnumerator PlayAgain()
    {
        yield return new WaitForSeconds(2);
        PresentedHerself = false;
        TalkInFirstScene = false;
        TalkInSecondScene= false;
        CalledTheWairtess= false;
        SceneManager.LoadScene("BeginScene");
    }

}