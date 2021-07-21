using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diggable : MonoBehaviour
{
    float timer;
    float holdDur = 3f;
    bool diggingAllowed = false;

    void Update()
    {
        Debug.Log(timer);

        if (Input.GetKeyDown("e") && diggingAllowed == true)
            {
                timer = Time.time;
            }
        else if (Input.GetKey("e") && diggingAllowed == true)
        {
            if (Time.time - timer > holdDur)
            {
                    //by making it positive inf, we won't subsequently run this code by accident,
                    //since X - +inf = -inf, which is always less than holdDur
                    timer = float.PositiveInfinity;

                    //perform your action
                    DestroyBlock();
                Debug.Log("destroyed");

            }
        }
        else
        {
            timer = float.PositiveInfinity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            diggingAllowed = true;
            Debug.Log("Contact");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            diggingAllowed = false;
            Debug.Log("Exit");
        }
    }

    void DestroyBlock()
        {
            Destroy(gameObject);
        }
}
