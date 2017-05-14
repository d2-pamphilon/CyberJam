using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    int score = 0;
    [SerializeField]
    Text scoreDisplay;

    [SerializeField]
    GameObject objectiveBoard;

    [SerializeField]
    GameObject player;

    public static GameManager instance = null; //Static instance of GameManager which allows it to be accessed by any other script.

    [SerializeField]
    public Dictionary<GameObject, UsbProgram.Program> UsbObjectivesList;

    
    [SerializeField]
    float timeBetweenSpawns = 60.0f;
    float timer;

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
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        UsbObjectivesList = new Dictionary<GameObject, UsbProgram.Program>();
        timer = timeBetweenSpawns;
	}
	
	// Update is called once per frame
	void Update () {
        scoreDisplay.text = "Score: " + score;
        timer += Time.deltaTime;
        if (timer >= timeBetweenSpawns)
        {
            CreateNewObjective();
            timer = 0.0f;
        }
        
	}

    void CreateNewObjective()
    {
        UsbProgram.Program prog = (UsbProgram.Program)((int)(Random.value*((int)UsbProgram.Program.LAST)-1));
        if (prog == UsbProgram.Program.NONE)
        {
            prog = UsbProgram.Program.RansomVirus;
        }
        GameObject board = Instantiate(objectiveBoard);
        board.GetComponent<ObjectiveTablet>().setProgram(prog, true);

        board.transform.position = player.transform.position;

        UsbObjectivesList.Add(board, prog);
    }

    public void CheckUsb(UsbProgram.Program _program)
    {
        if (UsbObjectivesList.ContainsValue(_program))
        {
            score++;
            foreach (var obj in UsbObjectivesList)
            {
                if (obj.Value == _program)
                {
                    Destroy(obj.Key);
                    UsbObjectivesList.Remove(obj.Key);
                    break;
                }
            }
        }
        else
        {
            score--;
        }
    }
}
