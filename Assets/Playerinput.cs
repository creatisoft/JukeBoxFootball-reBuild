using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Playerinput : MonoBehaviour{

    // Start is called before the first frame update
    public Animator footballAnimator;
    public Animation footballAnimation;

    public Text pointsText;
    int selectRandomPlayerNumber;
    int points = 0;

    public GameObject FootballGameObject;
    private Vector3 footballstartingposition;

    public Button throwButton;
    public Button tryButton;

    //0 missed 1 caught
    public GameObject[] resultsGameobject = new GameObject[2];
        
    private bool enablereset = true;

    void Start(){

        Random.InitState(2342);

        footballstartingposition = FootballGameObject.transform.position;

    }


    public void ResetFootballPosition() {


        FootballGameObject.transform.position = footballstartingposition;
        footballAnimator.SetInteger("footballer", 9);

        resultsGameobject[0].SetActive(false);
        resultsGameobject[1].SetActive(false);


        tryButton.gameObject.SetActive(false);
        throwButton.gameObject.SetActive(true);

    }

    void AddPoint() {

        points = points + 1;
        pointsText.text = "Points: " + points.ToString();
        enablereset = true;
        tryButton.gameObject.SetActive(true);


        resultsGameobject[1].SetActive(true);

        CancelInvoke();

    }

    void ReEnableReset() {

        enablereset = true;
        tryButton.gameObject.SetActive(true);

        resultsGameobject[0].SetActive(true);

        CancelInvoke();

    }

    public void ThrowFootball() {

        //Debug.Log("working");

        selectRandomPlayerNumber = Random.Range(1, 9);
        Debug.Log(selectRandomPlayerNumber);
        footballAnimator.SetInteger("footballer", selectRandomPlayerNumber);

        enablereset = false;
        throwButton.gameObject.SetActive(false);

        if (selectRandomPlayerNumber == 1 || selectRandomPlayerNumber == 2 || selectRandomPlayerNumber == 3 || selectRandomPlayerNumber == 4) {

            //Debug.Log("adding a point");
           
            Invoke("AddPoint", 0.9f);

        } else {

            Invoke("ReEnableReset", 0.9f);

        }

    }

    // Update is called once per frame
    void Update() {

        if (enablereset == true) {

            if (Input.GetKeyDown(KeyCode.R)) {

                ResetFootballPosition();
                enablereset = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) {

            ThrowFootball();
            
        }

    }
}
