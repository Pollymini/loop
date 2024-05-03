using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public Transform[] startingPos;
    public GameObject[] rooms; // 0 - LR, 1- LRD, 2 - LRT, 3 - LRTD

    public GameObject kostyaTest;
    public GameObject Player;
 
    public Transform pSpawn;
    

    private int direction;
    public float moveAmmount;

    private float timeBtwRoom;
    public float startTimeBtwRoom = 0.01f;

    public float minX;
    public float maxX;
    public float minY;
    private bool stopGenereation;
    public int rad;

    public LayerMask room;

    private int downCounter;

    private void Start()
    {
        int randStartPos = Random.Range(0, startingPos.Length);
        transform.position = startingPos[randStartPos].position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);
        Instantiate(Player, pSpawn.transform.position ,Quaternion.identity);
        Instantiate(kostyaTest, pSpawn.transform.position, Quaternion.identity);
        direction = Random.Range(1, 6);
    }
    private void Update()
    {
        if (timeBtwRoom <= 0 && stopGenereation == false) 
        {
            Move();
            timeBtwRoom = startTimeBtwRoom;
        }
        else
        {
            timeBtwRoom -= Time.deltaTime;  
        }
    }

    private void Move()
    {
        if(direction == 1 || direction == 2)
        {
            if(transform.position.x < maxX)
            {
                downCounter = 0;

                Vector2 newPos = new Vector2(transform.position.x + moveAmmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);

                if(direction == 3 || direction == 4)
                {
                    direction = 2;
                }
                else if(direction == 4)
                {
                    direction = 5;
                }
            }
            else
            {
                direction = 5;
            }
            
        }
        else if(direction == 3 || direction == 4) 
        {
            if (transform.position.x > minX)
            {
                downCounter = 0;
                Vector2 newPos = new Vector2(transform.position.x - moveAmmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(3, 6);
                
            }
            else
            {
                direction = 5;
            }
                
        }
        else if (direction == 5)
        {
            downCounter++;
            if (transform.position.y > minY)
            {

                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, rad, room);
                
                if (roomDetection.GetComponent<RoomType>().type !=1 && roomDetection.GetComponent<RoomType>().type != 3)
                {
                    if(downCounter >= 2)
                    {
                        roomDetection.GetComponent<RoomType>().DestroyRoom();
                        Instantiate(rooms[3], transform.position, Quaternion.identity);
                        
                    }
                    else
                    {
                        roomDetection.GetComponent<RoomType>().DestroyRoom();

                        int randBottomRoom = Random.Range(1, 4);
                        if (randBottomRoom == 2)
                        {
                            randBottomRoom = 1;
                        }
                        Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);
                    }

                   
                }
                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmmount);
                transform.position = newPos;

                int rand = Random.Range(2,3);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);
            }
            else
            {
                stopGenereation = true;
            }
            
        }

      
       
        
    }

}
