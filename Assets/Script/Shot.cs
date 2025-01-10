using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float damage = 25f;
    public float fireDistance = 50f;
    public Transform firePosition;
    private LineRenderer lineRenderer;
    private float lastFireTime;
    public float fireRate = 0.12f;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.positionCount = 2;
    }
    public void Fire()
    {
        if (Time.time > lastFireTime + fireRate)
        {
            lastFireTime = Time.time;
            var endpos = Vector3.zero;
            Ray ray = new Ray(firePosition.position, firePosition.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, fireDistance))
            {
                endpos = hit.point;
            }
            else
            {
                endpos = firePosition.position + firePosition.forward * fireDistance;
            }
            StartCoroutine(ShotEffect(endpos));
        }
    }
    private IEnumerator ShotEffect(Vector3 hitpoint)
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, firePosition.position);
        lineRenderer.SetPosition(1, hitpoint);

        yield return new WaitForSeconds(0.03f);
        lineRenderer.enabled = false;
    }
}
