using UnityEngine;
using MiseEnPlace.Data;
using System;

public class Employee : MonoBehaviour
{
    private EmployeeData _employeeData;
    private CharacterController _characterController;
    private Animator _animator;
    private bool _isMoving = false;
    private Vector3 _targetPosition;
    private float _moveSpeed = 2f; // Velocidad de movimiento del empleado
    private float _rotationSpeed = 5f; // Velocidad de rotación del empleado

    // Cache hash values
    private static readonly int IdleState = Animator.StringToHash("Base Layer.idle");
    private static readonly int MoveState = Animator.StringToHash("Base Layer.move");
    private static readonly int SurprisedState = Animator.StringToHash("Base Layer.surprised");
    private static readonly int AttackTag = Animator.StringToHash("Attack");

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _employeeData.position = new SerializableVector3(transform.position);
    }


    public void SetEmployeeData(EmployeeData employeeData)
    {
        _employeeData = employeeData;
    }
}
