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
        private List<IPeripheral> peripherals;
        private List<IComponent> components;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.peripherals = new List<IPeripheral>();  
            this.components = new List<IComponent>();
        }
        public override double OverallPerformance => this.Components.Count == 0 ? base.OverallPerformance : base.OverallPerformance + this.Components.Average(x => x.OverallPerformance);

        public override decimal Price => base.Price + this.Components.Sum(x => x.Price)
             + this.Peripherals.Sum(x => x.Price);
        public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();
       
           

        public void AddComponent(IComponent component)
        {
            if (this.components.Any(x => x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
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
            IPeripheral element = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            if (this.peripherals.Count == 0 || element == null)
            {
                throw new ArgumentException($"Peripheral {peripheralType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            this.peripherals.Remove(element);
            return element;
        }
        public override string ToString()
        {
            double peripheralsAverage = this.Peripherals.Count > 0 ? this.Peripherals.Average(x => x.OverallPerformance) : 0;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($" Components ({this.components.Count}):");
            foreach (var componenet in this.components)
            {
                sb.AppendLine($"  {componenet}");
            }

            sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({peripheralsAverage:f2}):");
            foreach (var peripheral in this.peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return base.ToString() + $"\n{sb.ToString().TrimEnd()}";
        }
    }
}
