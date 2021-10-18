namespace CIA.Menus
{
    public interface ISubMenu : IMenu<SubMenuChoices> 
    {
        void Create();
        void Delete();
        void Update();
        void View();
    }
}