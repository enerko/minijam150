using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Ending : MonoBehaviour
{
    public float delay;
    public string text;
    private string currentText;
    public GameObject player;
    public ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowText());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < text.Length; i++)
        {
            currentText = text.Substring(0, i);
            GetComponent<TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
        Vector3 playerpos = player.transform.position;

        
        Destroy(player);
        Instantiate(particles, playerpos, Quaternion.identity);
    }
}
