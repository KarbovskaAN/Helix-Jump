using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private TowerBuilder _towerBuilder;
    [SerializeField] private Ball _ball;
    [SerializeField] private BallTraking _cameraTraking;
    [SerializeField] private BallTraking _lightTraking;
    [SerializeField] private TMP_Text Level;

    [SerializeField] private AudioSource SoundJump;
    
    void Start()
    {
        Application.targetFrameRate = 90;
        
       int platformCount = GetPlatformCount();
       
       _towerBuilder.Build(platformCount);
       Vector3 ballPosition = _towerBuilder.GetBallPosition();
       _ball.SetPosition(ballPosition);
       
       _cameraTraking.StartTraking();
       _lightTraking.StartTraking();

      Level.text = (PlayerPrefs.GetInt("Level") + 1).ToString();
      
      SoundJump.volume = PlayerPrefs.GetFloat("CurrentVolume");
    }

    private int GetPlatformCount()
    {
        int count = 6 + PlayerPrefs.GetInt("PlatformAmount");
        return count;
    }
}
