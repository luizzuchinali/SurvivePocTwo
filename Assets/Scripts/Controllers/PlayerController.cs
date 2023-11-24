using Cinemachine;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject characterGameObject;
    public CinemachineVirtualCamera virtualCamera;

    private PlayerCharacter _character;
    private Transform _characterTransform;

    private void Awake()
    {
        var localTransform = transform;
        var instance = Instantiate(
            characterGameObject,
            localTransform.position,
            Quaternion.identity,
            localTransform
        );

        _character = instance.GetComponent<PlayerCharacter>();
        _characterTransform = _character.transform;
    }

    private void Start()
    {
        virtualCamera.Follow = _characterTransform;
        virtualCamera.LookAt = _characterTransform;
    }

    private void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        _character.Mover.Move(horizontal, vertical);
    }

    public Vector3 GetCharacterPosition() => _characterTransform.position;
}