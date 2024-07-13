using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool isBlocked = false;
    private int x, y;
    private GameManager gameManager;
    private SpriteRenderer spriteRenderer;

    public void Initialize(int xPos, int yPos, GameManager manager)
    {
        x = xPos;
        y = yPos;
        gameManager = manager;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        if (gameManager != null)
        {
            gameManager.BlockCell(x, y);
        }
        else
        {
            Debug.LogError("GameManager is null in Cell");
        }
    }

    public void Block()
    {
        isBlocked = true;
        spriteRenderer.color = Color.blue;
    }
}