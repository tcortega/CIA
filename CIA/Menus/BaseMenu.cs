using System;
using System.Threading;

namespace CIA.Menus
{
    public abstract class BaseMenu
    {
        public void DisplayInvalidChoice(ArgumentException ex)
        {

            if (ex.ParamName == "M")
            {
                var message = ex.Message.Replace("(Parameter 'M')", "");
                DisplayInvalidChoice(message);
            }
            else
                DisplayInvalidChoice();
        }
        public virtual void DisplayInvalidChoice()
        {
            Console.Clear();
            Console.WriteLine("Escolha inválida! Tente novamente.");
            Thread.Sleep(1500);
            Console.Clear();
        }

        public virtual void DisplayInvalidChoice(string text)
        {
            Console.Clear();
            Console.WriteLine(text);
            Thread.Sleep(1500);
            Console.Clear();
        }
    }
}