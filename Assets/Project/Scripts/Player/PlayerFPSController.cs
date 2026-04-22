using UnityEngine;

public class PlayerFPSController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform cameraPivot;
    [SerializeField] private GameSettings _settings;
    [SerializeField] private float minPitch = -60f;
    [SerializeField] private float maxPitch = 60f;
    private float yaw, pitch;   //yaw orizzontale, pitch verticale

    private void Awake()
    {
        if (_player == null)
            _player = transform.parent;

        if (_settings == null)
            Debug.LogWarning($"GameSettings mancanti su {gameObject.name}");
    }

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        MouseLook();
    }

    private void MouseLook()
    {
        if (_player == null || cameraPivot == null || _settings == null)
            return;

        float mouseX = Input.GetAxis("Mouse X") * _settings._mouseSens;
        float mouseY = Input.GetAxis("Mouse Y") * _settings._mouseSens;

        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        _player.rotation = Quaternion.Euler(0f, yaw, 0f);   //ruota il player su Y
        cameraPivot.localRotation = Quaternion.Euler(pitch, 0f, 0f);    //ruota la camera su X
    }
}