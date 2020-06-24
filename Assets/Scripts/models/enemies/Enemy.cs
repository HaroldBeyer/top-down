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
    [SerializeField]
    private float MoveSpeed;

    private void Start()
    {
        SetPlayerList();
        SearchForNewSelectedPlayer();
        state = new EnemyState(playersNumber);
        rgdb.freezeRotation = true;
        MoveSpeed = 1f;
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
        state.CheckTime();
        if (state.states == EnemyStates.roaming)
        {
            RandomMovement();
        }
        else
        {
            print("Changed!");

        }

        // if (state.states == EnemyStates.attacking)
        // {
        //     if (checkForDistance(position, playerPos))
        //     {
        //         Chase();
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

        //ficar tipo 10 segundos indo pra uma posição, depois trocar;
        //ou seja, assim que mudar pra searching fazer uma nova
    }
    private void Chase()
    {
        Vector3 direction = selectedPlayer.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rgdb.rotation = angle;
        direction.Normalize();
        MoveEnemy(direction);
    }

    private void RandomMovement()
    {
        Vector2 direction = transform.position;
        direction += state.position.convertToVector2();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rgdb.rotation = angle;
        direction.Normalize();
        MoveEnemy(direction);
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

    private void MoveEnemy(Vector3 direction)
    {
        rgdb.MovePosition(transform.position + (direction * 1f * Time.deltaTime));
    }
}

/*
 var Player : Transform;
 var MoveSpeed = 4;
 var MaxDist = 10;
 var MinDist = 5;
 
*/