using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public float stopDistance = 3f;
    public float pushForce = 2f;  // 플레이어가 밀었을 때 밀리는 정도 (조정 가능)
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
            // 플레이어와의 거리 계산
            float distance = Vector3.Distance(transform.position, player.position);

            // 플레이어를 향해 회전
            Vector3 direction = player.position - transform.position;
            direction.y = 0; // y축 회전을 방지 (2D로 유지하기 위해 y 값만 제외)

            // 회전 적용
            transform.rotation = Quaternion.LookRotation(direction);

            // 플레이어와 일정 거리 이상일 경우 이동
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
            // 플레이어가 몬스터와 충돌 중일 때 밀어내기
            Vector3 pushDirection = transform.position - collider.transform.position;
            pushDirection.y = 0; // y축 밀어내지 않도록 조정

            collider.GetComponent<Rigidbody>().AddForce(pushDirection.normalized * pushForce, ForceMode.Impulse);

            // 플레이어에게 데미지 입히기
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