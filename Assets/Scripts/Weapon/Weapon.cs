using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour, IWeapon
{
    bool isReloading = false;

    [SerializeField]GameObject _bullet;
    [SerializeField]float defaultDelay = 3;
    [SerializeField]float bulletSpeed = 1f;
    public void Shoot(float shotDelay, Vector3 targetPos)
    {
        if (isReloading) { return; }
        isReloading = true;
        StartCoroutine(ShootCor(shotDelay, targetPos));
    }
    IEnumerator ShootCor(float shotDelay, Vector3 targetPos)
    {
        Vector3 direction = (targetPos - transform.position).normalized;

        GameObject bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = direction * bulletSpeed;

        float delayTime = defaultDelay - shotDelay;
        yield return new WaitForSeconds(delayTime);
        isReloading = true;
    }
}


