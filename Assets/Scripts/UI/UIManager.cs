
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]GameObject SettingsPannel;
    [SerializeField]GameObject MainMenuPannel;
    static bool SkipMenu=false;
    void Start()
    {
        if (SkipMenu)
        {
            MainMenuPannel.SetActive(false);
            SkipMenu=false;
        }
        else
        {
            MainMenuPannel.SetActive(true);
        }
    }

    
    void Update()
    {
        
    }
    public void StartButton()
    {
        SkipMenu=true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void ShowSettings()
    {
        SettingsPannel.SetActive(true);
    }
    public void ResumeButton()
    {
        SettingsPannel.SetActive(false);
    }
    public void HomeButton()
    {   
        SettingsPannel.SetActive(false);
        MainMenuPannel.SetActive(true);
    }
}
