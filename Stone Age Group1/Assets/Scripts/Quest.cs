using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quest : MonoBehaviour
{
    [SerializeField] private GameObject exit;
    [SerializeField] private GameObject mushroonEffect;
    [SerializeField] private GameObject taskPanel;
    public bool a;

    private void Start()
    {
        a = true;
    }
    void Update()
    {
        if(a == true)
        {
            taskPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            taskPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ExitMushroom")
        {
            Destroy(collision.gameObject);
            Destroy(mushroonEffect, 0.25f);

            exit.SetActive(true);
        }
    }

    public void TouchOnOk()
    {
        a = false;
    }
}
