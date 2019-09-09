using UnityEngine;
using System.Collections;

public class Enemy_Golem : MonoBehaviour
{
    public int golemHealth = 72;
    public int golemHit = 36;
    public LayerMask LayerMask;
    public float golemSpeed = 5f;
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
        Vector2 golemVel = golemBody.velocity;
        Vector2 lineCastPos = golemTrans.position.toVector2() - golemTrans.right.toVector2() * golemWidth - Vector2.up * golemHeight;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, LayerMask);

        Debug.DrawLine(lineCastPos, lineCastPos - golemTrans.right.toVector2() * .05f);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - golemTrans.right.toVector2() * .05f, LayerMask);

        if (!isGrounded || isBlocked)
        {
           if (golemVel.y >= .0f)
            {
                Vector3 currRot = golemTrans.eulerAngles;
                currRot.y += 180;
                golemTrans.eulerAngles = currRot;
           }
        }
       
        golemVel.x = -golemTrans.right.x * golemSpeed;
        golemBody.velocity = golemVel;
    }
}