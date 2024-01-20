using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AmmoCounter : MonoBehaviour
{
    public IntValue ammoCount;
    public string formatString;
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        ammoCount.onChange.AddListener(UpdateText);
        text = GetComponent<TextMeshProUGUI>();
        UpdateText();  // initialize
    }

    void UpdateText() {
        int count = ammoCount.GetValue();
        text.text = string.Format(formatString, count);
    }
}
