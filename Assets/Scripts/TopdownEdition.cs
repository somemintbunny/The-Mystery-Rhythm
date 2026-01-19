using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TopDownEdition : MonoBehaviour
{
    public static TopDownEdition instance;
    public float speed = 10f;
    private Rigidbody2D rb;
    public float xPos;
    public float yPos;
    private Animator animator;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        xPos = BackHome.instance.playerXPos;
        yPos = BackHome.instance.playerYPos;
        instance = this;
        if (xPos != 0 && yPos != 0)
        {
            transform.Translate(xPos, yPos, 0, Space.World);
        }
        else
        {
            transform.Translate(-1.96f, 41.86f, 0, Space.World);
        }
        // sus, sus, among us
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        xPos = transform.position.x;
        yPos = transform.position.y;
        // movement thingos :3
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveX, moveY);
        rb.velocity = movement * speed;



        if (rb.velocity == Vector2.zero)
        {
            animator.SetBool("isRunning", false);

        }
        else
        {

            if (moveX < -0.5)
            {
                animator.SetBool("isRunning", true);
                animator.SetBool("runUp", false);
                animator.SetBool("runDown", false);
                sprite.flipX = true;
            }
            if (moveX > 0.5)
            {
                animator.SetBool("isRunning", true);
                sprite.flipX = false;
                animator.SetBool("runDown", false);
                animator.SetBool("runUp", false);
            }
            else if (moveY < -0.5)
            {
                animator.SetBool("runUp", false);
                animator.SetBool("runDown", true);
                animator.SetBool("isRunning", false);
                sprite.flipX = false;
            }
            if (moveY > 0.5)
            {
                animator.SetBool("runDown", false);
                animator.SetBool("runUp", true);
                animator.SetBool("isRunning", false);
                sprite.flipX = false;
            }
            if (moveY > -0.5 && moveY < 0.5 && moveX > -0.5 && moveX < 0.5)
            {
                animator.SetBool("runDown", false);
                animator.SetBool("runUp", false);
                animator.SetBool("isRunning", false);
                sprite.flipX = false;
            }
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
            {
                sprite.flipY = true;
            }
            else
            {
                sprite.flipY = false;
            }
        }

    }
}
