using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject birdPrefab;
    public Transform[] birdPositions;
    public List<Bird> birds = new List<Bird>();
    public List<Pig> pigs = new List<Pig>();
    public LineRenderer leftLineRender;

    public LineRenderer rightLineRender;
    public Transform rightPos;
    public Transform leftPos;
    public Rigidbody2D rg;
    public static GameManager instance;
    public GameObject boom;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.Init();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Init()
    {
        //创建3个鸟
        birds.Clear();
        var birdObj1 = Instantiate(birdPrefab, birdPositions[0].position, Quaternion.identity);
        this.SetActiveBirdData(birdObj1);
        birds.Add(birdObj1.GetComponent<Bird>());

        var birdObj2 = Instantiate(birdPrefab, birdPositions[1].position, Quaternion.identity);
        this.SetWaitBirdData(birdObj2);
        birds.Add(birdObj2.GetComponent<Bird>());


        var birdObj3 = Instantiate(birdPrefab, birdPositions[2].position, Quaternion.identity);
        this.SetWaitBirdData(birdObj3);
        birds.Add(birdObj3.GetComponent<Bird>());
    }

    public void NextBird()
    {
        if (pigs.Count > 0)
        {
            if (birds.Count == 3)
            {
                birds.RemoveAt(0);
                this.SetActiveBirdData(birds[0].gameObject);
                birds[0].transform.position = birdPositions[0].position;
                
                birds[1].transform.position = birdPositions[1].position;
            }
            else if (birds.Count == 2)
            {
                birds.RemoveAt(0);
                this.SetActiveBirdData(birds[0].gameObject);
                birds[0].transform.position = birdPositions[0].position;
            }
            else
            {
                Debug.Log("Game Over!!!");
            }
        }
        else
        {
            Debug.Log("You Win!!!");
        }
    }

    private void SetActiveBirdData(GameObject go)
    {
        var bird = go.GetComponent<Bird>();
        bird.leftPos = this.leftPos;
        bird.rightPos = this.rightPos;
        bird.leftLineRender = leftLineRender;
        bird.rightLineRender = rightLineRender;
        bird.boom = this.boom;
        var sp = go.GetComponent<SpringJoint2D>();
        sp.enabled = true;
        sp.connectedBody = rg;
    }

    private void SetWaitBirdData(GameObject go)
    {
        var sp = go.GetComponent<SpringJoint2D>();
        sp.enabled = false;
        var bird = go.GetComponent<Bird>();
//        bird.leftPos = this.leftPos;
//        bird.rightPos = this.rightPos;
//        bird.leftLineRender = leftLineRender;
//        bird.rightLineRender = rightLineRender;
    }
}