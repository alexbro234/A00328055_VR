using UnityEngine;

public class Bounce_sound : MonoBehaviour
{
    public AudioClip bounceSound;
    public Rigidbody rb;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        float impact = collision.relativeVelocity.magnitude;
        float volume = Mathf.Clamp01(impact / 10f);

        audioSource.PlayOneShot(bounceSound, volume);
    }
}