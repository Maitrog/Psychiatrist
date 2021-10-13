using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisplayBoard : MonoBehaviour, IPointerDownHandler, IPointerClickHandler
{
    public Dictionary<GameObject, Cell> cellsDisplayed = new Dictionary<GameObject, Cell>();
    public Dictionary<Cell, GameObject> objectsDisplayed = new Dictionary<Cell, GameObject>();
    public Board board;
    private bool turn = true;
    public Cell curCell = new Cell();
    public GameObject playerScore;
    public GameObject aiScore;
    public float AlphaThreshold = 0.001f;

    void Start()
    {
        CreateCells();
    }
    void Update()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {

    }
    public void CreateCells()
    {
        cellsDisplayed = new Dictionary<GameObject, Cell>();
        objectsDisplayed = new Dictionary<Cell, GameObject>();
        int i = 0;
        int col = 0;
        int row = 0;
        int count = 4;
        bool second = false;
        foreach (Transform obj in this.transform)
        {
            if (obj.tag == "Slot")
            {
                if (col > count || second && col > 8)
                {
                    if (count < 8 && second == false) 
                    {
                        row++;
                        count++;
                        col = 0;
                    }
                    else 
                    {
                        second = true;
                        row++;
                        col = count - 7;
                        count++;
                    }
                }
                board.container.cells[i] = new Cell(row, col/*, i*/);
                cellsDisplayed.Add(obj.gameObject, board.container.cells[i]);
                objectsDisplayed.Add(board.container.cells[i], obj.gameObject);
                board.board[row, col] = 'n';
                Debug.Log(board.container.cells[i].pos.ToString()/* + " " + board.container.cells[i].id*/);
                i++;
                col++;
            }
        }

        board.container.cells[0].ChangeOwner(Owners.Player);
        board.container.cells[60].ChangeOwner(Owners.AI);
        board.playerCells.Add(board.container.cells[0]);
        board.aiCells.Add(board.container.cells[60]);

        objectsDisplayed[board.container.cells[0]].GetComponent<Image>().color = ChangeColor(objectsDisplayed[board.container.cells[0]].GetComponent<Image>().color, 1f);
        objectsDisplayed[board.container.cells[60]].GetComponent<Image>().color = ChangeColor(objectsDisplayed[board.container.cells[60]].GetComponent<Image>().color, 0.588f, 0f, 0f, 0f);
    }
    public void ChangeTurn()
    {
        turn = false;
        List<Cell> tmpPlayer = board.playerCells;
        List<Cell> tmpAi = board.aiCells;
        char[,] tmpBoard = board.board;
        board.Minimax(board.aiCells.Count - board.playerCells.Count, true, ref tmpPlayer, ref tmpAi, ref tmpBoard);
        turn = true;
    }
    public void UpdateHexes(List<Cell> changedCells)
    {

    }
    public void OnPointerClick(PointerEventData eventData) //разбить на функции
    {
        GameObject go = eventData.pointerCurrentRaycast.gameObject;
        if (go.transform.tag == "Slot" && turn)
        {
            Debug.Log(cellsDisplayed[go].ToString());
            HandleTouch(go);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public Color ChangeColor(Color color, float a, float r = 1f, float g = 1f, float b = 1f)
    {
        color.a = a;
        color.r = r;
        color.g = g;
        color.b = b;
        return color;
    }

    public void HandleTouch(GameObject go)
    {
        if (curCell.pos.First == -1 && cellsDisplayed[go].owner == Owners.Player)//смотрим можем ли мы передвинуть эту соту (если она принадлежит игроку, то она может стать текущей)
        {
            curCell = cellsDisplayed[go];//она становится текущей
        }
        else if ((curCell.pos.First == cellsDisplayed[go].pos.First) && (curCell.pos.Second== cellsDisplayed[go].pos.Second))//смотрим, попал ли игрок по уже выбранной соте, если да, то его выбор сбрасывается
        {
            curCell = new Cell();
            if (cellsDisplayed[go].owner == Owners.Neutral)
            {
                go.GetComponent<Image>().color = ChangeColor(go.GetComponent<Image>().color, 1f);
            }
        }
        else if (curCell.pos.First >= 0 && cellsDisplayed[go].owner != Owners.Player) //смотрим, можем ли мы туда походить
        {
            int distance = board.Move(curCell, cellsDisplayed[go]);
            switch (distance)
            {
                case 1:
                    go.GetComponent<Image>().color = ChangeColor(go.GetComponent<Image>().color, 1f);
                    curCell = new Cell();//сбрасываем curCell, так как мы походили
                    if (turn)
                    {
                        cellsDisplayed[go].ChangeOwner(Owners.Player);
                        board.playerCells.Add(cellsDisplayed[go]);
                        board.board[cellsDisplayed[go].pos.First, cellsDisplayed[go].pos.Second] = 'p';
                    }

                    AfterMoveChangeDisplay(cellsDisplayed[go]);
                    ChangeTurn();
                    break;
                case 2:
                    GameObject toNeutral = objectsDisplayed[curCell];
                    cellsDisplayed[toNeutral].ChangeOwner(Owners.Neutral);
                    toNeutral.GetComponent<Image>().color = ChangeColor(toNeutral.GetComponent<Image>().color, 0.588f);

                    if (turn)
                    {
                        cellsDisplayed[go].ChangeOwner(Owners.Player);
                        board.playerCells.Add(cellsDisplayed[go]);
                        board.board[cellsDisplayed[go].pos.First, cellsDisplayed[go].pos.Second] = 'p';
                    }

                    go.GetComponent<Image>().color = ChangeColor(go.GetComponent<Image>().color, 1f);
                    curCell = new Cell();//сбрасываем curCell, так как мы походили

                    AfterMoveChangeDisplay(cellsDisplayed[go]);
                    ChangeTurn();
                    break;
                default:
                    break;
            }
        }
    }

    public void AfterMoveChangeDisplay(Cell cellPos)
    {
        foreach (Cell cell in board.AfterMove(cellPos))
        {
            if (objectsDisplayed.ContainsKey(cell))
            {
                if ((cellsDisplayed[objectsDisplayed[cell]].owner == Owners.AI) && turn || (cellsDisplayed[objectsDisplayed[cell]].owner == Owners.Player) && !turn)
                {
                    if (turn)
                    {
                        objectsDisplayed[cell].GetComponent<Image>().color = ChangeColor(objectsDisplayed[cell].GetComponent<Image>().color, 1f);
                        cellsDisplayed[objectsDisplayed[cell]].ChangeOwner(Owners.Player);
                        board.playerCells.Add(cellsDisplayed[objectsDisplayed[cell]]);
                        board.board[cellsDisplayed[objectsDisplayed[cell]].pos.First, cellsDisplayed[objectsDisplayed[cell]].pos.Second] = 'p';
                    }
                    else
                    {
                        objectsDisplayed[cell].GetComponent<Image>().color = ChangeColor(objectsDisplayed[cell].GetComponent<Image>().color, 1f, 0f, 0f, 0f);
                        cellsDisplayed[objectsDisplayed[cell]].ChangeOwner(Owners.AI);
                        board.aiCells.Add(cellsDisplayed[objectsDisplayed[cell]]);
                        board.board[cellsDisplayed[objectsDisplayed[cell]].pos.First, cellsDisplayed[objectsDisplayed[cell]].pos.Second] = 'a';
                    }
                }
            }
        }
    }
}

