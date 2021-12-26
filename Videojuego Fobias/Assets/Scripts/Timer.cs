using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float duration;
    public Image fillImage;
    // Start is called before the first frame update
    void Start()
    {
     //   fillImage = GameObject.FindGameObjectWithTag("Timer2").GetComponent<Image>();
        fillImage.fillAmount = 1f;
      //  StartCoroutine(MyTimer(duration));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator MyTimer(float duration)
    {
        //  fillImage.fillAmount = 1f;
        //   fillImage.fillAmount = 1f;
        Debug.Log("La llamada se hace bien");
        float startTime = Time.time;
        float time = duration;
        float value = 0;

        while(Time.time - startTime < duration)
        {
            time -= Time.deltaTime;
            value = time / duration;
            fillImage.fillAmount = value;
            yield return null;
        }
    }
}
