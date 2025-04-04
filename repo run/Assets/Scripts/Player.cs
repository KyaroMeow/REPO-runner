using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private CharacterController _characterController;

    private Vector2 _mouseStartPosition;
    private Vector2 _mouseCurrentPosition;
    private bool _isMouseDown = false;

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        // ��������� ����� � ���������� (���� �����)
        float keyboardInput = Input.GetAxis("Horizontal");
        if (keyboardInput != 0f)
        {
            Vector3 move = Vector3.right * _speed * keyboardInput * Time.deltaTime;
            _characterController.Move(move);
        }

        // ��������� ����� � ����
        if (Input.GetMouseButtonDown(0)) // ����� ���� ����
        {
            _isMouseDown = true;
            _mouseStartPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _isMouseDown = false;
        }

        if (_isMouseDown)
        {
            _mouseCurrentPosition = Input.mousePosition;
            Vector2 delta = _mouseCurrentPosition - _mouseStartPosition;
            float moveDirection = delta.x / Screen.width; // ����������� �������� �� ��� X

            // ������������ �������� � �������� [-1, 1]
            moveDirection = Mathf.Clamp(moveDirection, -1f, 1f);

            Vector3 move = Vector3.right * _speed * moveDirection * Time.deltaTime;
            _characterController.Move(move);
        }
    }
}
