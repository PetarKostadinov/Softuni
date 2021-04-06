using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {

            IComponent component = this.components.FirstOrDefault(x => x.Id == id);

            if (component != null)
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }

            if (component == null)
            {
                throw new ArgumentException("Component type is invalid.");
            }

            IComputer computer = this.computers.FirstOrDefault(x => x.Id == computerId);

            ThrowExceptionIfComputerIsNull(computer);
            computer.AddComponent(component);
            this.components.Add(component);

            return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer comp = this.computers.FirstOrDefault(x => x.Id == id);

            if (comp != null)
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            if (computerType == "Laptop")
            {
                comp = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == "DesktopComputer")
            {
                comp = new DesktopComputer(id, manufacturer, model, price);
            }

            if (comp == null)
            {
                throw new ArgumentException("Computer type is invalid.");
            }
            if (this.computers.Contains(comp))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            this.computers.Add(comp);
            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IPeripheral peripheral = this.peripherals.FirstOrDefault(x => x.Id == id);

            if (peripheral != null)
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }
            else if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);

            }
            else if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);

            }
            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);

            }

            if (peripheral == null)
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }

            IComputer computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            ThrowExceptionIfComputerIsNull(computer);

            computer.AddPeripheral(peripheral);

            this.peripherals.Add(peripheral);
            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string BuyBest(decimal budget)
        {

            IComputer computer = this.computers.Where(x => x.Price <= budget).OrderByDescending(x => x.OverallPerformance).FirstOrDefault();

            if (computer == null)
            {
                throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
            }

            this.computers.Remove(computer);
            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            IComputer computer = this.computers.FirstOrDefault(x => x.Id == id);

            ThrowExceptionIfComputerIsNull(computer);

            this.computers.Remove(computer);
            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            IComputer computer = this.computers.FirstOrDefault(x => x.Id == id);

            ThrowExceptionIfComputerIsNull(computer);

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComponent component = this.components.FirstOrDefault(x => x.GetType().Name == componentType);
            IComputer computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            ThrowExceptionIfComputerIsNull(computer);

            computer.RemoveComponent(componentType);

            //this.components.Remove(component);  not necessary

            return $"Successfully removed {componentType} with id {component.Id}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IPeripheral peripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            IComputer computer = this.computers.FirstOrDefault(x => x.Id == computerId);

            ThrowExceptionIfComputerIsNull(computer);
            computer.RemovePeripheral(peripheralType);

           // this.peripherals.Remove(peripheral); not necessary

            return $"Successfully removed {peripheralType} with id {peripheral.Id}.";
        }

        private static void ThrowExceptionIfComputerIsNull(IComputer computer)
        {
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
        }

    }
}
