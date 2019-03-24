using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Resources
{
    public class Message
    {
        private string text;
        private string foregroundColor;
        public string Text
        {
            get
            {
                return text;
            }
        }
        public string ForegroundColor
        {
            get
            {
                return foregroundColor;
            }
        }

        public Message(string text, string foregroundColor)
        {
            this.text = text;
            this.foregroundColor = foregroundColor;
        }
    }
}
