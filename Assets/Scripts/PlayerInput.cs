using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Controller2D))]
public class PlayerInput : MonoBehaviour

{
    Player player;
    Controller2D controller;
    public Animator animator;

    float horizontalSpeed = 0f;

    void Start()
    {
        player = GetComponent<Player>();
        controller = GetComponent<Controller2D>();
    }

    void Update()

    {

        Vector3 characterScale = transform.localScale;

        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -1;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1;
        }

        transform.localScale = characterScale;

        horizontalSpeed = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontalSpeed));

        if (controller.collisions.below || controller.collisions.left || controller.collisions.right == true)
        {
            animator.SetBool("isJumping", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("isJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            animator.SetTrigger("Attack");
        }

        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        player.SetDirectionalInput(directionalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.OnJumpInputDown();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            player.OnJumpInputUp();
        }
    }

}