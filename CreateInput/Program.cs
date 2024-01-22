using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateInput
{
  internal class Program            //딕셔너리를 사용한다는 것이 중요
    {
    static void Main(string[] args)
    {
      Random r = new Random();
      // 랜덤하게 A: 450 T: 90 G: 120 C: 270
      Dictionary<char, int> freq = new Dictionary<char, int>();         //char: key / int: value
      freq.Add('A', 450);
      freq.Add('T', 90);
      freq.Add('G', 120);
      freq.Add('C', 270);

      int total = 0;
      foreach (var item in freq)
        total += item.Value;        // value를 다 더한 값
      Console.WriteLine(total);

      string output = "";          //패턴을 만들음
      string source = "ATGC";       //인덱스를 말함
      for(int i=0; ; i++)
      { 
        int index = r.Next() % 4;
        char c = source[index];             //랜덤하게 ATGC를 돌려 뽑음
        if (--freq[c] >= 0)                 //숫자를 범위 넘지 않게 뽑기 위해 사용
        {
          output += source[index];
          if (--total <= 0)
            break;
        }
      }
      Console.WriteLine(output);            
    }
  }
}
