using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    [SerializeField] private Vector3 playerDirection;
    [SerializeField] private float timeToMove = 0.2f;
    private bool isMoving;
    private Vector3 origPos, targetPos;

    private Dictionary<KeyCode, Vector3> directionMapping = new Dictionary<KeyCode, Vector3>
    {
        { KeyCode.W, Vector3.up },
        { KeyCode.A, Vector3.left },
        { KeyCode.S, Vector3.down },
        { KeyCode.D, Vector3.right }
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            return;
        }

        foreach (var kvp in directionMapping)
        {
            if (Input.GetKey(kvp.Key))
            {
                playerDirection = kvp.Value;
                StartCoroutine(MovePlayer(playerDirection));
                break;
            }
        }
    }

    public IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;
        float elapsedTime = 0;

        origPos = transform.position;
        targetPos = origPos + direction;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;

    }
}
