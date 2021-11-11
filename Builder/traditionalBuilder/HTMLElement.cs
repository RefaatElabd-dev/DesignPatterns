using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class HTMLElement
    {
        public string Name, Text;
        public List<HTMLElement> Elements = new List<HTMLElement>();
        private const int indentSize = 2;
        public HTMLElement()
        {

        }
        public HTMLElement(string name, string text)
        {
            Name = name ?? throw new ArgumentNullException(paramName: (nameof(name)));
            Text = text ?? throw new ArgumentNullException(paramName:(nameof(text)));
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);

            sb.Append($"{i}<{Name}>\n");

            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.Append(Text);
                sb.Append("\n");
            }

            foreach (var e in Elements)
            {
                sb.Append(e.ToStringImpl(indent + 1));
            }

            sb.Append($"{i}</{Name}>\n");

            return sb.ToString();
        }

       

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }
}
