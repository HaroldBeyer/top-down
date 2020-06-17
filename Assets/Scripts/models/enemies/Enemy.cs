using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    // [UnityEngine.SerializeField]
    private List<Transform> playerList;
    private Transform selectedPlayer;
    private int playerPos = 0;
    private int playersNumber;
    //enemy vision range
    private int maxDist;
    private int minDist;
    public EnemyState state;

    private void Start()
    {
        SetPlayerList();
        SearchForNewSelectedPlayer();

    }

    private void Update()
    {
        Vector2 position = selectedPlayer.position;
        if (Vector2.Distance(transform.position, selectedPlayer.position) <= maxDist)
        {
            //move there!
            var x = position.x;
            var y = position.y;
            var movePostion = new Vector2(x, y);
            Move(movePostion);
        }
        else
        {
            SearchForNewSelectedPlayer();
        }
    }

    private void SearchForNewSelectedPlayer()
    {
        selectedPlayer = playerList[playerPos];
    }

    private void NextPlayerPos()
    {
        if (playerPos >= playersNumber)
        {
            playerPos = 0;
        }
        else
        {
            playerPos++;
        }
    }

    private void SetPlayerList()
    {
        playerList = new List<Transform>();

        var objs = GameObject.FindGameObjectsWithTag("Player");

        playersNumber = objs.Length;

        foreach (var obj in objs)
        {
            playerList.Add(obj.transform);
        }
    }
}

/*
 var Player : Transform;
 var MoveSpeed = 4;
 var MaxDist = 10;
 var MinDist = 5;
 
*/