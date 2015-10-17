namespace HtmlGenerator
{
    public class HtmlForAttribute : HtmlAttribute 
    {
        internal HtmlForAttribute() : base("for", "For", null, false, false) 
        {
        }

        internal HtmlForAttribute(string value) : base("for", "For", value, false, false) 
        {
        }
    }
}
