using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FinishPlatformSegment finishPlatformSegment))
        {
            FinishLevel();
        }
    }
    
    private void FinishLevel()
    {
        int level = PlayerPrefs.GetInt("Level");
        level += 1;
        int platformCountForNextLevel = 1 + PlayerPrefs.GetInt("PlatformAmount") ;
        PlayerPrefs.SetInt("PlatformAmount", platformCountForNextLevel);
        PlayerPrefs.SetInt("Level" , level);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
