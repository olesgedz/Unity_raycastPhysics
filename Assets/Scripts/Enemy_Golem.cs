using UnityEngine;
using System.Collections;

public class Enemy_Golem : MonoBehaviour
{
    public LayerMask enemyMask;
    public float speed = 5;
    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth, myHeight;

    void Start()
    {
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        SpriteRenderer mySprite = this.GetComponent<SpriteRenderer>();
        myWidth = mySprite.bounds.extents.x;
        myHeight = mySprite.bounds.extents.y;
    }

    void Update()
    {
        Vector2 myVel = myBody.velocity;
        Vector2 lineCastPos = myTrans.position.toVector2() - myTrans.right.toVector2() * myWidth - Vector2.up * myHeight;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);

        Debug.DrawLine(lineCastPos, lineCastPos - myTrans.right.toVector2() * .05f);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - myTrans.right.toVector2() * .05f, enemyMask);

        if (!isGrounded || isBlocked)
        {
           if (myVel.y >= 0.0f)
            {
                Vector3 currRot = myTrans.eulerAngles;
                currRot.y += 180;
                myTrans.eulerAngles = currRot;
           }
        }
       
        myVel.x = -myTrans.right.x * speed;
        myBody.velocity = myVel;
    }
}