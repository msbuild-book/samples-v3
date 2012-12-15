namespace Samples.Ch01.x86 {
    using Microsoft.Build.Utilities;

    public class PrintInfo : Task {
        public override bool Execute() {
            this.Log.LogMessage("Message from the x86 version of the task");
            return true;
        }
    }
}
