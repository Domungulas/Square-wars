using UnityEngine;
using System;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using static HTTPClient;
using System.Linq;


public class HTTPClient : MonoBehaviour
{
    private HttpListener listener;
    private bool isRunning = true;

    public GameObject player;
    public PlayerHealth playerHealth;

    public bool gameOver;
    public float playerX;
    public float playerY;
    public float playerHP;
    List<Vector2> enemies;

    public float updateTimer = 0.025f;
    private float currTimer;

    void Start()
    {
        currTimer = 0f;
        gameOver = false;

        listener = new HttpListener();
        listener.Prefixes.Add("http://localhost:8000/");
        listener.Start();
        Debug.Log("HTTP Server started on port 8000");

        Thread listenerThread = new Thread(HandleRequests);
        listenerThread.Start();
    }

    public void Update()
    {
        currTimer -= Time.deltaTime;

        if (currTimer < 0f)
        {
            playerX = player.transform.position.x;
            playerY = player.transform.position.y;
            playerHP = playerHealth.health;
            enemies = GetEnemyPositions();

            currTimer = updateTimer;
        }

        if (playerHealth.IsDead())
        {
            gameOver = true;
            Debug.Log("I died");
        }

        GameState state = new GameState(gameOver, playerX, playerY, playerHP, enemies);
        string responseString = JsonUtility.ToJson(state);
        Debug.Log(responseString);
    }

    private void HandleRequests()
    {
        while (isRunning)
        {
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;

            GameState state = new GameState(gameOver, playerX, playerY, playerHP,enemies);

            if (gameOver)
            {
                gameOver = false;
            }


            string responseString = JsonUtility.ToJson(state);
            byte[] buffer = Encoding.UTF8.GetBytes(responseString);
            context.Response.ContentLength64 = buffer.Length;
            context.Response.OutputStream.Write(buffer, 0, buffer.Length);
            context.Response.OutputStream.Close();
        }
    }

    private void OnDestroy()
    {
        isRunning = false;
        listener.Stop();
    }

    void OnApplicationQuit()
    {
        isRunning = false;
        listener.Stop();
    }

    public LayerMask enemyLayer;
    public List<Vector2> GetEnemyPositions()
    {
        List<Vector2> enemyPositions = new List<Vector2>();
        Dictionary<Vector2, float> detectedEnemies = new Dictionary<Vector2, float>();

        // Get all colliders in the circle
        Collider2D[] hits = Physics2D.OverlapCircleAll(player.transform.position, 10f, enemyLayer);

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                Vector2 enemyPos = hit.transform.position;
                float distance = Vector2.Distance(transform.position, enemyPos);

                if (!detectedEnemies.ContainsKey(enemyPos)) // Avoid duplicates
                {
                    detectedEnemies[enemyPos] = distance;
                }
            }
        }

        // Sort by closest enemies and take the top 5
        var sortedEnemies = detectedEnemies.OrderBy(e => e.Value).Take(5);
        foreach (var enemy in sortedEnemies)
        {
            enemyPositions.Add(enemy.Key);
        }

        return enemyPositions;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green; // Change color if needed
        Gizmos.DrawWireSphere(player.transform.position, 10f); // Draw detection radius
    }
}

    [Serializable]
    public class GameState
    {
        public bool isGameOver;
        public float playerX;
        public float playerY;
        public float playerHP;
        public List<Vector2> enemyPositions;

        public GameState(bool gameOver, float playerx, float playery, float playerhp, List<Vector2> closestEnemies)
        {
            isGameOver = gameOver;
            playerX = playerx;
            playerY = playery;
            playerHP = playerhp;
            enemyPositions = closestEnemies;
        }
    }


