using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Character : MonoBehaviour
{
    public Mover Mover { get; private set; }

    private void Awake()
    {
        Mover = GetComponent<Mover>();
    }
}