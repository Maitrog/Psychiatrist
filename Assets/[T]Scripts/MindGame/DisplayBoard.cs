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
                Debug.Log(board.container.cells[i].pos.ToString()/* + " " + board.container.cells[i].id*/);
                i++;
                col++;
            }
        }

        board.container.cells[0].ChangeOwner(Owners.Player);
        
        Color color;
        color = objectsDisplayed[board.container.cells[0]].GetComponent<Image>().color;
        color.a = 1f;
        objectsDisplayed[board.container.cells[0]].GetComponent<Image>().color = color;
    }
    public void ChangeTurn()
    {

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

    public Color ChangeColor(Color color, float a)
    {
        color.a = a;
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
                    //cellsDisplayed[go].ChangeOwner(Owners.Player);
                    go.GetComponent<Image>().color = ChangeColor(go.GetComponent<Image>().color, 1f);
                    curCell = new Cell();//сбрасываем curCell, так как мы походили
                    if (turn)
                        cellsDisplayed[go].ChangeOwner(Owners.Player);
                    else
                        cellsDisplayed[go].ChangeOwner(Owners.AI);

                    AfterMoveChangeDisplay(cellsDisplayed[go]);
                    ChangeTurn();
                    break;
                case 2:
                    GameObject toNeutral = objectsDisplayed[curCell];
                    cellsDisplayed[toNeutral].ChangeOwner(Owners.Neutral);
                    toNeutral.GetComponent<Image>().color = ChangeColor(toNeutral.GetComponent<Image>().color, 0.588f);

                    if (turn)
                        cellsDisplayed[go].ChangeOwner(Owners.Player);
                    else
                        cellsDisplayed[go].ChangeOwner(Owners.AI);
                    go.GetComponent<Image>().color = ChangeColor(go.GetComponent<Image>().color, 1f);
                    curCell = new Cell();//сбрасываем curCell, так как мы походили

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
                objectsDisplayed[cell].GetComponent<Image>().color = ChangeColor(objectsDisplayed[cell].GetComponent<Image>().color, 1f);
                if (turn)
                    cellsDisplayed[objectsDisplayed[cell]].ChangeOwner(Owners.Player);
                else
                    cellsDisplayed[objectsDisplayed[cell]].ChangeOwner(Owners.AI);
            }
        }
    }
}

