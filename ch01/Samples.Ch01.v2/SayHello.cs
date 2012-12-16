namespace Samples.Ch01.v2 {
    using Microsoft.Build.Utilities;

    public class SayHello : Task {
        public override bool Execute() {
            Log.LogMessage("Hello using .NET CLR 2");
            return true;
        }
    }
}
