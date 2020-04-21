namespace UltimateOrb {

    public partial interface INullableReference {

        bool IsNull();
    }


    public static partial class IsINullableReference<T> {

        public static readonly bool Value = GetValue();

        private static bool GetValue() {
            return  typeof(INullableReference).IsAssignableFrom(typeof(T));
        }
    }
}
