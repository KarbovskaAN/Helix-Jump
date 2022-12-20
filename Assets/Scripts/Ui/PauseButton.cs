
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PauseButton : MonoBehaviour
{
    public static bool GameIsPaused = false;
    
    public GameObject PauseMenu;
    public GameObject ButtonSound;
    
    public Sprite OffSoundSprite;
    public Sprite ButtonOnSound;

    public AudioSource JumpSound;

    void Start()
    {
        if (PlayerPrefs.GetFloat("CurrentVolume") == 0)
        {
            ButtonSound.GetComponent<Image>().sprite = OffSoundSprite;
        }
        else
        {
            ButtonSound.GetComponent<Image>().sprite = ButtonOnSound;
        }
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Continue()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SwitchSound()
    {
        if (ButtonSound.GetComponent<Image>().sprite == ButtonOnSound)
        {
            ButtonSound.GetComponent<Image>().sprite = OffSoundSprite;
            JumpSound.volume = 0f;
            PlayerPrefs.SetFloat("CurrentVolume", JumpSound.volume);
        }
        else
        {
            ButtonSound.GetComponent<Image>().sprite = ButtonOnSound;
            JumpSound.volume = 1f;
            PlayerPrefs.SetFloat("CurrentVolume", JumpSound.volume);
        }
    }
}
