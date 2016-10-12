using System;

namespace KFUtil
{
    public struct Matrix4x4
    {
        private double _m00;

        private double _m10;

        private double _m20;

        private double _m30;

        private double _m01;

        private double _m11;

        private double _m21;

        private double _m31;

        private double _m02;

        private double _m12;

        private double _m22;

        private double _m32;

        private double _m03;

        private double _m13;

        private double _m23;

        private double _m33;

        public double M00
        {
            get
            {
                return _m00;
            }
            set
            {
                this._m00 = value;
            }
        }

        public double M10
        {
            get
            {
                return _m10;
            }
            set
            {
                this._m10 = value;
            }
        }

        public double M20
        {
            get
            {
                return _m20;
            }
            set
            {
                this._m20 = value;
            }
        }

        public double M30
        {
            get
            {
                return _m30;
            }
            set
            {
                this._m30 = value;
            }
        }

        public double M01
        {
            get
            {
                return _m01;
            }
            set
            {
                this._m01 = value;
            }
        }

        public double M11
        {
            get
            {
                return _m11;
            }
            set
            {
                this._m11 = value;
            }
        }

        public double M21
        {
            get
            {
                return _m21;
            }
            set
            {
                this._m21 = value;
            }
        }

        public double M31
        {
            get
            {
                return _m31;
            }
            set
            {
                this._m31 = value;
            }
        }

        public double M02
        {
            get
            {
                return _m02;
            }
            set
            {
                this._m02 = value;
            }
        }

        public double M12
        {
            get
            {
                return _m12;
            }
            set
            {
                this._m12 = value;
            }
        }

        public double M22
        {
            get
            {
                return _m22;
            }
            set
            {
                this._m22 = value;
            }
        }

        public double M32
        {
            get
            {
                return _m32;
            }
            set
            {
                this._m32 = value;
            }
        }

        public double M03
        {
            get
            {
                return _m03;
            }
            set
            {
                this._m03 = value;
            }
        }

        public double M13
        {
            get
            {
                return _m13;
            }
            set
            {
                this._m13 = value;
            }
        }

        public double M23
        {
            get
            {
                return _m23;
            }
            set
            {
                this._m23 = value;
            }
        }

        public double M33
        {
            get
            {
                return _m33;
            }
            set
            {
                this._m33 = value;
            }
        }

        public double this[int row, int column]
        {
            get
            {
                return this[row + column * 4];
            }
            set
            {
                this[row + column * 4] = value;
            }
        }

        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return this._m00;
                    case 1:
                        return this._m10;
                    case 2:
                        return this._m20;
                    case 3:
                        return this._m30;
                    case 4:
                        return this._m01;
                    case 5:
                        return this._m11;
                    case 6:
                        return this._m21;
                    case 7:
                        return this._m31;
                    case 8:
                        return this._m02;
                    case 9:
                        return this._m12;
                    case 10:
                        return this._m22;
                    case 11:
                        return this._m32;
                    case 12:
                        return this._m03;
                    case 13:
                        return this._m13;
                    case 14:
                        return this._m23;
                    case 15:
                        return this._m33;
                    default:
                        throw new IndexOutOfRangeException("Invalid matrix index!");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        this._m00 = value;
                        break;
                    case 1:
                        this._m10 = value;
                        break;
                    case 2:
                        this._m20 = value;
                        break;
                    case 3:
                        this._m30 = value;
                        break;
                    case 4:
                        this._m01 = value;
                        break;
                    case 5:
                        this._m11 = value;
                        break;
                    case 6:
                        this._m21 = value;
                        break;
                    case 7:
                        this._m31 = value;
                        break;
                    case 8:
                        this._m02 = value;
                        break;
                    case 9:
                        this._m12 = value;
                        break;
                    case 10:
                        this._m22 = value;
                        break;
                    case 11:
                        this._m32 = value;
                        break;
                    case 12:
                        this._m03 = value;
                        break;
                    case 13:
                        this._m13 = value;
                        break;
                    case 14:
                        this._m23 = value;
                        break;
                    case 15:
                        this._m33 = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Invalid matrix index!");
                }
            }
        }

        public static Matrix4x4 Zero
        {
            get
            {
                return new Matrix4x4
                {
                    M00 = 0.0,
                    M01 = 0.0,
                    M02 = 0.0,
                    M03 = 0.0,
                    M10 = 0.0,
                    M11 = 0.0,
                    M12 = 0.0,
                    M13 = 0.0,
                    M20 = 0.0,
                    M21 = 0.0,
                    M22 = 0.0,
                    M23 = 0.0,
                    M30 = 0.0,
                    M31 = 0.0,
                    M32 = 0.0,
                    M33 = 0.0
                };
            }
        }

        public static Matrix4x4 Identity
        {
            get
            {
                return new Matrix4x4
                {
                    M00 = 1.0,
                    M01 = 0.0,
                    M02 = 0.0,
                    M03 = 0.0,
                    M10 = 0.0,
                    M11 = 1.0,
                    M12 = 0.0,
                    M13 = 0.0,
                    M20 = 0.0,
                    M21 = 0.0,
                    M22 = 1.0,
                    M23 = 0.0,
                    M30 = 0.0,
                    M31 = 0.0,
                    M32 = 0.0,
                    M33 = 1.0
                };
            }
        }

        public Vector4 GetColumn(int i)
        {
            return new Vector4(this[0, i], this[1, i], this[2, i], this[3, i]);
        }

        public Vector4 GetRow(int i)
        {
            return new Vector4(this[i, 0], this[i, 1], this[i, 2], this[i, 3]);
        }

        public void SetColumn(int i, Vector4 v)
        {
            this[0, i] = v.X;
            this[1, i] = v.Y;
            this[2, i] = v.Z;
            this[3, i] = v.W;
        }

        public void SetRow(int i, Vector4 v)
        {
            this[i, 0] = v.X;
            this[i, 1] = v.Y;
            this[i, 2] = v.Z;
            this[i, 3] = v.W;
        }

        public override string ToString()
        {
            return String.Format("{0:F5}\t{1:F5}\t{2:F5}\t{3:F5}\n{4:F5}\t{5:F5}\t{6:F5}\t{7:F5}\n{8:F5}\t{9:F5}\t{10:F5}\t{11:F5}\n{12:F5}\t{13:F5}\t{14:F5}\t{15:F5}\n", new object[]
            {
                this._m00,
                this._m01,
                this._m02,
                this._m03,
                this._m10,
                this._m11,
                this._m12,
                this._m13,
                this._m20,
                this._m21,
                this._m22,
                this._m23,
                this._m30,
                this._m31,
                this._m32,
                this._m33
            });
        }

        public string ToString(string format)
        {
            return String.Format("{0}\t{1}\t{2}\t{3}\n{4}\t{5}\t{6}\t{7}\n{8}\t{9}\t{10}\t{11}\n{12}\t{13}\t{14}\t{15}\n", new object[]
            {
                this._m00.ToString(format),
                this._m01.ToString(format),
                this._m02.ToString(format),
                this._m03.ToString(format),
                this._m10.ToString(format),
                this._m11.ToString(format),
                this._m12.ToString(format),
                this._m13.ToString(format),
                this._m20.ToString(format),
                this._m21.ToString(format),
                this._m22.ToString(format),
                this._m23.ToString(format),
                this._m30.ToString(format),
                this._m31.ToString(format),
                this._m32.ToString(format),
                this._m33.ToString(format)
            });
        }

        public override int GetHashCode()
        {
            return this.GetColumn(0).GetHashCode() ^ this.GetColumn(1).GetHashCode() << 2 ^ this.GetColumn(2).GetHashCode() >> 2 ^ this.GetColumn(3).GetHashCode() >> 1;
        }

        public override bool Equals(object other)
        {
            if (!(other is Matrix4x4))
            {
                return false;
            }
            Matrix4x4 matrix4x = (Matrix4x4)other;
            return this.GetColumn(0).Equals(matrix4x.GetColumn(0)) && this.GetColumn(1).Equals(matrix4x.GetColumn(1)) && this.GetColumn(2).Equals(matrix4x.GetColumn(2)) && this.GetColumn(3).Equals(matrix4x.GetColumn(3));
        }
    }
}
