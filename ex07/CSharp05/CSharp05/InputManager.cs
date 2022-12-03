using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    //Observer Pattern
    class InputManager
    {
        public delegate void OnInputKey();
        // 마음대로 호출 불가능하게 해줌
        public event OnInputKey inputKey;

        public void Update()
        {
            if (Console.KeyAvailable == false)
                return;
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.A)
            {
                // 모두에게 알려준다.
                inputKey();
            }
        }
    }
}
