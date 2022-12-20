using UnityEngine;

public class Ball : MonoBehaviour
{
    public ParticleSystem Blood;
    public AudioClip JumpSound;
    [SerializeField] private Animator _animator;

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlatformSegment2 platformSegment2))
        {
            other.GetComponentInParent<Platform>().Break();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        ParticleSystem a = Instantiate(Blood);
        a.transform.position = gameObject.transform.position;
        GetComponent<AudioSource>().PlayOneShot(JumpSound);
        _animator.SetTrigger("Jump");
    }
}
