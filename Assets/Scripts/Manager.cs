using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    InputAction _clickInput;
    InputAction _positionInput;
    Vector2 _mousePosition;

    void Awake()
    {
        _clickInput = InputSystem.actions["Attack"];
        _positionInput = InputSystem.actions["MousePosition"];

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(_clickInput.WasPressedThisFrame())
        {
            ShootRaycast();
        }
    }

    void ShootRaycast()
    {
        _mousePosition = _positionInput.ReadValue<Vector2>();
        
        Ray ray = Camera.main.ScreenPointToRay(_mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if(hit.collider.name == "Cube1")
            {
                SceneManager.LoadScene("Scene1");
            }
        }
    }
}