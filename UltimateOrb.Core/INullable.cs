namespace UltimateOrb {

    public partial interface INullable {

        bool HasValue {

            get;
        }
    }

    public partial interface INullable<T> : INullable {

        T Value {

            get;
        }

        T GetValueOrDefault();

        T GetValueOrDefault(T defaultValue);
    }
}
