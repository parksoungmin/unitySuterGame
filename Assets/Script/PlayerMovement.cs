using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    public readonly int hashMove = Animator.StringToHash("Move");
    public float hp = 300;
    public float speed = 5f;
    public float rotateSpeed = 100f;

    private Animator animator;
    private PlayerInput input;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Die();
        }

    }
    public void Die()
    {

    }
    private void FixedUpdate()
    {
        var pos = transform.position;
        Vector2 moveInput = new Vector2(input.MoveX, input.MoveZ);
        pos += input.MoveX * Vector3.forward * speed * Time.deltaTime;
        pos += input.MoveZ * Vector3.right * speed * Time.deltaTime;
        transform.position = pos;

        animator.SetFloat(hashMove, moveInput.magnitude);
    }
}
