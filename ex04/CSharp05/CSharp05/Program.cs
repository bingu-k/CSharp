using System;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Harry Potter";

            // 찾기
            bool found = name.Contains("Harry");// true
            int indexP = name.IndexOf("P");     // 6
            int indexz = name.IndexOf("z");     // -1

            // 변형
            string junior = name + "Junior";    // Harry PotterJunior
            string lowerCase = junior.ToLower();// Harry PotterJunior
            string upperCase = junior.ToUpper();// HARRY POTTERJUNIOR
            string newName = name.Replace('r', 'l');    // Hally Pottel

            // 분할
            string[] names = junior.Split(new char[] { ' ' });
                // [0] : Harry  [1] : PotterJunior
            string subName = junior.Substring(6);// PotterJunior
        }
    }
}