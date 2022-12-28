using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Border : MonoBehaviour
{
    [SerializeField] GameObject _destroyParticle;
    [SerializeField] AudioClip[] _collideSounds;

    AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Health.instance.TakeDamage(3);

            GetComponent<MeshRenderer>().enabled = false;
            Instantiate(_destroyParticle, transform.position, _destroyParticle.transform.rotation, transform);
            _audioSource.PlayOneShot(_collideSounds[Random.Range(0, _collideSounds.Length)]);
            Destroy(gameObject, 0.5f);
        }
    }
}
