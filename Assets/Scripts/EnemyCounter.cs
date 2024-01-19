using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contribute to Global enemy counter
public class EnemyCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Globals.currentEnemies++;   
    }
}
