namespace Samples.Ch01 {
    using Microsoft.Build.Utilities;

    public class SayHello : Task {
        public override bool Execute() {
            Log.LogMessage("Hello using AnyCPU");
            return true;
        }
    }
}
