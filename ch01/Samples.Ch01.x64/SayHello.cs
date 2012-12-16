namespace Samples.Ch01.x64 {
    using Microsoft.Build.Utilities;

    public class SayHello : Task {
        public override bool Execute() {
            Log.LogMessage("Hello using x64");
            return true;
        }
    }
}
