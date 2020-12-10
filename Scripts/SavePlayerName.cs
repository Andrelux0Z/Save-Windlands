using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SavePlayerName : MonoBehaviour
{

    public TMP_InputField textBox;

    public void SaveButton()
    {

        PlayerPrefs.SetString("name", textBox.text);
        SceneManager.LoadScene("SayName");

    }

    public void DeleteName()
    {

        PlayerPrefs.DeleteKey("name");
        SceneManager.LoadScene("NameScene");

    }

    public void NextScene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}
