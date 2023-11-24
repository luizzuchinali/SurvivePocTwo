using UnityEngine;

[RequireComponent(typeof(Mover), typeof(Fighter))]
public abstract class Character : MonoBehaviour
{
    public Mover Mover { get; private set; }
    public Fighter Fighter { get; private set; }

    protected virtual void Awake()
    {
        Mover = GetComponent<Mover>();
        Fighter = GetComponent<Fighter>();
    }
}