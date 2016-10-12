using System;

namespace KFUtil
{
    public struct Color
    {
        private double _r;

        private double _g;

        private double _b;

        private double _a;

        public double R
        {
            get
            {
                return this._r;
            }
            set
            {
                this._r = value;
            }
        }

        public double G
        {
            get
            {
                return _g;
            }
            set
            {
                this._g = value;
            }
        }

        public double B
        {
            get
            {
                return _b;
            }
            set
            {
                this._b = value;
            }
        }

        public double A
        {
            get
            {
                return _a;
            }
            set
            {
                this._a = value;
            }
        }

        public static Color Red
        {
            get
            {
                return new Color(1.0, 0.0, 0.0, 1.0);
            }
        }

        public static Color Green
        {
            get
            {
                return new Color(0.0, 1.0, 0.0, 1.0);
            }
        }

        public static Color Blue
        {
            get
            {
                return new Color(0.0, 0.0, 1.0, 1.0);
            }
        }

        public static Color Black
        {
            get
            {
                return new Color(0.0, 0.0, 0.0, 1.0);
            }
        }

        public static Color White
        {
            get
            {
                return new Color(1.0, 1.0, 1.0, 1.0);
            }
        }

        public static Color Yellow
        {
            get
            {
                return new Color(1.0, 1.0, 0.0, 1.0);
            }
        }

        public static Color Cyan
        {
            get
            {
                return new Color(0.0, 1.0, 1.0, 1.0);
            }
        }

        public static Color Magenta
        {
            get
            {
                return new Color(1.0, 0.0, 1.0, 1.0);
            }
        }

        public static Color Gray
        {
            get
            {
                return new Color(0.5, 0.5, 0.5, 1.0);
            }
        }

        public static Color Grey
        {
            get
            {
                return new Color(0.5, 0.5, 0.5, 1.0);
            }
        }

        public static Color Clear
        {
            get
            {
                return new Color(0.0, 0.0, 0.0, 0.0);
            }
        }

        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return this._r;
                    case 1:
                        return this._g;
                    case 2:
                        return this._b;
                    case 3:
                        return this._a;
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector3 index!");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        this._r = value;
                        break;
                    case 1:
                        this._g = value;
                        break;
                    case 2:
                        this._b = value;
                        break;
                    case 3:
                        this._a = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector3 index!");
                }
            }
        }

        public Color(double r, double g, double b, double a)
        {
            this._r = r;
            this._g = g;
            this._b = b;
            this._a = a;
        }

        public Color(double r, double g, double b)
        {
            this._r = r;
            this._g = g;
            this._b = b;
            this._a = 1.0;
        }

        public void Set(double new_r, double new_g, double new_b, double new_a)
        {
            this._r = new_r;
            this._g = new_g;
            this._b = new_b;
            this._a = new_a;
        }

        public override string ToString()
        {
            return String.Format("RGBA({0:F3}, {1:F3}, {2:F3}, {3:F3})", new object[]
            {
                this._r,
                this._g,
                this._b,
                this._a
            });
        }

        public string ToString(string format)
        {
            return String.Format("RGBA({0}, {1}, {2}, {3})", new object[]
            {
                this._r.ToString(format),
                this._g.ToString(format),
                this._b.ToString(format),
                this._a.ToString(format)
            });
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }

        public override bool Equals(object other)
        {
            if (!(other is Color))
            {
                return false;
            }
            Color color = (Color)other;
            return this._r.Equals(color.R) && this._g.Equals(color.G) && this._b.Equals(color.B) && this._a.Equals(color.A);
        }
    }
}
