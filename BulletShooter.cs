using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] private float _timeBetweenShots;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _target;

    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isWork = enabled;
        _waitForSeconds = new WaitForSeconds(_timeBetweenShots);

        while (isWork)
        {
            Vector3 directionToTarget = (_target.position - transform.position).normalized;
            Bullet newBullet = Instantiate(_bulletPrefab, transform.position + directionToTarget, Quaternion.identity);

            newBullet.transform.up = directionToTarget;

            yield return _waitForSeconds;
        }
    }
}