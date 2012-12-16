namespace Samples.Ch01.v4 {
using Microsoft.Build.Utilities;

public class SayHello : Task {
    public override bool Execute() {
        Log.LogMessage("Hello using .NET CLR 4");
        return true;
    }
}
}
