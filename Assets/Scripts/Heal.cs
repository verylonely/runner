using UnityEngine;

namespace Runner
{
    [RequireComponent(typeof(AudioSource))]
    public class Heal : MonoBehaviour
    {
        [SerializeField] int _value;
        [SerializeField] GameObject _particle;
        [SerializeField] AudioClip[] _healSounds;

        AudioSource audioSource;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                audioSource.PlayOneShot(_healSounds[Random.Range(0, _healSounds.Length)]);
                Instantiate(_particle, transform.position, _particle.transform.rotation, transform);
                Health.instance.Heal(_value);
                Destroy(gameObject, 1f);
            }


        }
    }
}
