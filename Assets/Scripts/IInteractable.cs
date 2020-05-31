using System;
using UnityEngine;

public interface IInteractable
{
    Action OnInteract();
    void Interact();
}
