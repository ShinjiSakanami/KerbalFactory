using System;

namespace KFUtil
{
    public struct Vector3
    {
        private double _x;

        private double _y;

        private double _z;

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
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector3 index!");
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
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector3 index!");
                }
            }
        }

        public static Vector3 Zero
        {
            get
            {
                return new Vector3(0.0, 0.0, 0.0);
            }
        }

        public Vector3(double x, double y, double z)
        {
            this._x = x;
            this._y = y;
            this._z = z;
        }

        public Vector3(double x, double y)
        {
            this._x = x;
            this._y = y;
            this._z = 0.0;
        }

        public void Set(double new_x, double new_y, double new_z)
        {
            this._x = new_x;
            this._y = new_y;
            this._z = new_z;
        }

        public override string ToString()
        {
            return String.Format("({0:F1}, {1:F1}, {2:F1})", new object[]
            {
                this._x,
                this._y,
                this._z
            });
        }

        public string ToString(string format)
        {
            return String.Format("({0}, {1}, {2})", new object[]
            {
                this._x.ToString(format),
                this._y.ToString(format),
                this._z.ToString(format)
            });
        }

        public override int GetHashCode()
        {
            return this._x.GetHashCode() ^ this._y.GetHashCode() << 2 ^ this._z.GetHashCode() >> 2;
        }

        public override bool Equals(object other)
        {
            if (!(other is Vector3))
            {
                return false;
            }
            Vector3 vector = (Vector3)other;
            return this._x.Equals(vector.X) && this._y.Equals(vector.Y) && this._z.Equals(vector.Z);
        }
    }
}
