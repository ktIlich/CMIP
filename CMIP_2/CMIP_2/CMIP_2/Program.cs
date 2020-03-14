using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CMIP_2 {
  class Program {

   static double shennonEntropyFirstAlphabet = 0, shennonEntropySecondAlpahbet = 0, shennonEntropyBinaryAlphabet = 0;

    /// <summary>
    /// bel
    /// </summary>
    const string firstAlphabet = "абвгдеёжзійклмнопрстуўфхцчшыьэюя";

    /// <summary>
    /// польский
    /// </summary>
    const string secondAlphabet = "aąbcćdeęfghijklłmnńoóprsśtuwyzźż";

    /// <summary>
    /// бинарный
    /// </summary>
    const string binaryAlphabet = "01";

    const string fileFirstAlphabet = @"D:\_Labs_3_course\_Labs_2_sem\CMIP\CMIP_2\CMIP_2\CMIP_2\fisrtFile.txt";
    const string fileSecondAlphabet = @"D:\_Labs_3_course\_Labs_2_sem\CMIP\CMIP_2\CMIP_2\CMIP_2\secondFile.txt";
    const string fileBinaryAlphabet = @"D:\_Labs_3_course\_Labs_2_sem\CMIP\CMIP_2\CMIP_2\CMIP_2\binaryFile.txt";

    static void Main(string[] args) {

      Console.WriteLine("Task A\n");

      Console.WriteLine("Энтропия белорусского языка");

      EntropyAlphabet(1, firstAlphabet, fileFirstAlphabet);

      Console.WriteLine();

      Console.WriteLine("Энтропия польского языка");

      EntropyAlphabet(2, secondAlphabet, fileSecondAlphabet);

      Console.WriteLine();


      Console.WriteLine("Task B\n");

      Console.WriteLine("Энтропия бинарного алфавита");

      EntropyAlphabet(3, binaryAlphabet, fileBinaryAlphabet);

      Console.WriteLine();


      Console.WriteLine("Task C\n");

      CountAmountOfInformation(1);
      CountAmountOfInformation(2);

      Console.WriteLine("\nTask D\n");

      ErroneousTransmissionMethod();

      Console.ReadKey();
    }

    public static void EntropyAlphabet(int mode, string alphabetArr, string textFilePath) {

      int[] countLetter = new int[alphabetArr.Length];
      int countLettersInFile = 0;
      double[] probabilityLetters = new double[alphabetArr.Length];
      double entropy = 0;


      using (StreamReader streamReader = new StreamReader(textFilePath)) {

        string file = streamReader.ReadToEnd().ToLower().Replace("\r", "").Replace("\n", "").Replace(" ", "");
        file = Regex.Replace(file, @"\W+", "");
        countLettersInFile = file.Count();

        Console.WriteLine($"Количество символов в файле: {countLettersInFile}");
        Console.WriteLine();
        Console.WriteLine("Количество вхождений каждой буквы:");

        for (int i = 0; i < file.Length; i++) {

          for (int j = 0; j < alphabetArr.Length; j++) {

            countLetter[j] = file.Count(x => x == alphabetArr[j]);
            Console.WriteLine($"{ alphabetArr[j]}: { countLetter[j]}");

            probabilityLetters[j] = (double)countLetter[j] / countLettersInFile;
            Console.WriteLine($"P({alphabetArr[j]}): {probabilityLetters[j]}");
            Console.WriteLine();

            entropy += probabilityLetters[j] * (Math.Log(probabilityLetters[j], 2)) * (-1);
          }

          switch (mode) {
            case 1: {
              shennonEntropyFirstAlphabet = entropy;
              break;
            }
            case 2: {
              shennonEntropySecondAlpahbet = entropy;
              break;
            }
            case 3: {
              shennonEntropyBinaryAlphabet = entropy;
              break;
            }
          }
          Console.WriteLine("Энтропия алфавита по Шеннону:");
          Console.WriteLine(entropy);
          break;
        }
      }
    }

    public static void CountAmountOfInformation( int mode  ) {
      string fio;
      double countInfo;
      double ascii;
      if ( mode == 1 ) {
        Console.WriteLine("First FIO");
        Console.WriteLine("Кот Ілля Уладзіміравіч");
        fio = "Кот Ілля Уладзіміравіч";
        countInfo = shennonEntropyFirstAlphabet * fio.Replace(" ", "").ToLower().Count();

        Console.WriteLine("Количество информации с использованием энтропии белорусского языка:");
        Console.WriteLine(countInfo);

        Console.WriteLine();
        ascii = fio.ToLower().Count() * 8;

        Console.WriteLine();
        Console.WriteLine("Количество информации с использованием ANSII для белорусского алфавита:");

        //double ASIIenglishInformation = ascii * shennonEntropyFirstAlphabet;
        //Console.WriteLine(ASIIenglishInformation);

        Console.WriteLine(ascii);
      } else if( mode == 2 ) {
        Console.WriteLine("\nКот Ілля Уладзіміравіч");
        fio = "Кот Ілля Уладзіміравіч";

        countInfo = shennonEntropyBinaryAlphabet * fio.Replace(" ", "").ToLower().Count();

        Console.WriteLine("Количество информации с использованием энтропии бинарного алфавита:");
        Console.WriteLine(countInfo);

        Console.WriteLine();
        ascii = fio.ToLower().Count() * 8;

        Console.WriteLine("Количество информации с использованием ANSII для бинарного алфавита:");
        double ASIIbinaryInformation = ascii * shennonEntropyBinaryAlphabet;
        Console.WriteLine(ASIIbinaryInformation);
      }
    }

    public static void ErroneousTransmissionMethod() {
     
      double p = 0.1;
      double q = 1 - p;

      Console.WriteLine("Веростяность ошибочной передачи = 0.1");
     
      double conditionalEntropy = -p * (Math.Log(p) / Math.Log(2)) - q * (Math.Log(q) / Math.Log(2));
      
      Console.WriteLine($"Условная энтропия = {conditionalEntropy}");
      
      double effectiveEntropy = 1 - conditionalEntropy;
      
      Console.WriteLine($"Эффективная энтропия = {effectiveEntropy}");
      Console.WriteLine();
      
      p = 0.5;
      q = 1 - p;
      
      Console.WriteLine("Веростяность ошибочной передачи = 0.5");
      
      conditionalEntropy = -(p * (Math.Log(p) / Math.Log(2))) - (q * (Math.Log(q) / Math.Log(2)));
      
      Console.WriteLine($"Условная энтропия = {conditionalEntropy}");
      
      effectiveEntropy = 1 - conditionalEntropy;

      Console.WriteLine($"Эффективная энтропия = {effectiveEntropy}");
      Console.WriteLine();
      
      p = 1.0;
      q = 1 - p;

      Console.WriteLine("Веростяность ошибочной передачи = 1.0");
      //     conditionalEntropy = -p * (Math.Log(p) / Math.Log(2)) - q * (Math.Log(q) / Math.Log(2));

      conditionalEntropy = (p * (Math.Log(p) / Math.Log(2))) - 0; // q=0  0 * (Math.Log(0) / Math.Log(2))=0

      Console.WriteLine($"Условная энтропия = {conditionalEntropy}");
      
      effectiveEntropy = 1 - conditionalEntropy;
      
      Console.WriteLine($"Эффективная энтропия = {effectiveEntropy}");
      Console.WriteLine();
    }

   

  }
}

