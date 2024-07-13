using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Cat : MonoBehaviour
{
    private GameManager gameManager;
    private Vector2Int position;

    public void Initialize(GameManager manager, Vector2Int startPosition)
    {
        gameManager = manager;
        position = startPosition;
        UpdatePosition();
    }

    public void Move()
    {
        Vector2Int nextMove = GetBestMove();
        if (nextMove != position)
        {
            position = nextMove;
            UpdatePosition();
        }
    }

    private Vector2Int GetBestMove()
    {
        List<Vector2Int> possibleMoves = GetPossibleMoves();
        if (possibleMoves.Count == 0) return position;

        // Find the move that gets closest to an edge
        return possibleMoves.OrderBy(move => GetDistanceToEdge(move)).First();
    }

    private float GetDistanceToEdge(Vector2Int pos)
    {
        int distanceX = Mathf.Min(pos.x, gameManager.gridWidth - 1 - pos.x);
        int distanceY = Mathf.Min(pos.y, gameManager.gridHeight - 1 - pos.y);
        return Mathf.Min(distanceX, distanceY);
    }

    private List<Vector2Int> GetPossibleMoves()
    {
        List<Vector2Int> moves = new List<Vector2Int>();
        Vector2Int[] directions;

        if (position.y % 2 == 0)
        {
            // Even rows
            directions = new Vector2Int[]
            {
                new Vector2Int(0, 1), new Vector2Int(1, 1),
                new Vector2Int(1, 0), new Vector2Int(1, -1),
                new Vector2Int(0, -1), new Vector2Int(-1, 0)
            };
        }
        else
        {
            // Odd rows
            directions = new Vector2Int[]
            {
                new Vector2Int(-1, 1), new Vector2Int(0, 1),
                new Vector2Int(1, 0), new Vector2Int(0, -1),
                new Vector2Int(-1, -1), new Vector2Int(-1, 0)
            };
        }

        foreach (Vector2Int dir in directions)
        {
            Vector2Int newPos = position + dir;
            if (!gameManager.IsCellBlocked(newPos.x, newPos.y))
            {
                moves.Add(newPos);
            }
        }
        return moves;
    }

    private void UpdatePosition()
    {
        transform.position = gameManager.GetCellPosition(position.x, position.y) + new Vector3(0, 0, -1);
    }

    public bool HasEscaped()
    {
        return position.x == 0 || position.x == gameManager.gridWidth - 1 ||
               position.y == 0 || position.y == gameManager.gridHeight - 1;
    }

    public bool IsTrapped()
    {
        return GetPossibleMoves().Count == 0;
    }
}