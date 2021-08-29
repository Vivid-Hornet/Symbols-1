using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EtcherScript : MonoBehaviour
{

    public GameObject linePrefab;
    public GameObject currentLine;
    public GameObject clearButton;
    public GameObject percentageDisplay;
    public LineRenderer drawnLine;
    public List<Vector2> mousePosistions;

    decimal correctCounter = 0;
    public string displayPercentage = "00.00%"; 
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
            //moves the GameObject "Etcher" to follow the mouse
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //assigns the mouse's position to the Vector2 value "mousePos"
            transform.position = new Vector2(mousePos.x, mousePos.y); //makes the position of the object to equal "mousePos"

            if (Input.GetMouseButtonDown(0)) {
                //calls upon the "CreateLine();" functions only once when primary mouse button is pressed down
                CreateLine();
            }

            if (Input.GetMouseButton(0)) {
                //while the primary mouse button is pressed down, more vertices are assigned to "drawLine" equal to the mouse's position
                if (Vector2.Distance(mousePos, mousePosistions[mousePosistions.Count - 1]) > 1f) {
                    //as long as mouse is far enough away from the last point created, then the "UpdateLine();" method is called and "mousePos" replaces "movingMousePos"
                    UpdateLine(mousePos);
                }
            }

            if (Input.GetMouseButtonUp(0)) {
                //compares the player's drawn line to the template saved in the game's data
                foreach (var valueA in mousePosistions) { //cycles through the values in "mousePositions" array
                    foreach (var valueB in transform.parent.Find("Template to Copy(Clone)").GetComponent<TestSymbolScript>().templatePositions) { //cycles through the values in "templatePositions" array until a match is made
                        float distance = Vector2.Distance(valueA, valueB); //determines the distance the two values until a match is made
                        if (distance < 4) { //a match is made when that are a certain distance together
                            correctCounter++; //counts the amount of matches
                            break; //skips over the rest of "templatePositions" so that invalid matches aren't made
                        }
                    }
                }
            decimal resultPercentage = correctCounter / mousePosistions.Count * 100; //divides the amount of matches by the number of points in the player's drawn line and stores it in percentage form
            displayPercentage = string.Format("{0:00.00}", resultPercentage).ToString() + "%"; //displays the percentage
            transform.parent.parent.Find("PercentageDisplay").GetComponent<Text>().text = displayPercentage;
            Debug.Log(displayPercentage);
            Destroy(gameObject);
            GameObject ClearButton = Instantiate(clearButton, new Vector2(transform.parent.parent.Find("DealButton").transform.position.x - 660, transform.parent.parent.Find("DealButton").transform.position.y), Quaternion.identity);
            ClearButton.transform.SetParent(transform.parent.parent.transform);
            correctCounter = 0; //resets the counter
            }
        }

        void CreateLine() {
            //instantiates a new line render, rewrites the values of the "mousePositions" array, and creates the first two points of the array/line render
            currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity); //assigns the properties of "linePrefab" to "currentLine"
            currentLine.transform.SetParent(transform.parent.transform);
            drawnLine = currentLine.GetComponent<LineRenderer>(); //converts the newly assigned properties of "currentLine" into a LineRender and assigns the values to "drawLine"
            mousePosistions.Clear(); //resets the "mousePositions" array
            mousePosistions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition)); //gets the position of the mouse and adds it to "mousePositions" as a Vector2 value
            drawnLine.SetPosition(0, mousePosistions[0]); //adds the Vector2 value to "drawLine" so that the beginning of the line can be defined
            drawnLine.SetPosition(1, mousePosistions[0]); //defines a second point so that "drawLine" can be created
        }

        void UpdateLine(Vector2 movingMousePos) {
            //adds a new value and position to "mousePositions" and "drawLine" respectively
            mousePosistions.Add(movingMousePos); //adds the new Vector2 value "movingMousePos" to the array "mouse Positions"
            drawnLine.positionCount++; //increases how many vertices "drawLine" can hold
            drawnLine.SetPosition(drawnLine.positionCount - 1, movingMousePos); //assings the values of "movingMousePos" to the most recent drawLine vertice
        }

    }


