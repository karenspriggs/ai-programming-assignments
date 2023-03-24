using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineFSM
{
    public class VendingMachine
    {
        public VendingMachineState currentState = VendingMachineState.Active;
        public Output currentOutput = Output.Nothing;

        public VendingMachine()
        {
            
        }

        public void Run()
        {
            DoState();
        }

        void ActiveState()
        {
            Console.Clear();
            ListItems();
            string choice = GetMenuInput();

            switch (choice)
            {
                case ("1"):
                    Transaction.Instance.AddQuarter();
                    ChangeState(Input.AddQuarter);
                    break;
                case ("2"):
                    ChangeState(Input.Select);
                    break;
                case ("3"):
                    ChangeState(Input.Cancel);
                    break;
                default:
                    currentState = VendingMachineState.Active;
                    DoState();
                    break;
            }
        }

        void SelectState()
        {
            if (Transaction.Instance.currentPrice < 0.5M)
            {
                Console.WriteLine("You have not inserted enough quarters to buy anything! Press enter to continue");
                Console.ReadKey();
                currentState = VendingMachineState.Active;
                DoState();
            } else
            {
                string choice = GetItemInput();

                switch (choice)
                {
                    case ("1"):
                        currentOutput = Output.Gum;
                        ChangeState(Input.Buy);
                        break;
                    case ("2"):
                        currentOutput = Output.Granola;
                        ChangeState(Input.Buy);
                        break;
                    case ("3"):
                        ChangeState(Input.Cancel);
                        break;
                    default:
                        currentState = VendingMachineState.Active;
                        DoState();
                        break;
                }
            }
        }

        void VendState()
        {
            while (Transaction.Instance.currentPrice > 0)
            {
                GetOutput();
                currentOutput = Output.Quarter;
                Console.ReadKey();
            }
            
            ChangeState(Input.Cancel);
        }

        void DoState()
        {
            switch (currentState)
            {
                case (VendingMachineState.Active):
                    ActiveState();
                    break;
                case (VendingMachineState.Select):
                    SelectState();
                    break;
                case (VendingMachineState.Vend):
                    VendState();
                    break;
            }
        }

        void ChangeState(Input newInput)
        {
            switch (newInput)
            {
                case (Input.AddQuarter):
                    currentState = VendingMachineState.Active;
                    break;
                case (Input.Select):
                    currentState = VendingMachineState.Select;
                    break;
                case (Input.Buy):
                    currentState = VendingMachineState.Vend;
                    break;
                case (Input.Cancel):
                    Transaction.Instance.ResetTransaction();
                    currentState = VendingMachineState.Active;
                    break;
            }
            DoState();
        }

        void GetOutput()
        {
            switch (currentOutput)
            {
                case (Output.Nothing):
                    break;
                case (Output.Gum):
                    Transaction.Instance.currentPrice -= Gum.Instance.Price;
                    Console.WriteLine("You bought some gum");
                    break;
                case (Output.Granola):
                    Transaction.Instance.currentPrice -= Granola.Instance.Price;
                    Console.WriteLine("You bought a granola bar");
                    break;
                case (Output.Quarter):
                    Transaction.Instance.currentPrice -= Quarter.Instance.Price;
                    Console.WriteLine("You got a quarter back");
                    break;
            }

            Console.WriteLine("Press enter to continue");
        }

        void ListItems()
        {
            Console.WriteLine("This machine has two items that you can purchase:");
            Console.WriteLine(Granola.Instance.Describe());
            Console.WriteLine(Gum.Instance.Describe());
        }

        string GetMenuInput()
        {
            Console.WriteLine("Enter the number corresponding to the action that you want to take:");
            Console.WriteLine($"You currently have ${Transaction.Instance.currentPrice} inside the machine");
            Console.WriteLine("1) Add a quarter\n2) Vend an item\n3) Cancel Purchase");
            string input = Console.ReadLine();

            if (input != "1" && input != "2" && input != "3")
            {
                Console.WriteLine("That is not a valid input, please try again");
                Console.ReadKey();
                Console.Clear();
            }

            return input;
        }

        string GetItemInput()
        {
            Console.WriteLine("Which item do you want?");
            Console.WriteLine("1) Gum\n2) Granola\n3) Cancel Purchase");
            string input = Console.ReadLine();

            if (input != "1" && input != "2" && input != "3")
            {
                Console.WriteLine("That is not a valid input, please try again");
                Console.ReadKey();
                Console.Clear();
            }

            return input;
        }
    }

    public enum VendingMachineState
    {
        Active,
        Select,
        Vend
    }

    public enum Input
    {
        AddQuarter,
        Select,
        Buy,
        Cancel
    }

    public enum Output
    {
        Nothing,
        Quarter,
        Granola,
        Gum
    }
}
