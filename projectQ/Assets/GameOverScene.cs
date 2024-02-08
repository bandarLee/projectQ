using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{

    public GameObject Image1;


    private CanvasGroup canvasGroup1;


    public float fadeDuration = 1f; // 페이드 지속 시간


    void Awake()
    {
        canvasGroup1 = Image1.GetComponent<CanvasGroup>();
 

        Image1.SetActive(false);

    }

    void Start()
    {
        StartCoroutine(StartGameSequence());

    }

    IEnumerator StartGameSequence()
    {

        Image1.SetActive(true);
        StartCoroutine(FadeCanvasGroup(canvasGroup1, 0f, 1f, fadeDuration));
        yield return new WaitForSeconds(5);
            
      

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

