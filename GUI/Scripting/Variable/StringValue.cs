namespace BazisGUI.Scripting.Variable
{
    public class StringValue : ScriptValue
    {
        public string Value { get; set; }

        public override string ToString() => Value;
    }
}
