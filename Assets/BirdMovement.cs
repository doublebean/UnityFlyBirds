using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    Vector3 velocity = Vector3.zero;

    float flapSpeed = 100f;
    float forwardSpeed = 100f;

    bool didFlap = false; 

    public bool dead = false;

    public bool God = false;//测试作弊

    float deathCooldown;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
         animator = transform.GetComponentInChildren<Animator>();

        if(animator == null)
        {
            Debug.LogError("no find animator !!!");
        }
       GetComponent<Rigidbody2D>().AddForce(Vector2.right * forwardSpeed);
    }
    // 
    void FixedUpdate() {

        if (dead)
            return;

        

        if (didFlap)//按下按钮的时候
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * flapSpeed );
            animator.SetTrigger("DoFlap");

            didFlap = false;
        }
        if(GetComponent<Rigidbody2D>().velocity.y > 0)//当Y轴的速度大于0的时候就将鸟扶正
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else//当Y轴的速度小于0的时候鸟的头朝下
        {
            float angle = Mathf.Lerp(0, -90, -GetComponent<Rigidbody2D>().velocity.y / 4f);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        


    }
    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            deathCooldown -= Time.deltaTime;
            if(deathCooldown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                    Application.LoadLevel(Application.loadedLevel);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                didFlap = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (God == false)
            return;
        animator.SetTrigger("Death");
        dead = true;

        deathCooldown = 0.5f;
    }
}
