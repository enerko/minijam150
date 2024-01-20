using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements.Experimental;

public class IntValue : MonoBehaviour
{
    public UnityEvent onChange;
    [SerializeField] private int value;
    
    public int GetValue(int n) {
        return value;
    }

    public void SetValue(int n) {
        value = n;
        onChange.Invoke();
    }
}
