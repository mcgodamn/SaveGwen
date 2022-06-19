using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public Image img;

    public Sprite good, end;
    public Button replay, exit;

    void Awake()
    {
        if (GameManager.instance.GoodEnd)
        {
            img.sprite = good;
        }
        else
        {
            img.sprite = end;
        }

        replay.onClick.AddListener(()=> GameManager.instance.StartGame());
        exit.onClick.AddListener(()=>Application.Quit());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
