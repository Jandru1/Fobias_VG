using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviours2ndScene : MonoBehaviour
{

    public Animator CarlosAnimator;
    public Animator AlbaAnimator;
    public Animator SaraAnimator;
    public Animator ProtagonistAnimator;
    bool HasChosenOption = false;
    public WPActor WairtressScript;

    public static bool HasDoneBothSituations = false;
    UI SayThat;
    // Start is called before the first frame update
    void Start()
    {
        SayThat = GetComponent<UI>();
        StartCoroutine(WaitForCorrectCamera());   
    }

    // Update is called once per frame
    void Update()
    {
        HasChosenOption = SayThat.HasChosenOption;
    }

    IEnumerator WaitForCorrectCamera()
    {
        yield return new WaitForSeconds(23);
        if (!Solutions.PresentedHerself) StartCoroutine(AlbaAsksForMyName());
        else StartCoroutine(CarlosWantsCofee());
    }

    IEnumerator AlbaAsksForMyName()
    {
        AlbaAnimator.SetBool("isTalking", true);
        SayThat.SayThat("Alba: Oye, �y t� c�mo te llamas?");
        yield return new WaitForSeconds(3);
        AlbaAnimator.SetBool("isTalking", false);
        ProtagonistAnimator.SetBool("isTalking", true);
        SayThat.PresentYourself();
        yield return new WaitForSeconds(3);
        ProtagonistAnimator.SetBool("isTalking", false);

        StartCoroutine(CarlosWantsCofee());
    }

    IEnumerator CarlosWantsCofee()
    {
        //UISayThat.SayThat("Los dos de aqu� enfrente me han propuesto ir a tomar algo al bar ahora");
        CarlosAnimator.SetBool("isTalking", true);
        SayThat.SayThat("Carlos: Puede que me pida otro cafe. Me tengo que levantar a las 06:00 cada d�a");
        yield return new WaitForSeconds(3);
        SayThat.SayThat("Carlos: para llegar a la uni y estoy muerto de sue�o");
        yield return new WaitForSeconds(3);
        CarlosAnimator.SetBool("isTalking", false);

        StartCoroutine(SaraIsLazy());
    }


    IEnumerator SaraIsLazy()
    {
        SaraAnimator.SetBool("isTalking", true);
        SayThat.SayThat("Sara: Uff... �Qu� pereza! Yo por suerte tengo el bus delante de casa");
        yield return new WaitForSeconds(3);
        SayThat.SayThat("Sara: y en 20 minutos llego");
        yield return new WaitForSeconds(3);
        SaraAnimator.SetBool("isTalking", false);

        StartCoroutine(AlbaSame());
    }

    IEnumerator AlbaSame()
    {
        AlbaAnimator.SetBool("isTalking", true);
        SayThat.SayThat("Alba: S�, yo igual, y menos mal. Lo m�o no es madrugar");
        yield return new WaitForSeconds(3);
        AlbaAnimator.SetBool("isTalking", false);

        StartCoroutine(Protagonist1stDecision());
    }

    IEnumerator Protagonist1stDecision()
    {
        SayThat.ActiveOptions();
        SayThat.Set1stDecisions();
        SayThat.StartTheTimer();
        yield return new WaitUntil(() => SayThat.HasChosenOption == true);
        bool leftpressed = SayThat.LeftOptionChosen();
        if (!SayThat.HasExceededTimer())
        {
            ProtagonistAnimator.SetBool("isTalking", true);
            if (leftpressed) SayThat.ProtagonistSayThat("T�: jajaja lo m�o tampoco es madurgar. �Q�e fuerza de voluntad Carlos!");
            else SayThat.ProtagonistSayThat("T�: Pues yo soy de levantarme pronto, as� aprovecho el d�a");
            yield return new WaitForSeconds(3);
            ProtagonistAnimator.SetBool("isTalking", false);
        }
        StartCoroutine(SaraAsksForDegree());
    }
    
    IEnumerator SaraAsksForDegree()
    {
        SaraAnimator.SetBool("isTalking", true);
        SayThat.SayThat("Sara: Bueno, y vosotros, �por qu� habeis escogido esta carrera?");
        yield return new WaitForSeconds(3);
        SaraAnimator.SetBool("isTalking", false);

        StartCoroutine(AlbaForDiscard());
    }

    IEnumerator AlbaForDiscard()
    {
        AlbaAnimator.SetBool("isTalking", true);
        SayThat.SayThat("Alba: Pues un poco por descarte, si te digo la verdad...");
        yield return new WaitForSeconds(3);
        AlbaAnimator.SetBool("isTalking", false);

        StartCoroutine(SaraVocational());
    }

    IEnumerator SaraVocational()
    {
        SaraAnimator.SetBool("isTalking", true);
        SayThat.SayThat("Sara: �En serio? �Yo siempre he sabido que quer�a estudiar esto!");
        yield return new WaitForSeconds(3);
        SaraAnimator.SetBool("isTalking", false);

        StartCoroutine(CarlosForProfesionalsOutgoings());
    }

    IEnumerator CarlosForProfesionalsOutgoings()
    {
        CarlosAnimator.SetBool("isTalking", true);
        SayThat.SayThat("Carlos: Yo tan claro no lo ten�a, pero creo que se me puede dar bien");
        yield return new WaitForSeconds(3);
        SayThat.SayThat("Carlos: y las salidas profesionales son buenas");
        yield return new WaitForSeconds(3);
        CarlosAnimator.SetBool("isTalking", false);

        StartCoroutine(Protagonist2ndDecision());
    }

    IEnumerator Protagonist2ndDecision()
    {
        SayThat.ActiveOptions();
        SayThat.Set2ndDecisions();
        SayThat.StartTheTimer();
        yield return new WaitUntil(() => SayThat.HasChosenOption == true);
        bool leftpressed = SayThat.LeftOptionChosen();
        if (!SayThat.HasExceededTimer())
        {
            ProtagonistAnimator.SetBool("isTalking", true);
            if (!leftpressed)
            {
                SayThat.ProtagonistSayThat("T�: La verdad, he o�do que tiene muchas salidas profesionales");
                yield return new WaitForSeconds(3);
                SayThat.ProtagonistSayThat("T�: y que se gana dinero");
            }
            else SayThat.ProtagonistSayThat("T�: Para m� es algo vocacional, me interesa desde peque�o");
            yield return new WaitForSeconds(3);
            ProtagonistAnimator.SetBool("isTalking", false);
        }

        HasDoneBothSituations = true;

        StartCoroutine(SaraLikesTheVarietyOfReasons());
    }

    IEnumerator SaraLikesTheVarietyOfReasons()
    {
        SaraAnimator.SetBool("isTalking", true);
        SayThat.SayThat("Sara: Veo que hay variedad de motivos, �muy bien!");
        yield return new WaitForSeconds(3);
        SaraAnimator.SetBool("isTalking", false);

        StartCoroutine(CarlosWantsTheBill());
    }

    IEnumerator CarlosWantsTheBill()
    {
        CarlosAnimator.SetBool("isTalking", true);
        SayThat.SayThat("Carlos: No quiero ser aguafiestas, pero la pr�xima clase empieza en 5 minutos...");
        yield return new WaitForSeconds(3);
        SayThat.SayThat("Carlos: Deber�amos irnos ya");
        yield return new WaitForSeconds(3);
        CarlosAnimator.SetBool("isTalking", false);

        StartCoroutine(AlbaSaysItsTrue());
    }

    IEnumerator AlbaSaysItsTrue()
    {
        AlbaAnimator.SetBool("isTalking", true);
        SayThat.SayThat("Alba: �S�, es verdad! Si veis al camarero pedid la cuenta");
        yield return new WaitForSeconds(3);
        AlbaAnimator.SetBool("isTalking", false);

        StartCoroutine(ProtagonistHasToAskForTtheBill());
    }

    IEnumerator ProtagonistHasToAskForTtheBill()
    {
        SayThat.ActiveSpacebarForWairtress();
        SayThat.StartTheTimer();
        SayThat.DesactiveHasChosenOption();
        yield return new WaitUntil(() => SayThat.HasChosenOption == true);
        if (SayThat.HasCalledWairtress)
        {
            ProtagonistAnimator.SetBool("isTalking", true);
            SayThat.ProtagonistSayThat("T�: �Perdona!");
            WairtressScript.TheyCalledMe();
            yield return new WaitForSeconds(3);
            SayThat.ProtagonistSayThat("T�: �Nos puedes traer la cuenta por favor?");
            yield return new WaitForSeconds(3);
            ProtagonistAnimator.SetBool("isTalking", false);
            WairtressScript.AskedForBill();
            yield return new WaitForSeconds(3); //Los que tarda el camarero
        }
        else
        {
            SaraAnimator.SetBool("isTalking", true);
            SayThat.SayThat("Sara: �Perdona!");
            WairtressScript.TheyCalledMe();
            yield return new WaitForSeconds(3);
            SayThat.SayThat("Sara: �Nos puedes traer la cuenta por favor?");
            yield return new WaitForSeconds(3);
            SaraAnimator.SetBool("isTalking", false);
            WairtressScript.AskedForBill();
            yield return new WaitForSeconds(3); //Los que tarda el camarero
        }
        StartCoroutine(AlbaSaysPerfect());
    }

    IEnumerator AlbaSaysPerfect()
    {
        AlbaAnimator.SetBool("isTalking", true);
        SayThat.SayThat("Alba: �Perfecto! Llegaremos a tiempo");
        yield return new WaitForSeconds(6);
        AlbaAnimator.SetBool("isTalking", false);
        EndScene();
    }

    void EndScene()
    {
        Animator FadeAnimator = GameObject.FindGameObjectWithTag("Panel").GetComponent<Animator>();
        FadeAnimator.SetBool("FadeIn", true);
        FadeAnimator.SetBool("FadeOut", false);
    }
}
