using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    // this code is a clusterfuck. maybe clean up some day...
    Vector3 obstaclePostion;
    [SerializeField] bool turnOn;
    [SerializeField] float startingYValue = 29f;
    float currentXPos;
    float currentYPos;
    float currentZPos;
    bool complete = false;
    [SerializeField] float moveRate = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        currentXPos = transform.position.x;
        currentYPos = startingYValue;
        currentZPos = transform.position.z;
        obstaclePostion = new Vector3(currentXPos, currentYPos, currentZPos);
        transform.position = obstaclePostion;
    }

    // Update is called once per frame
    void Update()
    {
        while (turnOn)
        {
            if (currentYPos <= startingYValue && !complete)
            {
                DownMovement();
                if (currentYPos <= 15)
                {
                    complete = true;
                }
            }
            else if (complete)
            {
                UpMovement();
                if (currentYPos >= startingYValue)
                {
                    complete = false;
                }
            }
        }
        
    }

    private void UpMovement()
    {
        obstaclePostion = new Vector3(currentXPos, (currentYPos += moveRate), currentZPos);
        transform.position = obstaclePostion;
    }

    private void DownMovement()
    {
        obstaclePostion = new Vector3(currentXPos, (currentYPos -= moveRate), currentZPos);
        transform.position = obstaclePostion;

    }
}
