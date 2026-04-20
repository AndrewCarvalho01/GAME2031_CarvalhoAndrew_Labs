using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    [SerializeField] private AudioClip spawnSound;
    [SerializeField] private AudioClip explosionSound;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (spawnSound != null)
            audioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            if (explosionSound != null)
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            GameManager.Instance.GameOver();
        }
        else
        {
            GameManager.Instance.AwardPoints(1);
            print("1 Point");
        }
        Destroy(gameObject);
    }
}