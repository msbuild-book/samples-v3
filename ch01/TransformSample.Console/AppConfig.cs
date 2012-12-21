namespace TransformSample.Console {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AppConfig {
        public AppConfig(AppConfigModel model) {
            if (model == null) { throw new ArgumentNullException("model"); }

            this.Model = model;
        }

        public AppConfig()
            : this(AppConfigModel.BuildFromCurrent()) {
        }

        private AppConfigModel Model {
            get;
            set;
        }

        public string GetAppSettingsAsText() {
            return this.BuildStringFrom(this.Model.AppSettings);
        }

        public string GetConnectionStringsAsText() {
            return this.BuildStringFrom(this.Model.ConnectionStrings);
        }

        private string BuildStringFrom(IDictionary<string, string> dictionary) {
            if (dictionary == null) { throw new ArgumentNullException("dictionary"); }

            StringBuilder sb = new StringBuilder();
            foreach (string key in dictionary.Keys) {
                sb.AppendFormat("\t{0} : {1}{2}", key, dictionary[key], Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
