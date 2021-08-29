using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestSymbolScript : MonoBehaviour
{
    public GameObject testPrefab;
    public GameObject templateCurrentLine;
    public GameObject templatePrefab;
    public GameObject playArea;
    public LineRenderer templateLine;
    public List<Vector3> templatePositions;
    public int polyPoints;
    

    Vector3 vertexCreator;
    int pointCounter = 1;
    
    int arrayCounter = 0;
    Vector3 centerPos;
    // Start is called before the first frame update
    void Start() {
        centerPos.Set(537, 350, -10);
        DrawPolygon(polyPoints, 50, centerPos, 1);
        while (arrayCounter < templateLine.positionCount) {
            templatePositions.Add(templateLine.GetPosition(arrayCounter)); //adds the vertices of "templateLine" to "templatePositions"
            arrayCounter++;
        }

        vertexCreator = templateLine.GetPosition(0);
        //templatePositions.Add(Vector2.MoveTowards(vertexCreator, templateLine.GetPosition(pointCounter), 0.1f));
        while (pointCounter < templateLine.positionCount) {
            vertexCreator = Vector2.MoveTowards(vertexCreator, templateLine.GetPosition(pointCounter), 1f);
            templatePositions.Add(vertexCreator);

            if (Vector2.Distance(vertexCreator, templateLine.GetPosition(pointCounter)) < 2) {
                pointCounter++;
            }

        }

    // Update is called once per frame
    void Update() {

        
    }

     void DrawPolygon(int vertexNumber, float radius, Vector3 centerPos, int modifier) {
        templateCurrentLine = Instantiate(testPrefab, Vector3.zero, Quaternion.identity); //assigns the properties of "testPrefab" to "templateCurrentLine"
        templateCurrentLine.transform.SetParent(transform.parent.transform);
        templateLine = templateCurrentLine.GetComponent<LineRenderer>(); //converts the newly assigned properties of "templateCurrentLine" into a LineRender and assigns the values to "templateLine"
        templateLine.startWidth = 5;
        float angle = (2 * Mathf.PI / vertexNumber);
        templateLine.positionCount = vertexNumber;
        templateLine.loop = true;

        for (int i = 0; i < vertexNumber; i++) {
            Matrix4x4 rotationMatrix = new Matrix4x4(new Vector4(Mathf.Cos((angle * i) * modifier), Mathf.Sin((angle * i) * modifier), 0, 0),
                                                     new Vector4(-1 * Mathf.Sin((angle * i) * modifier), Mathf.Cos((angle * i) * modifier), 0, 0),
                                                     new Vector4(0, 0, 1, 0),
                                                     new Vector4(0, 0, 0, 1));
            Vector3 initialRelativePosition = new Vector3(0, radius, 0);
            templateLine.SetPosition(i, centerPos + rotationMatrix.MultiplyPoint(initialRelativePosition));
            

            }
        
        }
    }

}
