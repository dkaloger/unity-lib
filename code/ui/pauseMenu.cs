using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class pauseMenu : MonoBehaviour
{
    public placebuildings placeBuildings;
    public bool muted = false;
    public Sprite mute;
    public Sprite unmute;
    public GameObject mutebuton;
    public GameObject MoveToMouseScript;

    public int SceneName;

    public GameObject PlayerControllerScript;

    public  bool GameIsPaused = false;
   public Image myImageComponent;
    public Sprite myFirstImage; 
    public Sprite mySecondImage;
    public GameObject PauseMenu;

    private void Start()
    {
        MoveToMouseScript.GetComponent<movetomouse>();
        PlayerControllerScript.GetComponent<playercontroller>();

    }

    void Update()
    {
   
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused == false)
            {
                pause();
                Debug.Log("Paused");
            }
            else
            {
                resume();
            }
        }
        if (GameIsPaused == true)
        {
            placeBuildings.pauseMenuOn = true;
        }
        else
        {
            placeBuildings.pauseMenuOn = false;
        }
    }
    void resume()
    {
        PlayerControllerScript.GetComponent<playercontroller>().CanScroll();
        PauseMenu.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
    }
    public void pause()
    {
        PauseMenu.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
    }
    //buttons
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void LawScene()
    {
        SceneManager.LoadScene(SceneName);
    }
    public void Mute()
    {
        if(muted == true){
            myImageComponent.sprite = myFirstImage;
            muted = false;
        }
        else if (muted == false)
        {
            myImageComponent.sprite = mySecondImage;
            muted = true;
        }
        Debug.Log("mute");
        AudioListener.pause = !AudioListener.pause;
        //very smart
    }
    public void GetBack()
    {
        SceneManager.LoadScene(1);
    }
}
