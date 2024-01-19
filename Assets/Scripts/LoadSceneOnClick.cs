using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Should be used on buttons to load a scene on click
public class LoadSceneOnClick : MonoBehaviour
{
    public string levelName;
    private Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    void OnClick() {
        Globals.LoadScene(levelName);
    }
}
