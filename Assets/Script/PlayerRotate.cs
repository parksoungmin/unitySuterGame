using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField]
    private bool isLookAt = true;

    private void Update()
    {
        if (isLookAt == false) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.up);


        // Ray를 시각적으로 표시
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);

        if (plane.Raycast(ray, out float distance))
        {
            Vector3 direction = ray.GetPoint(distance) - transform.position;
            transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        }
    }

    private void OnDrawGizmos()
    {
        if (Camera.main == null) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.up);

        if (plane.Raycast(ray, out float distance))
        {
            Vector3 hitPoint = ray.GetPoint(distance);

            // Plane을 사각형으로 표시
            Vector3 center = new Vector3(hitPoint.x, 0, hitPoint.z);
            float size = 10f; // Plane의 크기 설정

            Vector3[] corners = new Vector3[4];
            corners[0] = center + new Vector3(-size, 0, -size);
            corners[1] = center + new Vector3(size, 0, -size);
            corners[2] = center + new Vector3(size, 0, size);
            corners[3] = center + new Vector3(-size, 0, size);

            Gizmos.color = Color.green;
            Gizmos.DrawLine(corners[0], corners[1]);
            Gizmos.DrawLine(corners[1], corners[2]);
            Gizmos.DrawLine(corners[2], corners[3]);
            Gizmos.DrawLine(corners[3], corners[0]);
        }
    }
}
