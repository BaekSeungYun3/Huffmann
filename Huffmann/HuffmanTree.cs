using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Huffmann
{
  internal class HuffmanTree
  {
    private List<Node> nodes = new List<Node>();
    public Node Root { get; set; }
    public Dictionary<char, int> Frequencies = new Dictionary<char, int>();

    public void Build(string source)
    {
      for (int i = 0; i < source.Length; i++)
      {
        if (!Frequencies.ContainsKey(source[i]))
        {
          Frequencies.Add(source[i], 0);
        }
        Frequencies[source[i]]++;
      }

      foreach (KeyValuePair<char, int> symbol in Frequencies)
      {
        nodes.Add(new Node() { Symbol = symbol.Key, Frequency = symbol.Value });
        Console.WriteLine(symbol.Key + ": " + symbol.Value);
      }

      while (nodes.Count > 1)                               //핵심코드
      {
        List<Node> orderedNodes = nodes.OrderBy(node => node.Frequency).ToList<Node>();

        PrintOrderedNodes(orderedNodes);

        if (orderedNodes.Count >= 2)
        {
          // Take first two items
          List<Node> taken = orderedNodes.Take(2).ToList<Node>();       //take: 맨 앞에 두개 가져옴

          // Create a parent node by combining the frequencies
          Node parent = new Node()
          {
            Symbol = '*', // 합쳐진 노드라는 표시
            Frequency = taken[0].Frequency + taken[1].Frequency,
            Left = taken[0],
            Right = taken[1]
          };

          nodes.Remove(taken[0]);
          nodes.Remove(taken[1]);
          nodes.Add(parent);
        }

        this.Root = nodes.FirstOrDefault();         
      }
    }

    private void PrintOrderedNodes(List<Node> orderedNodes)
    {
      Console.WriteLine("Print OrderedNodes");
      foreach (var item in orderedNodes)
      {
        Console.WriteLine(item.Symbol + ": " + item.Frequency);
      }
    }

    public BitArray Encode(string source)               
    {
      List<bool> encodedSource = new List<bool>();          //비트들의 리스트

      for (int i = 0; i < source.Length; i++)
      {
        List<bool> encodedSymbol = this.Root.Traverse(source[i], new List<bool>());     //첫번째가 a아라면 루트에서 traverse함(TRAVERSE가 핵심)
        encodedSource.AddRange(encodedSymbol);
      }

      BitArray bits = new BitArray(encodedSource.ToArray());

      return bits;
    }

    public string Decode(BitArray bits)
    {
      Node current = this.Root;
      string decoded = "";

      foreach (bool bit in bits)
      {
        if (bit)
        {
          if (current.Right != null)
          {
            current = current.Right;
          }
        }
        else
        {
          if (current.Left != null)
          {
            current = current.Left;
          }
        }

        if (IsLeaf(current))
        {
          decoded += current.Symbol;
          current = this.Root;
        }
      }
      return decoded;
    }

    public bool IsLeaf(Node node)
    {
      return (node.Left == null && node.Right == null);
    }
  }
}