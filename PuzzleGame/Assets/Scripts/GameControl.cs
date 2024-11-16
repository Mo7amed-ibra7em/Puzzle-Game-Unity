using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameControl : MonoBehaviour
{
    public Transform[] PictureItem;
    public GameObject[] Picture;
    public GameObject WinText;
    public GameObject MenuPanel;
    public Button NextButton;
    public static bool Win;
    public AudioSource AudioWin; 
    static int i = 0;
    static int x = 0;
    static int y = 0;
    static int Score = 0;
    bool audioPlay = false;
    void Start()
    {
        WinText.SetActive(false);
        Win = false;
        MenuPanel.SetActive(false);
        SelectPicture();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (isSuccessful())
            {
                WinText.SetActive(true);
                Win = true;
                MenuPanel.SetActive(true);
                if (y == PictureItem.Length - 1)
                {
                    NextButton.interactable = false;
                }
                if (!audioPlay)
                {
                    AudioWin.Play();
                    audioPlay = true;
                }
            }
        }
    }
    bool isSuccessful()
    {
        SelectPicture();
        Score = 0;
        for (; x <= y; x++)
        {
            if (PictureItem[x].rotation.z == 0)
            {
                Score++;
            }
        }
        if (Score == 8)
        {
            return true;
        }
        return false;
    }
    void SelectPicture()
    {
        for (i = 0; i <= Picture.Length; i++)
        {
            if (Picture[i].activeSelf == true)
            {
                x = i * 8;
                y = x + 7;
                break;
            }
        }
    }
    public void Menu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    public void Next()
    {
        WinText.SetActive(false);
        Win = false;
        MenuPanel.SetActive(false);
        Picture[i].SetActive(false);
        Picture[i+1].SetActive(true);
        audioPlay = false;
    }
}
