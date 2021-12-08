using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BoardTest
{
    Board board = new Board();

    [Test]
    public void TestBoard()
    {
        Assert.Greater(board.minimaxDepth, 0);
        Assert.AreEqual(board.aiScore, 0);
        Assert.AreEqual(board.playerScore, 0);
    }

    [Test]
    public void MoveTest()
    {
        Assert.AreEqual(board.Move(new Cell(0, 0, Owners.Neutral), new Cell(3, 3, Owners.Neutral)), -1);
        Assert.AreEqual(board.Move(new Cell(1, 2, Owners.Neutral), new Cell(1, 3, Owners.Neutral)), 1);
        Assert.AreEqual(board.Move(new Cell(1, 2, Owners.Neutral), new Cell(2, 2, Owners.Neutral)), 1);
        Assert.AreEqual(board.Move(new Cell(2, 2, Owners.Neutral), new Cell(1, 2, Owners.Neutral)), 1);
        Assert.AreEqual(board.Move(new Cell(4, 3, Owners.Neutral), new Cell(6, 5, Owners.Neutral)), 2);
        Assert.AreEqual(board.Move(new Cell(3, 3, Owners.Neutral), new Cell(5, 4, Owners.Neutral)), 2);
    }

    [Test]
    public void AfterMoveTest()
    {
        List<Cell> changedCells = board.AfterMove(new Cell(2, 2, Owners.Neutral));
        Assert.AreEqual(changedCells.Count, 6);
    }
}
