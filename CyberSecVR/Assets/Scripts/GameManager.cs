using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    int score = 0;
    [SerializeField]
    Text scoreDisplay;

    [SerializeField]
    GameObject objectiveTab;

    [SerializeField]
    GameObject spawningWaypoint;

    [SerializeField]
    float timeBetweenSpawns = 60;
    float timer;

    float hintPercentage = 0.5f;

    Dictionary<GameObject, UsbProgram.Program> objectivesList;

    public static GameManager instance = null; //Static instance of GameManager which allows it to be accessed by any other script.
 
    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        //DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        timer = timeBetweenSpawns;
        objectivesList = new Dictionary<GameObject, UsbProgram.Program>();
    }
	
	// Update is called once per frame
	void Update () {
        scoreDisplay.text = "Score: " + score;

        timer += Time.deltaTime;

        if (timer >= timeBetweenSpawns)
        {
            createNewObjective();
            timer = 0;
        }

	}

    void createNewObjective()
    {
        GameObject obj = Instantiate(objectiveTab);
        obj.transform.position = spawningWaypoint.transform.position;
        UsbProgram.Program prog = (UsbProgram.Program)((int)(Random.value * ((int)(UsbProgram.Program.LAST) -1)));
        if (prog == UsbProgram.Program.NONE)
        {
            prog = UsbProgram.Program.RansomVirus;
        }

        objectivesList.Add(obj, prog);

        obj.GetComponent<ObjectiveTablet>().setProgram(prog, Random.value > hintPercentage);

    }

    public void checkProgram(UsbProgram.Program _prog)
    {
        foreach (var objective in objectivesList)
        {
            if (objective.Value == _prog)
            {
                score++;
                Destroy(objective.Key.gameObject);
                return;
            }
        }
        score--;
        return;
    }
}
