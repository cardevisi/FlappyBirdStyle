using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {


    public int columnPoolSize = 5;
    public GameObject columnPrefab;
    public float spwanRate = 4f;
    public float columnMin = -1f;
    public float columnMax = 3.5f;

    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpwaned;
    private float spwanXPostion = 10f;
    private int currentColumn = 0;

    void Start () {
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
	}
	
	
	void Update () {
        timeSinceLastSpwaned += Time.deltaTime;
        if (GameControl.instance.gameOver == false && timeSinceLastSpwaned >= spwanRate)
        {
            timeSinceLastSpwaned = 0;
            float spwanYPosition = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spwanXPostion, spwanYPosition);
            currentColumn++;
            if(currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
	}
}
