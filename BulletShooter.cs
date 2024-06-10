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
            Vector3 _vector3direction = (_target.position - transform.position).normalized;
            Bullet NewBullet = Instantiate(_bulletPrefab, transform.position + _vector3direction, Quaternion.identity);

            NewBullet.GetComponent<Rigidbody>().transform.up = _vector3direction;

            yield return _waitForSeconds;
        }
    }
}