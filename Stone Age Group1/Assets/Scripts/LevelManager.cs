using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameData gameData;

    private void Start()
    {
        gameData.OpenLevels = gameData.GetData(gameData.openLevelsValueName);

        for (int i = 0; i < transform.childCount; i++)
        {
            if (i < gameData.OpenLevels)
            {
                transform.GetChild(i).GetComponent<Button>().interactable = true;  //sprite level is open
            }
            else
            {
                transform.GetChild(i).GetComponent<Button>().interactable = false; //sprite level is quit
            }
        }
    }

    private void OnApplicationQuit()
    {
        gameData.SaveData(gameData.openLevelsValueName, gameData.OpenLevels);
    }

    public void Exit()
    {
        OnApplicationQuit();
    }
}
