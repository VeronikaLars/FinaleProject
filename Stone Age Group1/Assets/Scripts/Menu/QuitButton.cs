using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections;

public class QuitButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Application.Quit();
        Debug.Log("Выход");
    }
}
