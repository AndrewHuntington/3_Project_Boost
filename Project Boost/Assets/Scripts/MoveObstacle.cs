using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    Vector3 obstaclePostion;

    float startXPos;
    float startYPos;
    float startZPos;

    float maxXpos;
    float minXpos;
    float maxYpos;
    float minYpos;
    float maxZpos;
    float minZpos;

    float currentXPos;
    float currentYPos;
    float currentZPos;
    bool complete;

    [SerializeField] bool turnOn;
    [SerializeField] float adjustYUp = 0f; // max obstacle height from starting position
    [SerializeField] float adjustYDown = 0f; // min obstacle height from starting position
    [SerializeField] float moveRate = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startXPos = currentXPos = transform.position.x;
        startYPos = currentYPos = transform.position.y;
        startZPos = currentZPos = transform.position.z;
        maxYpos = startYPos + adjustYUp;
        minYpos = startYPos - adjustYDown;
        obstaclePostion = new Vector3(currentXPos, currentYPos, currentZPos);
        transform.position = obstaclePostion;
    }

    // Update is called once per frame
    void Update()
    {
        if (turnOn)
        {
            moveYAxis();
        }
    }

    private void moveYAxis()
    {        
        if (currentYPos < maxYpos && !complete)
        {
            upMovement();
            if (currentYPos >= maxYpos)
            {
                complete = true;
            }
        }
        else if (complete)
        {
            downMovement();
            if (currentYPos <= minYpos)
            {
                complete = false;
            }
        }
    }

    private void upMovement()
    {
        obstaclePostion = new Vector3(currentXPos, (currentYPos += (moveRate * Time.deltaTime)), currentZPos);
        transform.position = obstaclePostion;
    }

    private void downMovement()
    {
        obstaclePostion = new Vector3(currentXPos, (currentYPos -= (moveRate * Time.deltaTime)), currentZPos);
        transform.position = obstaclePostion;
    }
}
