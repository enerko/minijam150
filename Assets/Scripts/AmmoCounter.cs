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
    private TextMeshProUGUI hint;

    // Start is called before the first frame update
    void Start()
    {
        ammoCount.onChange.AddListener(UpdateText);
        text = GetComponent<TextMeshProUGUI>();
        hint = GameObject.Find("Hint").GetComponentInChildren<TextMeshProUGUI>();
        UpdateText();  // initialize
    }

    void UpdateText()
    {
        int count = ammoCount.GetValue();
        text.text = string.Format(formatString, count);
        StartCoroutine(CheckAmmoCount());
    }

    private IEnumerator CheckAmmoCount()
    {
        if (ammoCount.GetValue() == 0)
        {
            yield return new WaitForSeconds(1);
            if (Globals.currentEnemies != 0)
            {
                ChangeDisplay();
            }

        }
        yield return null;

    }

    private void ChangeDisplay()
    {
        hint.text = "Press R to restart level";
    }
}
