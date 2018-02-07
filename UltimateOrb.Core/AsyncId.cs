using System.Threading;

namespace UltimateOrb {

    public static partial class AsyncId {

        private static readonly AsyncLocal<object> s_Value = new AsyncLocal<object>();

        public static object Value {

            get {
                var a = s_Value;
                var id = a.Value;
                if (null == id) {
                    id = new object();
                    a.Value = id;
                }
                return id;
            }
        }
    }
}
