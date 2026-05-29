namespace BazisGUI.Scripting.Variable
{
    public class IntValue : ScriptValue
    {
        public int Value { get; set; }

        public override string ToString() => Value.ToString();
    }
}
