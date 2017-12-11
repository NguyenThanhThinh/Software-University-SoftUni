namespace MVC.Framework.Contracts
{
    public interface IActionResult : IInvocable
    {
        IRenderable Action { get; set; }
    }
}