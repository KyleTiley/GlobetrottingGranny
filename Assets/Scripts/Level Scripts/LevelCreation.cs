using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreation : MonoBehaviour
{
    //SECTION CREATION VARIABLES
    public GameObject startSection;
    public GameObject otherStartSection;
    public GameObject[] sections;
    private float sectionStartPosition = 0f;
    public int sectionLength = 5;
    public int sectionDifficulty;
    public int sectionNumber;
    public int tempSectionNumber;
    public float sectionCreationDelay = 1;

    //POWERUP CREATION VARIABLES
    public GameObject[] powerups;
    private float powerupStartPosition = 62.5f;
    int powerupDistance = 200;
    public int randomPowerup;
    public int powerupNumber;
    public int tempPowerupNumber;
    public float powerupCreationDelay = 10;
    public Quaternion quatPowerup = Quaternion.Euler(90,0,0);

    //BOSS VARIABLES
    public static bool spawnBoss = false;
    int tumbleSeed;
    public GameObject tumbleWeed;
    public GameObject BoulderRock;
    public float tumbleCreationDelay = 1f;
    float bossGap = 80;
    public int tempTumbler;

    //NEW VARIABLES
    bool isLevelOne = true;
    bool isLevelTwo = false;
    float gameCounter = 7;
    bool creatingLevel = false;
    bool creatingBoss = true;

    private void Start()
    {
        //Creates blank start sections
        for(int i = 0; i < 3; i++)
        {
            Instantiate(startSection, new Vector3(0,0,sectionStartPosition), Quaternion.identity);
            sectionStartPosition += sectionLength;
        }
        //Creates 5 sections at the start of the game
        for(int i = 0; i < 20; i++)
        {
            StartCoroutine(GenerateSection());
        }
        
        StartCoroutine(GeneratePowerup());

        creatingBoss = true;
    }

    private void FixedUpdate() {
        gameCounter += Time.deltaTime;
    }

    //Calls the coroutine to create sections and powerups OR spawn the boss
    private void Update()
    {
        if(gameCounter > 20){
            if(creatingLevel){
                if(isLevelOne){
                    for(int i = 0; i < 20; i++){
                        StartCoroutine(GenerateSection());  
                    }

                    StartCoroutine(GeneratePowerup());
                }
                else if(isLevelTwo){
                    for(int i = 0; i < 20; i++){
                        StartCoroutine(GenerateSection());
                    }

                    StartCoroutine(GeneratePowerup());
                }
                creatingBoss = true;
                creatingLevel = false;
            }
            else if(creatingBoss){
                if(isLevelOne){
                    for(int i = 0; i < 20; i++){
                        StartCoroutine(SpawnBossOneCoroutine()); 
                    }

                    isLevelTwo = true;
                    isLevelOne = false;
                }
                else if(isLevelTwo){
                    for(int i = 0; i < 20; i++){
                        StartCoroutine(SpawnBossTwoCoroutine()); 
                    }

                    isLevelOne = true;
                    isLevelTwo = false;
                }
                creatingLevel = true;
                creatingBoss = false;
            }
            gameCounter = 0;
        }
    }
    
    //Creates a section
    IEnumerator GenerateSection()
    {
        //Seperates prefabs into groups to create variety in sections
        repeatSection:
        sectionDifficulty = Random.Range(0,5);
        if(isLevelOne){
            switch(sectionDifficulty)
            {
                case 0:
                    sectionNumber = 0;
                    break;
                case 1:
                case 2:
                    sectionNumber = Random.Range(1,4);
                    break;
                case 3:
                case 4:
                    sectionNumber = Random.Range(4,10);
                    break;
            }
        }
        if(isLevelTwo){
            switch(sectionDifficulty)
            {
                case 0:
                    sectionNumber = 10;
                    break;
                case 1:
                case 2:
                    sectionNumber = Random.Range(11,14);
                    break;
                case 3:
                case 4:
                    sectionNumber = Random.Range(14,20);
                    break;
            }
        }
        

        //Stops the chance of repeating sections
        if(sectionNumber == tempSectionNumber)
        {
            goto repeatSection;
        }
        tempSectionNumber = sectionNumber;

        Instantiate(sections[sectionNumber], new Vector3(0,0,sectionStartPosition), Quaternion.identity);
        sectionStartPosition += sectionLength;
        yield return new WaitForSeconds(sectionCreationDelay);
    }

    //Creates a powerup
    IEnumerator GeneratePowerup()
    {
        //Randomises the powerup
        repeatPowerup:
        powerupNumber = Random.Range(0,3);
        
        //Stops the chance of repeating powerups
        if(powerupNumber == tempPowerupNumber)
        {
            goto repeatPowerup;
        }
        tempPowerupNumber = powerupNumber;
        
        Instantiate(powerups[powerupNumber], new Vector3(0,1.5f,powerupStartPosition), Quaternion.identity);
        powerupStartPosition += powerupDistance;
        yield return new WaitForSeconds(powerupCreationDelay);
    }

    //Spawns the first boss
    IEnumerator SpawnBossOneCoroutine()
    {
        Instantiate(startSection, new Vector3(0,0,sectionStartPosition), Quaternion.identity);

        repeatTumbler:
        tumbleSeed = Random.Range(0,3);

        //Stops the chance of repeating tumblers
        if(tumbleSeed == tempTumbler)
        {
            goto repeatTumbler;
        }
        tempTumbler = tumbleSeed;

        switch(tumbleSeed)
        {
            case 0:
                Instantiate(tumbleWeed, new Vector3(0,1,sectionStartPosition  + bossGap), Quaternion.identity);
                Instantiate(tumbleWeed, new Vector3(1.5f,1,sectionStartPosition + bossGap), Quaternion.identity);
                break;
            case 1:
                Instantiate(tumbleWeed, new Vector3(-1.5f,1,sectionStartPosition + bossGap), Quaternion.identity);
                Instantiate(tumbleWeed, new Vector3(1.5f,1,sectionStartPosition + bossGap), Quaternion.identity);
                break;
            case 2:
                Instantiate(tumbleWeed, new Vector3(-1.5f,1,sectionStartPosition + bossGap), Quaternion.identity);
                Instantiate(tumbleWeed, new Vector3(0,1,sectionStartPosition + bossGap), Quaternion.identity);
                break;
        }

        sectionStartPosition += sectionLength;
        yield return new WaitForSeconds(sectionCreationDelay);
    }

    //Spawns the second boss
    IEnumerator SpawnBossTwoCoroutine()
    {
        Instantiate(otherStartSection, new Vector3(0,0,sectionStartPosition), Quaternion.identity);

        repeatTumbler:
        tumbleSeed = Random.Range(0,2);

        //Stops the chance of repeating tumblers
        if(tumbleSeed == tempTumbler)
        {
            goto repeatTumbler;
        }
        tempTumbler = tumbleSeed;

        switch(tumbleSeed)
        {
            case 0:
                Instantiate(BoulderRock, new Vector3(-2,1,sectionStartPosition), Quaternion.identity);
                break;
            case 1:
                Instantiate(BoulderRock, new Vector3(2,1,sectionStartPosition), Quaternion.identity);
                break;
        }

        sectionStartPosition += sectionLength;
        yield return new WaitForSeconds(sectionCreationDelay);
    }

        IEnumerator WaitForSec()
        {
            yield return new WaitForSeconds(powerupCreationDelay);
        }
}
