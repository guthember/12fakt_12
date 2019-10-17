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
    static double atlag;

    static void Beolvas()
    {
      Console.WriteLine("1. feladat Beolvasás");
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
      Console.WriteLine("2. feladt Kiirás");
      for (int i = 0; i < emberek.Length; i++)
      {
        emberek[i].Kiir();
      }
    }

    static void Sorrendbe()
    {
      // Növekvő sorrendbe
      Console.WriteLine("3. feladat Sorrendbe rakás");
      for (int i = 0; i < emberek.Length - 1; i++)
      {
        for (int j = i + 1; j < emberek.Length; j++)
        {
          if (emberek[i].magas > emberek[j].magas)
          {
            Ember tmp = emberek[i];
            emberek[i] = emberek[j];
            emberek[j] = tmp;
          }
        }
      }
      Console.WriteLine("Legkisebb:");
      emberek[0].Kiir();
      Console.WriteLine("Legnagyobb:");
      emberek[428].Kiir();
    }

    static void AtlagMagassag()
    {
      Console.WriteLine("4. feladat Átlagmagasság");

      // Összegzés tétel
      int sumMagassag = 0;

      for (int i = 0; i < emberek.Length; i++)
      {
        sumMagassag += emberek[i].magas;
      }

      // Átlag
      atlag = sumMagassag / (double)emberek.Length;

      Console.WriteLine("Az átlagmagasság: {0}",atlag);
    }

    static void AtlagAlatt()
    {
      Console.WriteLine("5. feladat Átlag alattiak száma");

      // megszámlálás tétel
      int darab = 0;
      for (int i = 0; i < emberek.Length; i++)
      {
        if (emberek[i].magas < atlag)
        {
          darab++;
        }
      }

      Console.WriteLine("Darabszám: {0}",darab);
    }

    static void Main(string[] args)
    {
      Beolvas();
      Kiiras();
      Sorrendbe();
      AtlagMagassag();
      AtlagAlatt();
      Console.ReadKey();
    }
  }
}
