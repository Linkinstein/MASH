using System;
using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Bullet bulletPrefab;

    [SerializeField] public Boolean playing = true;


    private void Start()
    {
        StartCoroutine(FireRoutine());
    }

    IEnumerator FireRoutine()
    {
        while (playing)
        {
            yield return new WaitForSeconds(5f);
            FireBullet();
        }
    }

    private void FireBullet()
    {
        if (target != null && bulletPrefab != null)
        {
            Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.ShootAt(target);
        }
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            direction.z = 0f;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 180f;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
