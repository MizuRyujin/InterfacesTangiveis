using System;
using System.Collections;
using UnityEngine;

public class Wumpa : MonoBehaviour, IInteractable
{
    [SerializeField] private float respawnTime = 5f;

    private MeshRenderer _mesh;
    private CapsuleCollider _collider;
    private ParticleSystem _particles;
    private WaitForSeconds _respawnTimer;

    private void Awake()
    {
        _mesh = gameObject.GetComponent<MeshRenderer>();
        _collider = gameObject.GetComponent<CapsuleCollider>();
        _particles = gameObject.GetComponentInChildren<ParticleSystem>();
        _respawnTimer = new WaitForSeconds(respawnTime);
    }

    public void Interact()
    {
        Debug.Log("Interacting");

        Despawn();
    }

    public void OnTriggerEnter()
    {
        Interact();
    }

    /// <summary>
    /// Hides fruit
    /// </summary>
    private void Despawn()
    {
        _collider.enabled = false;
        _mesh.enabled = false;
        _particles.gameObject.SetActive(false);

        StartCoroutine(TimerRespawn());
    }

    /// <summary>
    /// Respawns fruit
    /// </summary>
    private void Respawn()
    {
        _collider.enabled = true;
        _mesh.enabled = true;
        _particles.gameObject.SetActive(true);
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
