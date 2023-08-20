using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace RSA_cryptosystem
{
    class Program
    {

        private static string Encrypted(string msg, int public_key_e, int N)
        {
            char[] msg_in_ascii = msg.ToCharArray();
            int msg_length = msg_in_ascii.Length;
            BigInteger[] msg_in_numbers = new BigInteger[msg_length];
            string coded_msg = "";
            // this for takes each letter from the message and puts its ASCII value in a BigInt array
            for (int letter = 0; letter < msg_length; letter++)
            {
                msg_in_numbers[letter] = (BigInteger)(msg_in_ascii[letter]);
            }
            // this for preforms RSA encryption on the ASCII values of the letters of the message
            for (int letter_in_num = 0; letter_in_num < msg_length; letter_in_num++)
            {
                msg_in_numbers[letter_in_num] = BigInteger.Pow(msg_in_numbers[letter_in_num], public_key_e) % N;
            }
            // this for turns the encrypted message's array of numbers to a string
            for (int letter_number = 0; letter_number < msg_length; letter_number++)
            {
                coded_msg = coded_msg + msg_in_numbers[letter_number].ToString() + ",";

            }
            return coded_msg;
        }
        private static string Decrypted(string coded_msg, int private_key_d, int N)
        {
            List<BigInteger> msg_in_ascii_numbers = new List<BigInteger>();
            char[] msg_in_ascii = null;
            int msg_length = coded_msg.Length;
            int beginning_of_the_num = 0;
            // this for takes each letter from the coded message and puts its ASCII value in a BigInt array
            for (int letter = 0; letter < msg_length; letter++)
                {
                    if (coded_msg[letter] == ',')
                    {
                    BigInteger l = BigInteger.Parse(coded_msg.Substring(beginning_of_the_num, letter - beginning_of_the_num));
                    msg_in_ascii_numbers.Add(l);
                    beginning_of_the_num = letter + 1;
                    }
                }
            // this for preforms RSA decryption on the ASCII values of the letters of the message
            int num_length = msg_in_ascii_numbers.Count();
            msg_in_ascii = new char[num_length];
            for (int letter_in_num = 0; letter_in_num < num_length ; letter_in_num++)
                {
                    msg_in_ascii_numbers[letter_in_num] = BigInteger.Pow(msg_in_ascii_numbers[letter_in_num], private_key_d) % N;
                    msg_in_ascii[letter_in_num] = (char)(msg_in_ascii_numbers[letter_in_num]);
                }
            // this for replaces the coded message's letters with the decrypted message's letters
            string encrypted_message = new string(msg_in_ascii);
            return encrypted_message;
        }

        static void Main(string[] args)
        {
            int e = 5;
            int d = 65;
            int NN = 133;


            while (true)
            {
                Console.Write("Would you like to decrypt or encrypt your message? ");
                string user_msg = Console.ReadLine();
                if (user_msg == "decrypt" || user_msg == "Decrypt" || user_msg == "d")
                {
                    Console.Write("Please enter the message that you would like to decrypt: ");
                    string msg_to_decrypt = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Your decrypted message is:" + Decrypted(msg_to_decrypt, d, NN));
                    Console.WriteLine();
                }
                if (user_msg == "encrypt" || user_msg == "encrypt" || user_msg == "e")
                {
                    Console.Write("Please enter the message that you would like to encrypt: ");
                    string msg_to_encrypt = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Your encrypted message is:" + Encrypted(msg_to_encrypt, e, NN));
                    Console.WriteLine();
                }
                Console.Write("Would you like to continue? If your answer is yes, please enter the number 1. If your answer is no, anything else that you'll enter will close the program. ");
                string end = Console.ReadLine();
                Console.WriteLine();
                if (end != "1")
                {
                    break;
                }
            }




        }
    }
}
