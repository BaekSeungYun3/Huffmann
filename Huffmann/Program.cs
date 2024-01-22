using System;
using System.Collections;

namespace Huffmann
{
  internal class Program
  {
    static void Main(string[] args)
    {
      //string input = "Yesterday, all my troubles seemed so far away " +
      //          "Now it looks as though they're here to stay " +
      //          "Oh, I believe in yesterday " +
      //          "Suddenly, I'm not half the man I used to be " +
      //          "There's a shadow hanging over me " +
      //          "Oh, yesterday came suddenly " +
      //          "Why she had to go I don't know she wouldn't say " +
      //          "I said something wrong, now I long for yesterday " +
      //          "Yesterday, love was such an easy game to play " +
      //          "Now I need a place to hide away " +
      //          "Oh, I believe in yesterday " +
      //          "Why she had to go I don't know she wouldn't say " +
      //          "I said something wrong, now I long for yesterday " +
      //          "Yesterday, love was such an easy game to play " +
      //          "Now I need a place to hide away " +
      //          "Oh, I believe in yesterday " +
      //          "Mm mm mm mm mm mm mm";
      string input = "GCCAAGGCTAGCCCTCAAGAGAATAACGCTGACCCTAACGCAGCCTGAGCTTCCCGCGACCACCTTAACCGCACAGTTTGGGCAAAAACTGGAACGACTGTTACATTAGAAGATAAACGATAATTACAATTGCCTTGACCCAGGAAGGCGTTTTTTAGTATACACGGTCCGACGAATTTTGTAGCCTTGAACGCTGTGCGTAGACTGGAACCTAGAATACTTGCCCGAAGCCTGCTGAGGTGTTTTTTATGCTAAAGCTACGTGTCTCTTGACTTGCTTGGACCCCGTTCCGCGCCTCCGCGACCGAACGATTGGGGTGTTATTGCAAGGTATCGCCCATCTTCGGAAAAACAGTCTCTCCACCGAGCCAGCGGACAACCGCGAGAACAGCGGAGGACACAAACACCCAAACGACGCGCAGAACCCAGGAAAACCCCGCCAGGACCAAGCACGAACCCAGAACCACCCGACCCCCAGAGCGAAGGGACCGGGCGCCACCAACCCCAAACACCCCCCCCCCCACAAACAACCCCACCAACCCACACACCAACCCACAAAACCCAACCCAAACCACCCACCACCACACCAAACAAACAACCCCCCCCCCCACCAACCACCAAACAACCACAACAAACAAACCAACCACCAACCAACCCAACAACCAACCACACCCCCACCACACCAAACCAAACCCCACCACCAAACACAACACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";

      HuffmanTree huffmanTree = new HuffmanTree();          

      // Build the Huffman tree - 허프만 트리 빌드
      huffmanTree.Build(input);

      // Encode - 0,1패턴으로 인코드
      BitArray encoded = huffmanTree.Encode(input);     //input: 입력패턴
      Console.Write("Encoded: ");
      foreach (bool bit in encoded)
      {
        Console.Write((bit ? 1 : 0) + "");
      }
      Console.WriteLine();

      // Decode - 원래 우리가 입력한 입력이 그대로 출력
      string decoded = huffmanTree.Decode(encoded);

      Console.WriteLine("Decoded: " + decoded);
      Console.WriteLine("size of input : " + input.Length * 8);
      Console.WriteLine("size of encoded : " + encoded.Length);
      Console.WriteLine("압축률 = " + (float)encoded.Length/(input.Length * 8));
    }
  }
}
