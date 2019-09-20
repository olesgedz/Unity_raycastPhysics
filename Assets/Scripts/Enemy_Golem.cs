using UnityEngine;
using System.Collections;

public class Enemy_Golem : MonoBehaviour
{
    public float golemHealth = 10;
    public float golemHit = 2;
    public LayerMask LayerMask;
    public float golemSpeed = 5;
    Rigidbody2D golemBody;
    Transform golemTrans;
    float golemWidth, golemHeight;

    void Start()
    {
        golemTrans = this.transform;
        golemBody = this.GetComponent<Rigidbody2D>();
        SpriteRenderer mySprite = this.GetComponent<SpriteRenderer>();
        golemWidth = mySprite.bounds.extents.x;
        golemHeight = mySprite.bounds.extents.y;
    }

    void Update()
    {
        Vector2 myVel = golemBody.velocity;
        Vector2 lineCastPos = golemTrans.position.toVector2() - golemTrans.right.toVector2() * golemWidth - Vector2.up * golemHeight;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, LayerMask);

        Debug.DrawLine(lineCastPos, lineCastPos - golemTrans.right.toVector2() * .05f);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - golemTrans.right.toVector2() * .05f, LayerMask);

        if (!isGrounded || isBlocked)
        {
           if (myVel.y >= .0f)
            {
                Vector3 currRot = golemTrans.eulerAngles;
                currRot.y += 180;
                golemTrans.eulerAngles = currRot;
           }
        }
       
        myVel.x = -golemTrans.right.x * golemSpeed;
        golemBody.velocity = myVel;
    }
}