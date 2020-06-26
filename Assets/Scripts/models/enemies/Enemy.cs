using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    private List<SerializableTransform> playerList = new List<SerializableTransform>();
    private Transform selectedPlayer;
    private int playerPos = 0;
    private int playersNumber;
    //enemy vision range
    [SerializeField]
    private float maxDist;
    [SerializeField]
    private float minDist;
    public EnemyState state;
    [SerializeField]
    private float MoveSpeed;

    private int coutn = 800;

    private void Start()
    {
        playersNumber = playerList.Count - 1;
        print("Players number" + playersNumber);
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
        if (coutn > 200)
        {
            Chase();
            coutn--;
        }
        else if (coutn > 0)
        {
            RandomMovement();
            coutn--;
        }
        else
        {
            SelectNewPlayer();
            coutn = 800;
        }
        /*
        if (state.states == EnemyStates.attacking)
        {
            print("Attacking");
            if (checkForDistance(position, playerPos))
            {
                print("Distance attack!");
                Chase();
            }
            else
            {
                state.SetState(EnemyStates.searching);
            }
        }
        else
        {
            if (state.states == EnemyStates.searching)
            {
                print("Searching");
                SelectNewPlayer();
                if (checkForDistance(position, playerPos))
                {
                    print("CHANGING TO ATTACK");
                    state.SetState(EnemyStates.attacking);
                }
            }
            else
            {
                print("Roaming forever");
            }

            state.CheckTime();

            RandomMovement();
        }
*/
    }

    private void SelectNewPlayer()
    {
        NextPlayerPos();
        SearchForNewSelectedPlayer();
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
        direction += state.position;
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
        print("OLD PLAYER: " + selectedPlayer);
        selectedPlayer = playerList[playerPos].position;
        print("NEW PLAYER: " + selectedPlayer);
    }

    private void NextPlayerPos()
    {
        print("Players number" + playersNumber);
        print("Player pos: " + playerPos);
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