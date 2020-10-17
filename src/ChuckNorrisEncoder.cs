using System;
using System.Text;

namespace Codingame
{
    public static class ChuckNorrisEncoder
    {
        public static string Encode(string message)
        {
            var binary = ToBinary(message);
            var sb = new StringBuilder();

            ComputeEncoding(sb, binary);

            return sb.ToString();
        }

        private static string ToBinary(string message)
        {
            string result = string.Empty;
            
            foreach (var ch in message)
            {
                result += Convert.ToString(ch, 2).PadLeft(7, '0');
            }

            return result;
        }

        private static void ComputeEncoding(StringBuilder sb, string binary)
        {
            var current = ' ';

            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] == current)
                    sb.Append("0");

                else if (binary[i] == '1')
                    sb.Append(i == 0 ? "0 0" : " 0 0");

                else
                    sb.Append(i == 0 ? "00 0" : " 00 0");

                current = binary[i];
            }
        }
    }
}
