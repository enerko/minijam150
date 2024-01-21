using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTagHit : MonoBehaviour
{
    public string target;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == target)
        {
            // Disable the collider
            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            collider.enabled = false;

            Globals.CheckState(tag);
            Animator animator = GetComponent<Animator>();
            if (animator)
            {
                animator.SetBool("IsDead", true);

                // Freeze rigidbody
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.isKinematic = true;
            } else {
                Destroy(gameObject);
            }
        }
    }
}
