using UnityEngine;
using System.Collections;


public class GhostFollow : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float stoppingDistance;
    Vector2 defaultPosition;
    public float defaultX = 1f;
    public float defaultY = 3.2f;
    bool isRight = true;

    public Transform target;

    void Update() {


        Vector2 characterScale = transform.localScale;
        Vector2 characterPosition = transform.position;

        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -1;
            isRight = false;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1;
            isRight = true;
        }
        transform.localScale = characterScale;

        if (isRight == true)
        {
            defaultPosition = new Vector2(target.position.x - defaultX, target.position.y + defaultY);
            defaultPosition = Vector2.Lerp(transform.position, defaultPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            defaultPosition = new Vector2(target.position.x + defaultX, target.position.y + defaultY);
            defaultPosition = Vector2.Lerp(transform.position, defaultPosition, moveSpeed * Time.deltaTime);
        }
        
            if (Vector2.Distance(transform.position, defaultPosition) > stoppingDistance)
            {
                transform.position = Vector2.Lerp(transform.position, defaultPosition, (moveSpeed * Time.deltaTime) * 10);
            }
    }
}