using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LobbyManager : MonoBehaviour
{
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;
    public GameObject Image4;
    public GameObject Image5;
    public GameObject Image6;
    public GameObject Image7;

    private CanvasGroup canvasGroup1;
    private CanvasGroup canvasGroup2;
    private CanvasGroup canvasGroup3;
    private CanvasGroup canvasGroup4;
    private CanvasGroup canvasGroup5;
    private CanvasGroup canvasGroup6;
    private CanvasGroup canvasGroup7;
        


    public float fadeDuration = 1f; // 페이드 지속 시간
 


    void Awake()
    {
        canvasGroup1 = Image1.GetComponent<CanvasGroup>();
        canvasGroup2 = Image2.GetComponent<CanvasGroup>();
        canvasGroup3 = Image3.GetComponent<CanvasGroup>();
        canvasGroup4 = Image4.GetComponent<CanvasGroup>();
        canvasGroup5 = Image5.GetComponent<CanvasGroup>();
        canvasGroup6 = Image6.GetComponent<CanvasGroup>();
        canvasGroup7 = Image7.GetComponent<CanvasGroup>();

        Image1.SetActive(false);
        Image2.SetActive(false);
        Image3.SetActive(false);
        Image4.SetActive(false);
        Image5.SetActive(false);
        Image6.SetActive(false);
        Image7.SetActive(false);
   
        

    }
    void Start()
    {
        StartCoroutine(StartGameSequence());


    }





    IEnumerator StartGameSequence()
    {

        Image1.SetActive(true);
        StartCoroutine(FadeCanvasGroup(canvasGroup1, 0f, 1f, fadeDuration));
        yield return new WaitForSeconds(4);
        Image2.SetActive(true);
        StartCoroutine(FadeCanvasGroup(canvasGroup2, 0f, 1f, fadeDuration));
        yield return new WaitForSeconds(4);
        Image1.SetActive(false);
        Image3.SetActive(true);
        StartCoroutine(FadeCanvasGroup(canvasGroup3, 0f, 1f, fadeDuration));
        yield return new WaitForSeconds(4);
        Image2.SetActive(false);
        Image4.SetActive(true);
        StartCoroutine(FadeCanvasGroup(canvasGroup4, 0f, 1f, fadeDuration));
        yield return new WaitForSeconds(4);
        Image3.SetActive(false);
        Image5.SetActive(true);
        StartCoroutine(FadeCanvasGroup(canvasGroup5, 0f, 1f, fadeDuration));
        yield return new WaitForSeconds(4);
        Image4.SetActive(false);
        Image6.SetActive(true);
        StartCoroutine(FadeCanvasGroup(canvasGroup6, 0f, 1f, fadeDuration));
        yield return new WaitForSeconds(4);
        Image5.SetActive(false);
        Image7.SetActive(true);
        StartCoroutine(FadeCanvasGroup(canvasGroup7, 0f, 1f, fadeDuration));
        yield return new WaitForSeconds(4);




        SceneManager.LoadScene("DemoScene");
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float duration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            cg.alpha = Mathf.Lerp(start, end, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        cg.alpha = end;
    }
}