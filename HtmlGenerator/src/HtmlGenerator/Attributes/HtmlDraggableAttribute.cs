namespace HtmlGenerator
{
    public class HtmlDraggableAttribute : HtmlAttribute 
    {
        internal HtmlDraggableAttribute() : base("draggable", "Draggable", null, false, false) 
        {
        }

        internal HtmlDraggableAttribute(string value) : base("draggable", "Draggable", value, false, false) 
        {
        }
    }
}
