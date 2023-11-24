using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Mover : MonoBehaviour
{
    public float speed = 10;

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

    public void LookAt(Vector3 target)
    {
        var direction = target - transform.position;
        var rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }
}