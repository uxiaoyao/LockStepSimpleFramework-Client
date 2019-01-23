using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoyT.AStar;

public class astar_test : MonoBehaviour {

	// Use this for initialization
	void Start () {


        // Create a new grid and let each cell have a default traversal cost of 1.0
        var grid = new RoyT.AStar.Grid(10, 10, 1.0f);

        // Block some cells (for example walls)
        grid.BlockCell(new Position(5, 5));

        // Make other cells harder to traverse (for example water)
        grid.SetCellCost(new Position(6, 5), 3.0f);

        // And finally start the search for the shortest path form start to end
        Position[] path = grid.GetPath(new Position(0, 0), new Position(9, 9));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
