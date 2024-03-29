using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    [SerializeField] private Transform armPivot;
    // Gun Variabels 
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    // [Range(0.1f, 1f)] 
    //   [SerializeField] private float fireRate = 0.5f; 

    private Rigidbody2D rb;
    private float mx;
    private float my;

    private Vector2 mousePos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");
        my = Input.GetAxisRaw("Vertical");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        armPivot.localRotation = Quaternion.Euler(0, 0, angle);

        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(mx, my).normalized * speed;
    }
    private void Shoot()
    {
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
    }
}


