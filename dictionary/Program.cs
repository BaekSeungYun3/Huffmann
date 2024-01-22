using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dictionary        
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Dictionary<char, int> freq = new Dictionary<char, int>();
      freq.Add('a', 10);
      freq.Add('c', 20);
      freq.Add('d', 30);
      freq.Add('b', 40);

      //var ord = dict.OrderBy(key => key.Key);
      var ordered = freq.OrderBy(item => item.Key);

      foreach (KeyValuePair<char, int> item in ordered)
        Console.WriteLine(item.Key + " : " + item.Value);
    }
  }
}
