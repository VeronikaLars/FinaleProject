using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelsButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    public void LoadLevel(int numLvl)
    {
        SceneManager.LoadScene(numLvl);
    }

    public void LoadPanel()
    {
        panel.SetActive(true);
    }

    public void QuitPanel()
    {
        panel.SetActive(false);
    }
}
