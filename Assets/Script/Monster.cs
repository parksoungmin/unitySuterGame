using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public float stopDistance = 3f;
    public float pushForce = 2f;  // �÷��̾ �о��� �� �и��� ���� (���� ����)
    public int hp = 100;
    private int damage = 20;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (player != null)
        {
            // �÷��̾���� �Ÿ� ���
            float distance = Vector3.Distance(transform.position, player.position);

            // �÷��̾ ���� ȸ��
            Vector3 direction = player.position - transform.position;
            direction.y = 0; // y�� ȸ���� ���� (2D�� �����ϱ� ���� y ���� ����)

            // ȸ�� ����
            transform.rotation = Quaternion.LookRotation(direction);

            // �÷��̾�� ���� �Ÿ� �̻��� ��� �̵�
            if (distance > stopDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            // �÷��̾ ���Ϳ� �浹 ���� �� �о��
            Vector3 pushDirection = transform.position - collider.transform.position;
            pushDirection.y = 0; // y�� �о�� �ʵ��� ����

            collider.GetComponent<Rigidbody>().AddForce(pushDirection.normalized * pushForce, ForceMode.Impulse);

            // �÷��̾�� ������ ������
            PlayerMovement player2 = collider.gameObject.GetComponent<PlayerMovement>();
            if (player2 != null)
            {
                player2.TakeDamage(damage);
            }
        }
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
        Destroy(gameObject);
    }
}