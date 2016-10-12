using System;

namespace KFUtil
{
    public struct Quaternion
    {
        private double _x;

        private double _y;

        private double _z;

        private double _w;

        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                this._x = value;
            }
        }

        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                this._y = value;
            }
        }

        public double Z
        {
            get
            {
                return _z;
            }
            set
            {
                this._z = value;
            }
        }

        public double W
        {
            get
            {
                return _w;
            }
            set
            {
                this._w = value;
            }
        }

        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return this._x;
                    case 1:
                        return this._y;
                    case 2:
                        return this._z;
                    case 3:
                        return this._w;
                    default:
                        throw new IndexOutOfRangeException("Invalid Quaternion index!");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        this._x = value;
                        break;
                    case 1:
                        this._y = value;
                        break;
                    case 2:
                        this._z = value;
                        break;
                    case 3:
                        this._w = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Invalid Quaternion index!");
                }
            }
        }

        public static Quaternion Identity
        {
            get
            {
                return new Quaternion(0.0, 0.0, 0.0, 1.0);
            }
        }

        public Quaternion(double x, double y, double z, double w)
        {
            this._x = x;
            this._y = y;
            this._z = z;
            this._w = w;
        }

        public void Set(double new_x, double new_y, double new_z, double new_w)
        {
            this._x = new_x;
            this._y = new_y;
            this._z = new_z;
            this._w = new_w;
        }

        public override string ToString()
        {
            return String.Format("({0:F1}, {1:F1}, {2:F1}, {3:F1})", new object[]
            {
                this._x,
                this._y,
                this._z,
                this._w
            });
        }

        public string ToString(string format)
        {
            return String.Format("({0}, {1}, {2}, {3})", new object[]
            {
                this._x.ToString(format),
                this._y.ToString(format),
                this._z.ToString(format),
                this._w.ToString(format)
            });
        }

        public override int GetHashCode()
        {
            return this._x.GetHashCode() ^ this._y.GetHashCode() << 2 ^ this._z.GetHashCode() >> 2 ^ this._w.GetHashCode() >> 1;
        }

        public override bool Equals(object other)
        {
            if (!(other is Quaternion))
            {
                return false;
            }
            Quaternion quaternion = (Quaternion)other;
            return this._x.Equals(quaternion.X) && this._y.Equals(quaternion.Y) && this._z.Equals(quaternion.Z) && this._w.Equals(quaternion.W);
        }
    }
}
