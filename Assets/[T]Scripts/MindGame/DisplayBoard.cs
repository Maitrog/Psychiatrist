using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisplayBoard : MonoBehaviour, IPointerDownHandler, IPointerClickHandler
{
    public Dictionary<GameObject, Cell> cellsDisplayed = new Dictionary<GameObject, Cell>();
    public Dictionary<Cell, GameObject> objectsDisplayed = new Dictionary<Cell, GameObject>();
    public Board board;
    public int turn = 0;
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
                board.container.cells[i] = new Cell(row, col, i);
                cellsDisplayed.Add(obj.gameObject, board.container.cells[i]);
                objectsDisplayed.Add(board.container.cells[i], obj.gameObject);
                Debug.Log(board.container.cells[i].pos.ToString() + " " + board.container.cells[i].id);
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
        if (go.transform.tag == "Slot")
        {
            if (curCell.id == -1 && cellsDisplayed[go].owner == Owners.Player)//смотрим можем ли мы передвинуть эту соту (если она принадлежит игроку, то она может стать текущей)
            {
                curCell = cellsDisplayed[go];//она становится текущей
                Color color;
                color = go.GetComponent<Image>().color;
                color.a = 1f;
                go.GetComponent<Image>().color = color;//меняем ее цвет на цвет игрокв
                Debug.Log("curCell id: " + curCell.id);
            }
            else if (curCell.id == cellsDisplayed[go].id)//смотрим, попал ли игрок по уже выбранной соте, если да, то его выбор сбрасывается
            {
                curCell = new Cell();
                if (cellsDisplayed[go].owner == Owners.Neutral)
                {
                    Color color;
                    color = go.GetComponent<Image>().color;
                    color.a = 0.588f;
                    go.GetComponent<Image>().color = color;
                }
                Debug.Log("Deselected");
            }
            else if (curCell.id >= 0 && cellsDisplayed[go].owner != Owners.Player) //смотрим, можем ли мы туда походить
            {
                Debug.Log("Where id: " + cellsDisplayed[go].id);
                int distance = board.Move(curCell, cellsDisplayed[go]);
                Debug.Log("Distance: " + distance);
                if (distance == 1)
                {
                    cellsDisplayed[go].ChangeOwner(Owners.Player);
                    Color color;
                    color = go.GetComponent<Image>().color;
                    color.a = 1f;
                    go.GetComponent<Image>().color = color;//меняем ее цвет на цвет игрокв
                    curCell = new Cell();//сбрасываем curCell, так как мы походили
                }
                else if (distance == 2)
                {
                    GameObject toNeutral = objectsDisplayed[curCell];
                    cellsDisplayed[toNeutral].ChangeOwner(Owners.Neutral);
                    Color color;
                    color = toNeutral.GetComponent<Image>().color;
                    color.a = 0.588f;
                    toNeutral.GetComponent<Image>().color = color;




                    cellsDisplayed[go].ChangeOwner(Owners.Player);
                    color = go.GetComponent<Image>().color;
                    color.a = 1f;
                    go.GetComponent<Image>().color = color;//меняем ее цвет на цвет игрокв
                    curCell = new Cell();//сбрасываем curCell, так как мы походили
                }
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
}
