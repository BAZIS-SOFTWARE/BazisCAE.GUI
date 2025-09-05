namespace BaseModule.PropertiesPanel.DataGridViewNumericUpDown
{
    public class NumericUpDownConfig
    {
        public decimal Value { get; set; }
        public decimal Minimum { get; set; }
        public decimal Maximum { get; set; }

        public int DecimalPlaces { get; set; } = 0;
        public decimal Increment { get; set; } = 1;

        public NumericUpDownConfig(decimal value, decimal minimum, decimal maximum, int decimalPlaces, decimal increment)
        {
            DecimalPlaces = decimalPlaces;
            Increment = increment;
            Minimum = minimum;
            Maximum = maximum;
            Value = value;
        }
    }
}
