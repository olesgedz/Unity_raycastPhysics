using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueZone : MonoBehaviour
{

    void Start()
    {
        button.gameObject.SetActive(false);
    }

    public Button button;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            button.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            button.gameObject.SetActive(false);
        }
    }
}
