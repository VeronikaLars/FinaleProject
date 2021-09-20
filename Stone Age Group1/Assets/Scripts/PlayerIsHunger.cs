using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerIsHunger : MonoBehaviour
{
    [SerializeField] private Image visualHunger;

    [SerializeField] private GameObject friutParticle;
    [SerializeField] private GameObject mushroomParticle;

    [SerializeField] private List<Sprite> Hearts;

    [SerializeField] private Image blackImage;
    [SerializeField] private GameObject redPanel;
    [SerializeField] private GameObject youWin;

    [SerializeField] private Image[] hearts;

    [SerializeField] private float hunger;
    private int index;

    [SerializeField] private GameData gameData;
    void Update()
    {
        Hunger();
        if(Time.timeScale == 0)
        {         
            StopCoroutine(StartHunger());
        }
        else
        {
            StartCoroutine(StartHunger());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Fruit")
        {
            visualHunger.fillAmount += 0.5f;
            GameObject effect = Instantiate(friutParticle, transform.position, friutParticle.transform.rotation);
            Destroy(collision.gameObject);
           
            Destroy(effect, 0.5f);
        }

        if (collision.gameObject.tag == "Mushroom")
        {
            visualHunger.fillAmount -= 0.5f;
            GameObject killEffect = Instantiate(mushroomParticle, transform.position, mushroomParticle.transform.rotation);
            Destroy(collision.gameObject);
     
            Destroy(killEffect, 0.5f);
        }

        if (collision.gameObject.tag == "Exit")
        {  
            youWin.SetActive(true);
            Time.timeScale = 0;

            gameData.OpenLevels++;
            gameData.SaveData();

        }
    }
    private void Hunger()
    {
        if (visualHunger.fillAmount == 0)
        {
            StartCoroutine(BlackHearts());
            
            if (index < 3)
            {
                redPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    IEnumerator StartHunger()
    {
        visualHunger.fillAmount -= hunger / 100; 

        yield return new WaitForSeconds(0.25f);
    }

    IEnumerator BlackHearts()
    {
        for (index = 0; index < 3; index++)
        {
            hearts[index].sprite = blackImage.sprite;

            yield return new WaitForSeconds(0.5f);
        }
    }
}
