
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResertLevel : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FinishSegment finishSegment))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
