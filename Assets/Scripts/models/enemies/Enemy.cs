using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableTransform
{
    [SerializeField]
    public Transform position;
    [SerializeField]
    public int saveableItemID;
    public SerializableTransform(Transform t, int saveableItemID)
    {
        this.position = t;
        this.saveableItemID = saveableItemID;
    }
}

public class Enemy : Character
{
    [SerializeField]
    private List<SerializableTransform> playerList;
    private Transform selectedPlayer;
    private int playerPos = 0;
    [UnityEngine.SerializeField]
    private int playersNumber;
    //enemy vision range
    [SerializeField]
    private int maxDist;
    [SerializeField]
    private int minDist;
    public EnemyState state;

    private void Start()
    {
        SetPlayerList();
        SearchForNewSelectedPlayer();
        state = new EnemyState(playersNumber);
        rgdb.freezeRotation = true;

    }

    private void Update()
    {
        //3 situações
        //1 => encontrou jogador e ele esta proximo para atacar, perseguir
        //2 => encontrou jogador e ele não está proximo para atacar, procurar outro
        //3 => verificar se todos estão longe? se sim, randomicamente andar pelo mapa. se não, voltar para passo 1
        // andar randomicamente pelo mapa
        //
        Vector2 position = transform.position;
        Vector2 playerPos = selectedPlayer.position;
        Chase();
        // if (state.states == EnemyStates.attacking)
        // {
        //     if (checkForDistance(position, playerPos))
        //     {
        //         Chase(playerPos);
        //     }
        //     else
        //     {
        //         state.SetState(EnemyStates.searching);
        //     }
        // }
        // else
        // {
        //     print("Searching or roaming");
        //     if (state.states == EnemyStates.searching)
        //     {
        //         SearchForNewSelectedPlayer();

        //         if (checkForDistance(position, playerPos))
        //         {
        //             state.SetState(EnemyStates.attacking);
        //         }
        //     }

        //     state.CheckTime();

        //     RandomMovement(position);
        // }
    }

    private void Chase()
    {
        //rotação mudando -2f
        Vector2 direction = selectedPlayer.position - transform.position;
        if (direction.x < 0)
            direction.x = direction.x + direction.x;
        if (direction.y < 0)
            direction.y = direction.y + direction.y;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle < 0)
            angle = angle + angle;
        // angle = Utils.limitRotation(angle);
        rgdb.rotation = angle;
        direction.Normalize();
        Move(direction);
        print("Direction: " + direction);
    }

    private void RandomMovement(Vector2 position)
    {
        var x = Random.Range(-10, 10);
        var y = Random.Range(-10, 10);
        var movePostion = new Vector2(x, y);
        Move(movePostion);
    }

    private bool checkForDistance(Vector2 position, Vector2 playerPos)
    {
        float distance = Vector2.Distance(position, playerPos);
        if (distance <= maxDist)
            return true;
        return false;
    }

    private void SearchForNewSelectedPlayer()
    {
        selectedPlayer = playerList[playerPos].position;
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
        playerList = new List<SerializableTransform>();

        var objs = GameObject.FindGameObjectsWithTag("Player");

        playersNumber = objs.Length;

        foreach (var obj in objs)
        {
            playerList.Add(new SerializableTransform(obj.transform, playerPos));
        }
    }
}

/*
 var Player : Transform;
 var MoveSpeed = 4;
 var MaxDist = 10;
 var MinDist = 5;
 
*/