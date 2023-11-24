using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Mover : MonoBehaviour
{
    public float speed = 3.0f;

    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void Move(float horizontal, float vertical)
    {
        var direction = new Vector3(horizontal, 0, vertical);
        var movement = direction.normalized * speed;
        _characterController.SimpleMove(movement);
    }
}