using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

namespace Scripts
{
    /// <summary>
    /// Wumpa class, derives from interactable
    /// </summary>
    public class Wumpa : MonoBehaviour, IInteractable
    {
        [SerializeField] private float _respawnTime = 5f;
        [SerializeField] private float _staminaGainAmount = default;
        [SerializeField] private ParticleSystem _particlesIdle = default;
        [SerializeField] private ParticleSystem _particleInteract = default;
        [SerializeField] private AudioSource _source;

        private MeshRenderer _mesh;
        private CapsuleCollider _collider;
        private WaitForSeconds _respawnTimer;

        /// <summary>
        /// Gets components needed for wumpa methods
        /// </summary>
        private void Awake()
        {
            _mesh = gameObject.GetComponent<MeshRenderer>();
            _collider = gameObject.GetComponent<CapsuleCollider>();
            _respawnTimer = new WaitForSeconds(_respawnTime);
        }

        /// <summary>
        /// Wumpa interacts, despawns wumpa and enables particle effect
        /// </summary>
        public void Interact()
        {
            _particleInteract.Play();
            
            Despawn();
        }

        /// <summary>
        /// On trigger enter, wumpa interacts, player adds stamina
        /// </summary>
        /// <param name="collider"> Collider to check if it is a player </param>
        public void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.TryGetComponent(out Player player))
            {
                player.StaminaScript.OnChange(_staminaGainAmount);
            }

            Interact();
        }

        /// <summary>
        /// Hides fruit
        /// </summary>
        private void Despawn()
        {
            _collider.enabled = false;
            _mesh.enabled = false;
            _particlesIdle.gameObject.SetActive(false);

            _source.Play();

            StartCoroutine(TimerRespawn());
        }

        /// <summary>
        /// Respawns fruit
        /// </summary>
        private void Respawn()
        {
            _collider.enabled = true;
            _mesh.enabled = true;
            _particlesIdle.gameObject.SetActive(true);
        }

        /// <summary>
        /// Courotine Timer
        /// </summary>
        /// <returns></returns>
        private IEnumerator TimerRespawn()
        {
            yield return _respawnTimer;

            Respawn();
        }
    }
}
