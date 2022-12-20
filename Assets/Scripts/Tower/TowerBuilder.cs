using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class TowerBuilder : MonoBehaviour
{
    private float _beamSizeForLevel = 2f;
     private float _platformDistance = 2;
    [SerializeField] private GameObject _beam;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private FinishPlatform _finishPlatform;
    [SerializeField] private Platform[] _platform;
    private float _additionalSizeForBeam = 5f;

    private Vector3 _ballSpawnPosition;

    public void Build(int platformCount )
    {
        GameObject beam = Instantiate(_beam,transform);
        beam.transform.localScale = new Vector3(1.5f, platformCount * _beamSizeForLevel + 2 + _additionalSizeForBeam + 0.5f, 1.5f);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y/2 - _additionalSizeForBeam - 0.25f;

        SpawnFirstPlatform(ref spawnPosition);
        
         for (int i = 0; i < platformCount ; i++)
         {
          SpawnPlatform1(_platform[Random.Range(0,_platform.Length)] , ref spawnPosition, transform);  
         }
        
         SpawnPlatform1(_finishPlatform, ref spawnPosition , transform);
    }

    public Vector3 GetBallPosition()
    {
        return _ballSpawnPosition;
    }

    private void SpawnFirstPlatform(ref Vector3 spawnPosition)
    {
        Platform p =  SpawnPlatform1(_spawnPlatform, ref spawnPosition , transform);
        _ballSpawnPosition = p.gameObject.transform.GetChild(1).position;
    }
    
    private Platform  SpawnPlatform1(Platform platform , ref Vector3 spawnPosition , Transform parent)
    {
        Platform platf = Instantiate(platform, spawnPosition, Quaternion.Euler(0,Random.Range(0,360) ,0), parent);
        spawnPosition.y -= _platformDistance;
        return platf;
    }
    

    public void DeletPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
 