using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
