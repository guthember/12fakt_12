using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StruktEmber
{
  struct Ember
  {
    public string nev;
    public int magas;

    public void Kiir()
    {
      Console.WriteLine("Név: {0} Magasság: {1}",nev.PadRight(20),magas);
    }
  }

  class Program
  {
    static Ember[] emberek = new Ember[429];

    static void Beolvas()
    {
      StreamReader file = new StreamReader("diakok.csv");

      // most kivételesen nem while mert tudjuk
      // nem a beolvasás a lényeg ebben a példában
      for (int i = 0; i < 429; i++)
      {
        // "Nagy János;156"
        // beolvassuk és a pontosvessző mentén szétvágjuk
        string[] adatok = file.ReadLine().Split(';');

        // adatok[0] = "Nagy János" string!!!
        // adatok[1] = "156" string!!!
        emberek[i].nev = adatok[0];
        emberek[i].magas = Convert.ToInt32(adatok[1]);
      }

      file.Close();
    }

    static void Kiiras()
    {
      for (int i = 0; i < emberek.Length; i++)
      {
        emberek[i].Kiir();
      }
    }

    static void Main(string[] args)
    {
      Beolvas();
      Kiiras();

      Console.ReadKey();
    }
  }
}
