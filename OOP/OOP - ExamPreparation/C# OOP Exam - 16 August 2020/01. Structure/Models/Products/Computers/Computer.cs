using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();  
        }

        public IReadOnlyCollection<IComponent> Components => (IReadOnlyCollection<IComponent>)this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals => (IReadOnlyCollection<IPeripheral>)this.peripherals;
        public override double OverallPerformance => this.Components.Count == 0 ? this.OverallPerformance : this.OverallPerformance + this.Components.Average(x => x.OverallPerformance);
       
        public override decimal Price => this.Price
            + this.Components.Sum(x => x.Price)
             + this.Peripherals.Sum(x => x.Price);

        public void AddComponent(IComponent component)
        {
            if (this.components.Contains(component))
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Contains(peripheral))
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var element = this.components.FirstOrDefault(x => x.GetType().Name == componentType);

            if (element == null || this.components.Count == 0)
            {
                throw new ArgumentException($"Component {componentType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            this.components.Remove(element);
            return element;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var element = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            if (this.peripherals.Count == 0 || element == null)
            {
                throw new ArgumentException($"Peripheral {peripheralType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            this.peripherals.Remove(element);
            return element;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Overall Performance: {this.OverallPerformance}. Price: {this.Price} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})");
            sb.AppendLine($" Components ({components.Count}):");

            foreach (var component in this.Components)
            {
                sb.AppendLine($"{component}");
            }

            sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({this.Peripherals.Average(x => x.OverallPerformance)}):");

            foreach (var peripheral in this.Peripherals)
            {
                sb.AppendLine($"{peripheral}");
            }

            return sb.ToString().TrimEnd().TrimStart();
        }
    }
}
