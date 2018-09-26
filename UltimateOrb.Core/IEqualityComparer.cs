using System.Collections.Generic;

namespace UltimateOrb.Huge.Collections.Generic {

    public interface IEqualityComparer<in T>
        : System.Collections.Generic.IEqualityComparer<T> {

        long GetLongHashCode(T obj);
    }



    public static class EqualityComparerModule {

        private static EqualityComparer<T> CreateDefault<T>() {
            throw new System.NotImplementedException();
        }
    }


    public struct EqualityComparer<T> : IEqualityComparer<T> {


        public static readonly EqualityComparer<T> Default = default;

        private static bool Equals(T x, T y) {
            return Equals(x, y);
        }

        private static int GetHashCode(T obj) {
            return obj.GetHashCode();
        }

        private static long GetLongHashCode(T obj) {
            if (typeof(long) == typeof(T)) {
                return (long) (object) obj;
            } else if (typeof(ulong) == typeof(T)) {
                return (long) (ulong) (object) obj;
            }
            // TODO: ...
            return GetHashCode(obj);
        }

        bool System.Collections.Generic.IEqualityComparer<T>.Equals(T x, T y) {
            return Equals(x, y);
        }

        int System.Collections.Generic.IEqualityComparer<T>.GetHashCode(T obj) {
            return GetHashCode(obj);
        }

        long IEqualityComparer<T>.GetLongHashCode(T obj) {
            return GetLongHashCode(obj);
        }
    }
}
