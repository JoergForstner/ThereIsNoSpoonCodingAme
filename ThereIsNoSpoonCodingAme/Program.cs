using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Don't let the machines win. You are humanity's last hope...
 **/

public class Node
{
  public int OwnX { get; set; }
  public int OwnY { get; set; }
  public int NeighborRightX { get; set; }
  public int NeighborRightY { get; set; }
  public int NeighborBottomX { get; set; }
  public int NeighborBottomY { get; set; }
  public Boolean IsNode { get; set; }
}


class Player
{
  static void Main(string[] args)
  {
    int width = int.Parse(Console.ReadLine()); // the number of cells on the X axis
    int height = int.Parse(Console.ReadLine()); // the number of cells on the Y axis
    var NodeList = new List<Node>();
    for (int i = 0; i < height; i++)
    {
      string line = Console.ReadLine(); // width characters, each either 0 or .
      var lastNodeIndexinRow = -1;
      for (int j = 0; j < line.Length; j++)
      {
        NodeList.Add(new Node
        {
          OwnX = j,
          OwnY = i,
          NeighborRightX = -1,
          NeighborRightY = -1,
          NeighborBottomX = -1,
          NeighborBottomY = -1,
          IsNode = line[j] == '0' ? true : false
        });
        if (NodeList[i * width + j].IsNode)
        {
          if (lastNodeIndexinRow != -1)
          { 
            NodeList[lastNodeIndexinRow].NeighborRightX = NodeList[i * width + j].OwnX;
            NodeList[lastNodeIndexinRow].NeighborRightY = NodeList[i * width + j].OwnY;
          }
          lastNodeIndexinRow = i * width + j;
        };
        //if Node is not a node, the node above must have NeighborCoordinates -1,-1
        if (i > 0 & NodeList[i*width + j].IsNode) {
          for(int k = i-1; k <= 0; k--)
          {
            if (NodeList[k * width + j].IsNode)
            {
              NodeList[k * width + j].NeighborBottomX = NodeList[i * width + j].OwnX;
              NodeList[k * width + j].NeighborBottomY = NodeList[i * width + j].OwnY;
              break;
            }
          }
        };
      } 
    }
    // Three coordinates: a node, its right neighbor, its bottom neighbor
    foreach (Node node in NodeList){
      if (node.IsNode) {
        Console.WriteLine(Convert.ToString(node.OwnX) + ' ' + Convert.ToString(node.OwnY) + 
                          ' ' + Convert.ToString(node.NeighborRightX) + ' ' + Convert.ToString(node.NeighborRightY)
                          + ' ' + Convert.ToString(node.NeighborBottomX) + ' ' + Convert.ToString(node.NeighborBottomY));
      }
    }
  }
}
