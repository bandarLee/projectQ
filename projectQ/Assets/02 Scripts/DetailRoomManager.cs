using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailRoomManager : MonoBehaviour
{
    public Rect roomRect;


    void Start()
    {
        roomRect = Rect.MinMaxRect(this.transform.position.x - 7, this.transform.position.y - 3, this.transform.position.x + 7, this.transform.position.y + 3);

    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        OneEye[] oneeyes = GameManager.Instance.oneeyes;
        OneEye1[] oneeyesred = GameManager.Instance.oneeyesred;
        
        BasicEnemy[] basicEnemy = GameManager.Instance.basicEnemy;
        Virus[] virus = GameManager.Instance.virus;
        Snake[] snake = GameManager.Instance.snake;
        if (other.gameObject.CompareTag("Player")) 
        {
            foreach (OneEye oneeye in oneeyes)
            {
          
                if (!oneeye.gameObject.activeInHierarchy && roomRect.Contains(oneeye.gameObject.transform.position))
                        {
                            oneeye.gameObject.SetActive(true);
                        }

            }
            foreach (BasicEnemy basicenemies in basicEnemy)
            {

                if (!basicenemies.gameObject.activeInHierarchy && roomRect.Contains(basicenemies.gameObject.transform.position))
                {
                    basicenemies.gameObject.SetActive(true);
                }

            }
            foreach (Virus viruses in virus)
            {

                if (!viruses.gameObject.activeInHierarchy && roomRect.Contains(viruses.gameObject.transform.position))
                {
                    viruses.gameObject.SetActive(true);
                }

            }
            foreach (Snake snakes in snake)
            {

                if (!snakes.gameObject.activeInHierarchy && roomRect.Contains(snakes.gameObject.transform.position))
                {
                    snakes.gameObject.SetActive(true);
                }

            }


        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        OneEye[] oneeyes = GameManager.Instance.oneeyes;
       
        OneEye1[] oneeyesred = GameObject.FindObjectsOfType<OneEye1>();
        BasicEnemy[] basicEnemy = GameObject.FindObjectsOfType<BasicEnemy>();
        Virus[] virus = GameObject.FindObjectsOfType<Virus>();
        Snake[] snake = GameObject.FindObjectsOfType<Snake>();

        if (other.gameObject.CompareTag("Player"))
        {
            foreach (OneEye oneeye in oneeyes)
            {
                if (oneeye.gameObject.activeInHierarchy && roomRect.Contains(oneeye.gameObject.transform.position))
                {
                    oneeye.gameObject.SetActive(false);
                }
            }
            foreach (OneEye1 oneeyered in oneeyesred)
            {
                if (oneeyered.gameObject.activeInHierarchy && roomRect.Contains(oneeyered.gameObject.transform.position))
                {
                    oneeyered.gameObject.SetActive(false);
                }
            }
            foreach (BasicEnemy basicenemies in basicEnemy)
            {
                if (basicenemies.gameObject.activeInHierarchy && roomRect.Contains(basicenemies.gameObject.transform.position))
                {
                    basicenemies.gameObject.SetActive(false);
                }
            }
            foreach (Virus viruses in virus)
            {
                if (viruses.gameObject.activeInHierarchy && roomRect.Contains(viruses.gameObject.transform.position))
                {
                    viruses.gameObject.SetActive(false);
                }
            }
            foreach (Snake snakes in snake)
            {
                if (snakes.gameObject.activeInHierarchy && roomRect.Contains(snakes.gameObject.transform.position))
                {
                    snakes.gameObject.SetActive(false);
                }
            }
        }

    }
}
