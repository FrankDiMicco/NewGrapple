using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovementBasic : MonoBehaviour
{
    [SerializeField] float speed = .01f;
    float[] position = {1.25f, -1f};
    Transform obstacleMover;
    float obstacleXPosition;
    float screenWidth;
    int counter;
    void Start(){
        //speed *= Time.deltaTime;
        obstacleMover = gameObject.GetComponent<Transform>();
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        obstacleXPosition = obstacleMover.transform.position.x;
        counter = 0;
    }
    void Update()
    {
        if (obstacleXPosition > screenWidth || obstacleXPosition < -screenWidth){
            Debug.Log("Passed border");
            counter++;
        }
        if (counter == 2){
            counter = 0;
        }
        if (counter == 1){
            speed *= -1;
        }
        obstacleMover.Translate(speed, 0, 0);
    }
}

