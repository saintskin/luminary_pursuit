using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
     public ObjectPoolingB objectPoolManager;
    public Transform firePoint;
    public float bulletForce = 10f;
    public int damage = 1;

    private InputAction fireAction; // Reference to the Fire action from the Input System.

    private void Awake()
    {
        // Get a reference to the Fire action.
        fireAction = new InputAction("Fire", binding: "<Mouse>/leftButton");
    }

    private void OnEnable()
    {
        // Enable the Fire action when the script is enabled.
        fireAction.Enable();
    }

    private void OnDisable()
    {
        // Disable the Fire action when the script is disabled.
        fireAction.Disable();
    }

    private void Update()
    {
        // Check if the Fire action is triggered.
        if (fireAction.triggered)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = objectPoolManager.GetBullet();

        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.SetActive(true);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);

            BulletBehaviour bulletBehavior = bullet.GetComponent<BulletBehaviour>();
            bulletBehavior.SetDamage(damage);
        }
    }
}
