namespace Samples.Ch01.x64 {
    using Microsoft.Build.Utilities;

    public class PrintInfo : Task {

        public string Bitness {
            get {
                if (System.IntPtr.Size == 8) {
                    return "64 bit";
                }

                return "32 bit";
            }
        }

        public string ClrVersion {
            get {
                return System.Environment.Version.ToString();
            }
        }


        public override bool Execute() {
            this.Log.LogMessage(".NET CLR version: {0}\tBitness: {1}", this.ClrVersion, this.Bitness);
            return true;
        }
    }
}
