namespace HtmlGenerator
{
    public class HtmlIconAttribute : HtmlAttribute 
    {
        internal HtmlIconAttribute() : base("icon", "Icon", null, false, false) 
        {
        }

        internal HtmlIconAttribute(string value) : base("icon", "Icon", value, false, false) 
        {
        }
    }
}
