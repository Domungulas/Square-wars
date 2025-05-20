using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonToPlay : MonoBehaviour
{
    // Start is called before the first frame update
    public Button MyButton;
    void Start()
    {
        MyButton.onClick.AddListener(ButtonHit);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ButtonHit() 
    {
        SceneManager.LoadScene("TheWorld");
    }
}
