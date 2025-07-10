using System.Windows;

namespace Example_01
{
    class Person : DependencyObject
    {
        public static readonly DependencyProperty AgeProperty;

        private string name;
        

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Age
        {
            get => (int)GetValue(AgeProperty);
            set => SetValue(AgeProperty, value);
        }

        static Person()
        {
            AgeProperty=DependencyProperty.Register(
                nameof(Age),
                typeof(int),
                typeof(Person),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure|
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CourceAge)),
                new ValidateValueCallback(ValidateAge)
                );
        }

        private static bool ValidateAge(object value)
        {
            int v = (int) value;
            return (v >= 0 && v <= 200);
        }

        private static object CourceAge(DependencyObject d, object basevalue)
        {
            int v = (int)basevalue;
            if (v < 0)
                return 0;
            return v;
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Print()
        {
            return $"{Name} {Age}";
        }
    }
}
