using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GwenManager : MonoBehaviour
{
    public ParticleSystem mparticleSystem;

    public List<Rigidbody2D> gwenPart;

    public static GwenManager instance;

    float countdown;

    public bool GwenIsFuckingDead = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        countdown = GameManager.instance.setting.loseCountDown;
    }

    public void GwenFuckingDead()
    {
        if (GwenIsFuckingDead) return;

        mparticleSystem.Play();

        foreach(var part in gwenPart)
        {
            part.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        GwenIsFuckingDead = true;

    }

    void Update()
    {
        if (GwenIsFuckingDead)
        {
            countdown -= Time.deltaTime;
        }

        if (countdown < 0)
        {
            GameManager.instance.EndGame(false);
        }
    }


}
