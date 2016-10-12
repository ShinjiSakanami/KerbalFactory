using System;

namespace KFUtil
{
    public struct Vector2
    {
        private double _x;

        private double _y;

        public double X
        {
            get
            {
                return this._x;
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
                return this._y;
            }
            set
            {
                this._y = value;
            }
        }

        public double this[int index]
        {
            get
            {
                if (index == 0)
                {
                    return this._x;
                }
                if (index != 1)
                {
                    throw new IndexOutOfRangeException("Invalid Vector2 index!");
                }
                return this._y;
            }
            set
            {
                if (index != 0)
                {
                    if (index != 1)
                    {
                        throw new IndexOutOfRangeException("Invalid Vector2 index!");
                    }
                    this._y = value;
                }
                else
                {
                    this._x = value;
                }
            }
        }

        public static Vector2 Zero
        {
            get
            {
                return new Vector2(0.0, 0.0);
            }
        }

        public Vector2(double x, double y)
        {
            this._x = x;
            this._y = y;
        }

        public void Set(double new_x, double new_y)
        {
            this._x = new_x;
            this._y = new_y;
        }

        public override string ToString()
        {
            return String.Format("({0:F1}, {1:F1})", new object[]
            {
                this._x,
                this._y
            });
        }

        public string ToString(string format)
        {
            return String.Format("({0}, {1})", new object[]
            {
                this._x.ToString(format),
                this._y.ToString(format)
            });
        }

        public override int GetHashCode()
        {
            return this._x.GetHashCode() ^ this._y.GetHashCode() << 2;
        }

        public override bool Equals(object other)
        {
            if (!(other is Vector2))
            {
                return false;
            }
            Vector2 vector = (Vector2)other;
            return this._x.Equals(vector.X) && this._y.Equals(vector.Y);
        }
    }
}
