using UnityEngine;

[RequireComponent(typeof(Mover))]
public abstract class Character : MonoBehaviour
{
    public Mover Mover { get; private set; }

    protected virtual void Awake()
    {
        Mover = GetComponent<Mover>();
    }
}