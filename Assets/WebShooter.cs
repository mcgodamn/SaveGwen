using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebShooter : MonoBehaviour
{
    public GameObject webPrefab;

    public GameObject peter;

    public bool isShooting = false;

    GameObject nowWeb;
    GameObject lastWeb;

    float lastSpawnTime;

    float winTime;

    Vector3 mousePos, lastMousePos;

    public static WebShooter instance;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        winTime = GameManager.instance.setting.winTime;
    }

    void FixedUpdate()
    {
        if (isShooting)
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (nowWeb) nowWeb.GetComponent<Rigidbody2D>().AddForce((worldPosition - nowWeb.transform.position).normalized * GameManager.instance.setting.webSpeed * Time.fixedDeltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        winTime -= Time.deltaTime;
        if (winTime < 0 && !GwenManager.instance.GwenIsFuckingDead)
        {
            GameManager.instance.EndGame(true);
        }

        if (Input.GetMouseButtonDown(0) && !isShooting)
        {
            isShooting = true;
            lastWeb = nowWeb = Instantiate(webPrefab, peter.transform.position, Quaternion.identity);
            nowWeb.GetComponent<Stick>().isStick = true;
        }

        if (isShooting && Time.time > lastSpawnTime + GameManager.instance.setting.spawnTime)
        {
            lastSpawnTime = Time.time;
            var web = Instantiate(webPrefab, (Vector2)peter.transform.position - Vector2.up, Quaternion.identity, this.transform);
            web.GetComponent<SpringJoint2D>().connectedBody = peter.GetComponent<Rigidbody2D>();
            lastWeb.GetComponent<SpringJoint2D>().connectedBody = web.GetComponent<Rigidbody2D>();
            lastWeb = web;
        }
    }
}
