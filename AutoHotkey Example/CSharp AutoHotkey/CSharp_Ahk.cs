using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoHotkey;

namespace CSharp_AutoHotkey
{
    class CSharp_Ahk
    {
        static void Main(string[] args)
        {
            var AHK = new AutoHotkey.Interop.AutoHotkeyEngine();

            // Set Variable ( AHK.SetVar )
            // C# Code      ( var number1 = 10; )

            AHK.SetVar("number1", "10");

            // GET Variable ( AHK.GetVar )
            Console.WriteLine("number1 : {0}", AHK.GetVar("number1"));

            // Set Variable ( AHK.SetVar )
            /* C# Code      ( var number2 = 20; 
                              number1 += number2;) */

            AHK.SetVar("number2", "20");
            AHK.ExecRaw("number1 += number2");
            Console.WriteLine("number1 += number2 : {0}",AHK.GetVar("number1"));

            // Load a Library or Execute Scripts In a File
            AHK.Load("res\\ahk\\AHKFunction.ahk");

            Console.WriteLine("Msgbox Test");

            // Execute a Function ( AHKFunction.ahk )
            AHK.ExecFunction("HelloPanda", "2");

            // Eval Example
            string result = AHK.Eval("100*2-150").ToString();
            Console.WriteLine("100 * 2 - 150 : {0} \t {1}(50)", result, result.Equals("50"));

            // ImageSearch Example
            Console.WriteLine("ImageSearch");
            string _Script, _Path;

            // ImageFile
            _Path = "";
            _Script = @" 
            ImageSearch , OutX , OutY , 0 , 0 , %A_ScreenWidth% , %A_ScreenHeight% , *100 " + _Path +
            @" 
                if ErrorLevel = 0
                {
	                Mouseclick , left , %OutX% , %OutY%
                    Msgbox, ImageSearch Success.
                }
                if ErrorLevel = 1
                {
                    Msgbox, ImageSearch Fail.
                }
            ";

            AHK.ExecRaw(_Script);

            // Create New HotKey
            Console.WriteLine("HotKey");
            AHK.ExecRaw("F1::Msgbox, Hello HotKey");

            // Create New Gui
            Console.WriteLine("Gui");
            AHK.ExecFunction("CreateGui");

            Console.ReadKey();
        }
    }
}
