namespace CIA.Menus
{
    public interface IMenu<T>
    {
        T DisplayAndGetChoice();
    }
}