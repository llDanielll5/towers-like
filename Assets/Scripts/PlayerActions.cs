using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private float bulletSpeed = 20f;

    public float BulletSpeed
    {
        get => bulletSpeed;
        set => bulletSpeed = value;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Obtém o componente Rigidbody2D da bala instanciada
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Aplica força à bala na direção do ponto para frente do firePoint
        rb.AddForce(firePoint.right * bulletSpeed, ForceMode2D.Impulse);
    }
}
