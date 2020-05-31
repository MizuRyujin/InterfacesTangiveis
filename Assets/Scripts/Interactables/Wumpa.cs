using System;
using System.Collections;
using UnityEngine;

public class Wumpa : MonoBehaviour, IInteractable
{
    [SerializeField] private float respawnTime = 5f;
    [SerializeField] private ParticleSystem _particlesIdle;
    [SerializeField] private ParticleSystem _particleInteract;

    private MeshRenderer _mesh;
    private CapsuleCollider _collider;
    private WaitForSeconds _respawnTimer;

    private void Awake()
    {
        _mesh = gameObject.GetComponent<MeshRenderer>();
        _collider = gameObject.GetComponent<CapsuleCollider>();
        _respawnTimer = new WaitForSeconds(respawnTime);
    }

    public void Interact()
    {
        Debug.Log("Interacting");

        _particleInteract.Play();

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
        _particlesIdle.gameObject.SetActive(false);

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
