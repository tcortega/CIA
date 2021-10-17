using System;
using System.Threading;

namespace CIA.Menus
{
    public abstract class BaseMenu
    {
        public virtual void DisplayInvalidChoice()
        {
            Console.Clear();
            Console.WriteLine("Escolha inválida! Tente novamente.");
            Thread.Sleep(1500);
            Console.Clear();
        }
    }
}