using System;
using System.Collections.Generic;
using System.Text;

namespace The_Garage_Exercise.Tools
{
    internal class MultiTestHelper : IHelper
    {
        //MultiTestHelper lagrar en array av strings.
        //Den kan sättas genom att ge den en string som separeras av semikolon.
        //När GetInput() anropas delar den ut nästa string i ordningen.
        //Om alla strings delats ut börjar den om från början.
        private string[] _content;
        private int counter = -1;
        public string? Output { 
            get {
                counter++;
                if (counter >= _content.Length) counter = 0;
                return _content[counter];
            }
            set { 
                _content = value.Split(";"); 
            } 
        }

        public string GetInput(string message)
        {
            Console.WriteLine(message);

            return Output.ToLower();
        }

        public string GetInput()
        {
            return Output.ToLower();
        }
    }
}
