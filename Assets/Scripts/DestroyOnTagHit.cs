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
            Globals.CheckState(tag);
            Animator animator = GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("IsDead", true);
            }
        }
    }
}
