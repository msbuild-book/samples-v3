namespace Samples.Ch01.v2 {
    using Microsoft.Build.Utilities;

    public class PrintInfo : Task {
        public override bool Execute() {
            this.Log.LogMessage("Message from the CLR 2 version of the task");
            return true;
        }
    }
}
