using System;

namespace CodecSoftware
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CodecType();
        }

        public static void CodecType()
        {
            while (true)
            {
                Console.WriteLine("1 - Encrypt, 2 - Decrypt");
                Console.Write("Option: ");

                if (!int.TryParse(Console.ReadLine(), out int option))
                {
                    Console.WriteLine("\nInvalid input. Try again.\n");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        Console.WriteLine("\nEnter the phrase you want to be encrypted and a password for it:");
                        Console.Write("Phrase: ");
                        string phraseEncryption = Console.ReadLine();

                        Console.Write("Password: ");
                        string passwordEncryption = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(phraseEncryption))
                        {
                            Console.WriteLine("\nInvalid input. The phrase cannot be empty or null.\n");
                            continue;
                        }

                        CODEC.Encrypt(phraseEncryption, passwordEncryption);
                        return;

                    case 2:
                        Console.WriteLine("\nEnter the phrase you want to be decrypted and the password of it:");
                        Console.Write("Phrase: ");
                        string phraseDecryption = Console.ReadLine();

                        Console.Write("Password: ");
                        string passwordDecryption = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(phraseDecryption))
                        {
                            Console.WriteLine("\nInvalid input. The phrase cannot be empty or null.\n");
                            continue;
                        }

                        CODEC.Decrypt(phraseDecryption, passwordDecryption);
                        return;

                    default:
                        Console.WriteLine("\nOption is wrong/not available. Try again!\n");
                        break;
                }
            }
        }
    }
}
