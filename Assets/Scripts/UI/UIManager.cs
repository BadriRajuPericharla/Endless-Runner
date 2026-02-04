
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]GameObject SettingsPannel;
    [SerializeField]GameObject MainMenuPannel;
    [SerializeField]GameObject CountdownPannel;
    [SerializeField]TMPro.TMP_Text CountdownText;
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
            //Time.timeScale=0f;
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
        //Time.timeScale=0f;
    }
    public void ResumeButton()
    {
        StartCoroutine(ResumeCountdown());
    }
    public void HomeButton()
    {   
        SettingsPannel.SetActive(false);
        MainMenuPannel.SetActive(true);
    }
    IEnumerator ResumeCountdown()
    {
        SettingsPannel.SetActive(false);
        CountdownPannel.SetActive(true);
        CountdownText.text="3";
        yield return new WaitForSeconds(1f);
        CountdownText.text="2";
        yield return new WaitForSeconds(1f);
        CountdownText.text="1";
        yield return new WaitForSeconds(1f);
        CountdownPannel.SetActive(false);
        //Time.timeScale=1f;
    }
}
