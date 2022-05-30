using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    //SECTION CREATION VARIABLES
    public GameObject startSection;
    public GameObject[] sections;
    private float sectionStartPosition = 0f;
    public int sectionLength = 5;
    public bool isCreatingSection = false;
    public int sectionDifficulty;
    public int sectionNumber;
    public int tempSectionNumber;
    public float sectionCreationDelay = 1;

    //POWERUP CREATION VARIABLES
    public GameObject[] powerups;
    private float powerupStartPosition = 17.5f;
    public int powerupDistance = 50;
    public int randomPowerup;
    public bool isCreatingPowerup = false;
    public int powerupNumber;
    public int tempPowerupNumber;
    public float powerupCreationDelay = 10;
    public Quaternion quatPowerup = Quaternion.Euler(90,0,0);

    //BOSS VARIABLES
    float bossCounter = 0;
    bool spawnBoss = false;
    bool isSpawningBoss = false;
    bool bossHasSpawned = false;
    int tumbleSeed;
    public GameObject tumbleWeed;
    public float tumbleCreationDelay = 0.1f;
    public float bossStartPosition;
    public float bossGap = 0;

    private void Start()
    {
        //Creates blank start sections
        for(int i = 0; i < 3; i++)
        {
            Instantiate(startSection, new Vector3(0,0,sectionStartPosition), Quaternion.identity);
            sectionStartPosition += sectionLength;
        }
        //Creates 5 sections at the start of the game
        for(int i = 0; i < 5; i++)
        {
            sectionNumber = Random.Range(0,10);
            Instantiate(sections[sectionNumber], new Vector3(0,0,sectionStartPosition), Quaternion.identity);
            sectionStartPosition += sectionLength;
        }
    }

    //Calls the coroutine to create sections and powerups OR spawn the boss
    private void Update()
    {
        if(spawnBoss == true)
        {
            if(isSpawningBoss == false)
            {
                isSpawningBoss = true;
                StartCoroutine(SpawnBoss());
            }
        }
        else
        {
            if(isCreatingSection == false)
            {
                isCreatingSection = true;
                StartCoroutine(GenerateSection());
            }

            if(isCreatingPowerup == false)
            {
                isCreatingPowerup = true;  
                StartCoroutine(GeneratePowerup());
            }
        }
    }

    //Spawns the boss after 30 seconds of gameplay
    private void FixedUpdate()
    {
        bossCounter += Time.deltaTime;
        if(bossHasSpawned ==true && bossCounter > 30f)
        {
            Debug.Log("BACK TO MAIN MENU");
        }
        else if(bossCounter > 30f)
        {
            spawnBoss = true;
            if(bossHasSpawned == false)
            {
                bossStartPosition = sectionStartPosition+85;
            }
            bossHasSpawned = true;
            bossCounter = 0;
        }
        else if(bossHasSpawned == true)
        {
            spawnBoss = true;
        }
    }
    
    //Creates a section
    IEnumerator GenerateSection()
    {
        //Seperates prefabs into groups to create variety in sections
        repeatSection:
        sectionDifficulty = Random.Range(0,5);
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

        //Stops the chance of repeating sections
        if(sectionNumber == tempSectionNumber)
        {
            goto repeatSection;
        }
        tempSectionNumber = sectionNumber;

        Instantiate(sections[sectionNumber], new Vector3(0,0,sectionStartPosition), Quaternion.identity);
        sectionStartPosition += sectionLength;
        yield return new WaitForSeconds(sectionCreationDelay);
        isCreatingSection = false;
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
        isCreatingPowerup = false;
    }

    //Spawns the boss
    IEnumerator SpawnBoss()
    {
        Instantiate(startSection, new Vector3(0,0,sectionStartPosition), Quaternion.identity);

        if(bossCounter > 0)
        {
            tumbleSeed = Random.Range(0,3);
            switch(tumbleSeed)
            {
                case 0:
                    Instantiate(tumbleWeed, new Vector3(-1.5f,1,bossStartPosition-bossGap), Quaternion.identity);
                    Instantiate(tumbleWeed, new Vector3(0,1,bossStartPosition-bossGap), Quaternion.identity);
                    bossStartPosition += bossGap;
                    Instantiate(tumbleWeed, new Vector3(0,1,bossStartPosition), Quaternion.identity);
                    Instantiate(tumbleWeed, new Vector3(1.5f,1,bossStartPosition), Quaternion.identity);
                    bossStartPosition += bossGap;
                    break;
                case 1:
                    Instantiate(tumbleWeed, new Vector3(0,1,bossStartPosition-bossGap), Quaternion.identity);
                    Instantiate(tumbleWeed, new Vector3(1.5f,1,bossStartPosition-bossGap), Quaternion.identity);
                    bossStartPosition += bossGap;
                    Instantiate(tumbleWeed, new Vector3(-1.5f,1,bossStartPosition), Quaternion.identity);
                    Instantiate(tumbleWeed, new Vector3(1.5f,1,bossStartPosition), Quaternion.identity);
                    bossStartPosition += bossGap;
                    break;
                case 2:
                    Instantiate(tumbleWeed, new Vector3(-1.5f,1,bossStartPosition-bossGap), Quaternion.identity);
                    Instantiate(tumbleWeed, new Vector3(1.5f,1,bossStartPosition-bossGap), Quaternion.identity);
                    bossStartPosition += bossGap;
                    Instantiate(tumbleWeed, new Vector3(-1.5f,1,bossStartPosition), Quaternion.identity);
                    Instantiate(tumbleWeed, new Vector3(0,1,bossStartPosition), Quaternion.identity);
                    bossStartPosition += bossGap;
                    break;
            }
        }
        
        sectionStartPosition += sectionLength;
        yield return new WaitForSeconds(sectionCreationDelay);
        isSpawningBoss = false;
    }
}
