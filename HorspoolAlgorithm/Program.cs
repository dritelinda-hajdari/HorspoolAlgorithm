using System;

namespace HorspoolAlgorithm
{
    class Program
    {
        public static int[] shiftTable;
        static void Main(string[] args)
        {
            Console.WriteLine("------------Horspool Algorithm------------\n\n");

            Console.Write("Enter text: ");
            String text = Console.ReadLine();
            Console.Write("\nEnter plaintext you want to find in the above text: ");
            String plaintext = Console.ReadLine();
            shiftTable = new int[256];
            Program.populateShiftTable(plaintext);
            int position = Program.horspool(plaintext, text);
            if (position == -1)
                Console.WriteLine("\nPlaintext not found!");
            else
                Console.WriteLine("Plaintext found in this position: \t" + position + "\n");
        }

        public static int horspool(String plaintext, String text) 
        {
            char[] plaintextArray = plaintext.ToCharArray();
            char[] textArray = text.ToCharArray();
            int length = plaintextArray.Length;
            int k, position;
            for (int i = length - 1; i < textArray.Length;)
            {
                k = 0;
                while ((k < length) && (plaintextArray[length - 1 - k] == textArray[i - k]))
                    k++;
                if (k == length)
                {
                    position = i - length + 2;
                    return position;
                }
                else
                    i += shiftTable[textArray[i]];
            }
            return -1;
        }

        public static void populateShiftTable(String plaintext)
        {
            char[] plaintextArray = plaintext.ToCharArray();
            int length = plaintext.Length;
            for (int i = 0; i < shiftTable.Length; i++)
                shiftTable[i] = length;

            for (int i = 0; i < length-1; i++)
                shiftTable[plaintextArray[i]] = length - 1 - i;
        }
    }
}
