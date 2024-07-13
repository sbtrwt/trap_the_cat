using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int gridWidth = 11;
    public int gridHeight = 11;
    public float cellSize = 1f;
    public float rowOffset = 0.5f;
    public float cellSpacing = 5f; // New variable for spacing between cells
    public GameObject cellPrefab;
    public GameObject catPrefab;
    public TMP_Text gameStateText;

    private GameObject[,] grid;
    private Cat cat;
    private bool gameOver = false;

    void Start()
    {
        InitializeGrid();
        SpawnCat();
    }

    void InitializeGrid()
    {
        grid = new GameObject[gridWidth, gridHeight];
        float totalWidth = gridWidth * (cellSize + cellSpacing);
        float totalHeight = gridHeight * (cellSize * 0.866f + cellSpacing);

        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                float xPos = x * (cellSize + cellSpacing);
                float yPos = y * (cellSize * 0.866f + cellSpacing); // 0.866 is approximately sqrt(3)/2

                // Apply offset to even rows
                if (y % 2 == 0)
                {
                    xPos += rowOffset;
                }

                Vector3 position = new Vector3(
                    xPos - (totalWidth / 2),
                    yPos - (totalHeight / 2),
                    0
                );

                grid[x, y] = Instantiate(cellPrefab, position, Quaternion.identity);
                grid[x, y].GetComponent<Cell>().Initialize(x, y, this);
            }
        }
    }

    void SpawnCat()
    {
        int centerX = gridWidth / 2;
        int centerY = gridHeight / 2;
        Vector3 catPosition = grid[centerX, centerY].transform.position + new Vector3(0, 0, -1);
        GameObject catObject = Instantiate(catPrefab, catPosition, Quaternion.identity);
        cat = catObject.GetComponent<Cat>();
        cat.Initialize(this, new Vector2Int(centerX, centerY));
    }

    public bool IsCellBlocked(int x, int y)
    {
        if (x < 0 || x >= gridWidth || y < 0 || y >= gridHeight)
            return true;
        return grid[x, y].GetComponent<Cell>().isBlocked;
    }

    public void BlockCell(int x, int y)
    {
        Debug.Log($"Attempting to block cell at {x}, {y}"); // Add this line for debugging
        if (!gameOver && !IsCellBlocked(x, y))
        {
            grid[x, y].GetComponent<Cell>().Block();
            cat.Move();
            CheckGameState();
        }
    }

    void CheckGameState()
    {
        if (cat.HasEscaped())
        {
            gameOver = true;
            gameStateText.text = "Cat Escaped! You Lose!";
        }
        else if (cat.IsTrapped())
        {
            gameOver = true;
            gameStateText.text = "Cat Trapped! You Win!";
        }
    }

    public Vector3 GetCellPosition(int x, int y)
    {
        return grid[x, y].transform.position;
    }
}