using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Setting
{
    public float webSpeed;
    public float webDistance;
    public float webJointFreq;
    public float webJointDump;
    public float spawnTime;
    public float winTime;
    public float loseCountDown;
    public float breakAngle;
    public float breakDis;
    public float gwenJointFreq;
    public float gwenJointDump;
    public float gwenMass;
    public float gwenLinearDrag;
    public float gwenAngularDrag;
}

public class GameManager : MonoBehaviour
{
    string settingJson = "{\"webSpeed\":100000,\"webDistance\":0.5,\"webJointFreq\": 100000,\"webJointDump\": 0,\"spawnTime\": 0.03,\"winTime\": 10,\"loseCountDown\":2,\"breakAngle\": 90,\"breakDis\":3,\"gwenJointFreq\": 1,\"gwenJointDump\": 1,\"gwenMass\": 5,\"gwenLinearDrag\":1,\"gwenAngularDrag\":2}";

    public Setting setting;
    public static GameManager instance;

    public bool GoodEnd = false;

    void Awake()
    {
        instance = this;
        ReadSetting();
        DontDestroyOnLoad(this);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
    
    public void EndGame(bool isGoodEnd)
    {
        GoodEnd = isGoodEnd;
        SceneManager.LoadScene("End", LoadSceneMode.Single);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void ReadSetting()
    {
#if UNITY_WEBGL
        setting = JsonUtility.FromJson<Setting>(settingJson);
#else
        using(StreamReader file = new StreamReader(Path.Combine(Application.streamingAssetsPath, "setting.json")))
        {  
            setting = JsonUtility.FromJson<Setting>(file.ReadToEnd());
        }
#endif  
    }
}
