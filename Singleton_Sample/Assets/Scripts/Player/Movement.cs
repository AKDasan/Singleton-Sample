using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;

    public float walk_Speed;
    public float run_Speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StaminaBoost();
        }
    }

    public void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, z).normalized;

        if (Input.GetKey(KeyCode.LeftShift) && Stamina.Instance.player_Stamina > 0)
        {
            rb.MovePosition(transform.position + movement * run_Speed * Time.fixedDeltaTime);
            Stamina.Instance.DecreaseStamina(1f);  
            // Singleton kullanýmý
            // istenilirse direkt deðer girmek yerine bir deðiþkene atanabilir.
        }
        else
        {
            rb.MovePosition(transform.position + movement * walk_Speed * Time.fixedDeltaTime);
        }
    }

    public void StaminaBoost()
    {
        Stamina.Instance.IncreaseStamina(20f);
    }
}
