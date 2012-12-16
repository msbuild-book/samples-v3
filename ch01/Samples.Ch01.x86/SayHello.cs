namespace Samples.Ch01.x86 {
    using Microsoft.Build.Utilities;
    
    public class SayHello : Task {
        public override bool Execute() {
            Log.LogMessage("Hello using x86");
            return true;
        }
    }
}
