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

    private CanvasGroup canvasGroup1;
    private CanvasGroup canvasGroup2;
    private CanvasGroup canvasGroup3;

    public float fadeDuration = 1f; // 페이드 지속 시간
 


    void Awake()
    {
        canvasGroup1 = Image1.GetComponent<CanvasGroup>();
        canvasGroup2 = Image2.GetComponent<CanvasGroup>();
        canvasGroup3 = Image3.GetComponent<CanvasGroup>();
        Image1.SetActive(false);
        Image2.SetActive(false);
        Image3.SetActive(false);
   
        

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

        //SceneManager.LoadScene("Scene3");
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