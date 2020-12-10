using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float speed;
    public Sprite[] dibujos;
    public SpriteRenderer dibujo;
    public GameObject button;
    public GameObject button2;

    void Start() 
    {

        StartCoroutine(Type());

    }

    IEnumerator Type()
    {

        yield return new WaitForSeconds(0.3f);

        //Convert the text to separate letters and show it slowly
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(speed);
        }

    } 

    public void Next()
    {

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            dibujo.sprite = dibujos[index];
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = " ";
            Destroy(button);
            button2.SetActive(true);
        }

    } 
    
}
