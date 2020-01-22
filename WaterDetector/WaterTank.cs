using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WaterDetector
{
    class WaterTank
    {
        private int _value = 0;

        public WaterTank(int capacity, string name)
        {
            Capacity = capacity;
            Name = name;
            Reset();
        }

        public int Capacity { get; }
        public string Name { get; }
        public int CurrentValue { 
            get 
            { 
                return _value; 
            }
            set 
            {
                _value = value;
                ValueHasChanged?.Invoke(this, new ExampleEventArgs(value));
            }
        }
        public void Reset()
        {
            CurrentValue = 0;
        }

        public void Add(int value)
        {
            CurrentValue += value;
        }

        public event ExampleEventHandler ValueHasChanged;
    }


    public delegate void ExampleEventHandler(object sender, ExampleEventArgs e);

    public class ExampleEventArgs
    {
        public ExampleEventArgs(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
    }

    class EvenSubscriber
    {
            
        public void OnValueChanged(object sender, ExampleEventArgs e)
        {          
            Console.WriteLine(sender.ToString() + " value is now " + e.Value);
        }
    }
}
