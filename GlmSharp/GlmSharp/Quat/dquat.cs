using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Linq;
using GlmSharp.Swizzle;

// ReSharper disable InconsistentNaming

namespace GlmSharp
{
    
    /// <summary>
    /// A quaternion of type double.
    /// </summary>
    [Serializable]
    [DataContract]
    [StructLayout(LayoutKind.Sequential)]
    public struct dquat : IReadOnlyList<double>, IEquatable<dquat>
    {

        #region Fields
        
        /// <summary>
        /// x-component
        /// </summary>
        [DataMember]
        public double x;
        
        /// <summary>
        /// y-component
        /// </summary>
        [DataMember]
        public double y;
        
        /// <summary>
        /// z-component
        /// </summary>
        [DataMember]
        public double z;
        
        /// <summary>
        /// w-component
        /// </summary>
        [DataMember]
        public double w;

        #endregion


        #region Constructors
        
        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public dquat(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        
        /// <summary>
        /// all-same-value constructor
        /// </summary>
        public dquat(double v)
        {
            this.x = v;
            this.y = v;
            this.z = v;
            this.w = v;
        }
        
        /// <summary>
        /// vector-and-scalar constructor
        /// </summary>
        public dquat(dvec3 v, double s)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = s;
        }
        
        /// <summary>
        /// Create a quaternion from two normalized axis (http://lolengine.net/blog/2013/09/18/beautiful-maths-quaternion-from-vectors)
        /// </summary>
        public dquat(dvec3 u, dvec3 v)
        {
            var localW = dvec3.Cross(u, v);
            var dot = dvec3.Dot(u, v);
            var q = new dquat(localW.x, localW.y, localW.z, 1.0 + dot).Normalized;
            this.x = q.x;
            this.y = q.y;
            this.z = q.z;
            this.w = q.w;
        }
        
        /// <summary>
        /// Create a quaternion from two normalized axis (http://lolengine.net/blog/2013/09/18/beautiful-maths-quaternion-from-vectors)
        /// </summary>
        public dquat(dvec3 eulerAngle)
        {
            var c = dvec3.Cos(eulerAngle / 2);
            var s = dvec3.Sin(eulerAngle / 2);
            this.x = s.x * c.y * c.z - c.x * s.y * s.z;
            this.y = c.x * s.y * c.z + s.x * c.y * s.z;
            this.z = c.x * c.y * s.z - s.x * s.y * c.z;
            this.w = c.x * c.y * c.z + s.x * s.y * s.z;
        }

        #endregion


        #region Implicit Operators
        
        /// <summary>
        /// Implicitly converts this to a cquat.
        /// </summary>
        public static implicit operator cquat(dquat v) => new cquat((Complex)v.x, (Complex)v.y, (Complex)v.z, (Complex)v.w);

        #endregion


        #region Explicit Operators
        
        /// <summary>
        /// Explicitly converts this to a ivec4.
        /// </summary>
        public static explicit operator ivec4(dquat v) => new ivec4((int)v.x, (int)v.y, (int)v.z, (int)v.w);
        
        /// <summary>
        /// Explicitly converts this to a iquat.
        /// </summary>
        public static explicit operator iquat(dquat v) => new iquat((int)v.x, (int)v.y, (int)v.z, (int)v.w);
        
        /// <summary>
        /// Explicitly converts this to a uvec4.
        /// </summary>
        public static explicit operator uvec4(dquat v) => new uvec4((uint)v.x, (uint)v.y, (uint)v.z, (uint)v.w);
        
        /// <summary>
        /// Explicitly converts this to a uquat.
        /// </summary>
        public static explicit operator uquat(dquat v) => new uquat((uint)v.x, (uint)v.y, (uint)v.z, (uint)v.w);
        
        /// <summary>
        /// Explicitly converts this to a vec4.
        /// </summary>
        public static explicit operator vec4(dquat v) => new vec4((float)v.x, (float)v.y, (float)v.z, (float)v.w);
        
        /// <summary>
        /// Explicitly converts this to a quat.
        /// </summary>
        public static explicit operator quat(dquat v) => new quat((float)v.x, (float)v.y, (float)v.z, (float)v.w);
        
        /// <summary>
        /// Explicitly converts this to a dvec4.
        /// </summary>
        public static explicit operator dvec4(dquat v) => new dvec4((double)v.x, (double)v.y, (double)v.z, (double)v.w);
        
        /// <summary>
        /// Explicitly converts this to a decvec4.
        /// </summary>
        public static explicit operator decvec4(dquat v) => new decvec4((decimal)v.x, (decimal)v.y, (decimal)v.z, (decimal)v.w);
        
        /// <summary>
        /// Explicitly converts this to a decquat.
        /// </summary>
        public static explicit operator decquat(dquat v) => new decquat((decimal)v.x, (decimal)v.y, (decimal)v.z, (decimal)v.w);
        
        /// <summary>
        /// Explicitly converts this to a cvec4.
        /// </summary>
        public static explicit operator cvec4(dquat v) => new cvec4((Complex)v.x, (Complex)v.y, (Complex)v.z, (Complex)v.w);
        
        /// <summary>
        /// Explicitly converts this to a lvec4.
        /// </summary>
        public static explicit operator lvec4(dquat v) => new lvec4((long)v.x, (long)v.y, (long)v.z, (long)v.w);
        
        /// <summary>
        /// Explicitly converts this to a lquat.
        /// </summary>
        public static explicit operator lquat(dquat v) => new lquat((long)v.x, (long)v.y, (long)v.z, (long)v.w);
        
        /// <summary>
        /// Explicitly converts this to a bvec4.
        /// </summary>
        public static explicit operator bvec4(dquat v) => new bvec4(v.x != 0.0, v.y != 0.0, v.z != 0.0, v.w != 0.0);
        
        /// <summary>
        /// Explicitly converts this to a bquat.
        /// </summary>
        public static explicit operator bquat(dquat v) => new bquat(v.x != 0.0, v.y != 0.0, v.z != 0.0, v.w != 0.0);

        #endregion


        #region Indexer
        
        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;
                    case 3: return w;
                    default: throw new ArgumentOutOfRangeException("index");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    case 2: z = value; break;
                    case 3: w = value; break;
                    default: throw new ArgumentOutOfRangeException("index");
                }
            }
        }

        #endregion


        #region Properties
        
        /// <summary>
        /// Returns an array with all values
        /// </summary>
        public double[] Values => new[] { x, y, z, w };
        
        /// <summary>
        /// Returns the number of components (4).
        /// </summary>
        public int Count => 4;
        
        /// <summary>
        /// Returns the euclidean length of this quaternion.
        /// </summary>
        public double Length => (double)Math.Sqrt(((x*x + y*y) + (z*z + w*w)));
        
        /// <summary>
        /// Returns the squared euclidean length of this quaternion.
        /// </summary>
        public double LengthSqr => ((x*x + y*y) + (z*z + w*w));
        
        /// <summary>
        /// Returns a copy of this quaternion with length one (undefined if this has zero length).
        /// </summary>
        public dquat Normalized => this / Length;
        
        /// <summary>
        /// Returns a copy of this quaternion with length one (returns zero if length is zero).
        /// </summary>
        public dquat NormalizedSafe => this == Zero ? Identity : this / Length;
        
        /// <summary>
        /// Returns the represented angle of this quaternion
        /// </summary>
        public double Angle => Math.Acos((double)w) * 2.0;
        
        /// <summary>
        /// Returns the represented axis of this quaternion
        /// </summary>
        public dvec3 Axis
        {
            get
            {
                var s1 = 1 - w * w;
                if (s1 < 0) return dvec3.UnitZ;
                var s2 = 1 / Math.Sqrt(s1);
                return new dvec3((double)(x * s2), (double)(y * s2), (double)(z * s2));
            }
        }
        
        /// <summary>
        /// Returns the represented yaw angle of this quaternion
        /// </summary>
        public double Yaw => Math.Asin(-2.0 * (double)(x * z - w * y));
        
        /// <summary>
        /// Returns the represented pitch angle of this quaternion
        /// </summary>
        public double Pitch => Math.Atan2(2.0 * (double)(y * z + w * x), (double)(w * w - x * x - y * y + z * z));
        
        /// <summary>
        /// Returns the represented roll angle of this quaternion
        /// </summary>
        public double Roll => Math.Atan2(2.0 * (double)(x * y + w * z), (double)(w * w + x * x - y * y - z * z));
        
        /// <summary>
        /// Returns the represented euler angles (pitch, yaw, roll) of this quaternion
        /// </summary>
        public dvec3 EulerAngles => new dvec3(Pitch, Yaw, Roll);
        
        /// <summary>
        /// Returns the conjugated quaternion
        /// </summary>
        public dquat Conjugate => new dquat(-x, -y, -z, w);
        
        /// <summary>
        /// Returns the inverse quaternion
        /// </summary>
        public dquat Inverse => Conjugate / LengthSqr;

        #endregion


        #region Static Properties
        
        /// <summary>
        /// Predefined all-zero quaternion
        /// </summary>
        public static dquat Zero { get; } = new dquat(0.0, 0.0, 0.0, 0.0);
        
        /// <summary>
        /// Predefined all-ones quaternion
        /// </summary>
        public static dquat Ones { get; } = new dquat(1.0, 1.0, 1.0, 1.0);
        
        /// <summary>
        /// Predefined identity quaternion
        /// </summary>
        public static dquat Identity { get; } = new dquat(0.0, 0.0, 0.0, 1.0);
        
        /// <summary>
        /// Predefined unit-X quaternion
        /// </summary>
        public static dquat UnitX { get; } = new dquat(1.0, 0.0, 0.0, 0.0);
        
        /// <summary>
        /// Predefined unit-Y quaternion
        /// </summary>
        public static dquat UnitY { get; } = new dquat(0.0, 1.0, 0.0, 0.0);
        
        /// <summary>
        /// Predefined unit-Z quaternion
        /// </summary>
        public static dquat UnitZ { get; } = new dquat(0.0, 0.0, 1.0, 0.0);
        
        /// <summary>
        /// Predefined unit-W quaternion
        /// </summary>
        public static dquat UnitW { get; } = new dquat(0.0, 0.0, 0.0, 1.0);
        
        /// <summary>
        /// Predefined all-MaxValue quaternion
        /// </summary>
        public static dquat MaxValue { get; } = new dquat(double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue);
        
        /// <summary>
        /// Predefined all-MinValue quaternion
        /// </summary>
        public static dquat MinValue { get; } = new dquat(double.MinValue, double.MinValue, double.MinValue, double.MinValue);
        
        /// <summary>
        /// Predefined all-Epsilon quaternion
        /// </summary>
        public static dquat Epsilon { get; } = new dquat(double.Epsilon, double.Epsilon, double.Epsilon, double.Epsilon);
        
        /// <summary>
        /// Predefined all-NaN quaternion
        /// </summary>
        public static dquat NaN { get; } = new dquat(double.NaN, double.NaN, double.NaN, double.NaN);
        
        /// <summary>
        /// Predefined all-NegativeInfinity quaternion
        /// </summary>
        public static dquat NegativeInfinity { get; } = new dquat(double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity);
        
        /// <summary>
        /// Predefined all-PositiveInfinity quaternion
        /// </summary>
        public static dquat PositiveInfinity { get; } = new dquat(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity);

        #endregion


        #region Operators
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool operator==(dquat lhs, dquat rhs) => lhs.Equals(rhs);
        
        /// <summary>
        /// Returns true iff this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator!=(dquat lhs, dquat rhs) => !lhs.Equals(rhs);

        #endregion


        #region Functions
        
        /// <summary>
        /// Returns an enumerator that iterates through all components.
        /// </summary>
        public IEnumerator<double> GetEnumerator()
        {
            yield return x;
            yield return y;
            yield return z;
            yield return w;
        }
        
        /// <summary>
        /// Returns an enumerator that iterates through all components.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
        /// <summary>
        /// Returns a string representation of this quaternion using ', ' as a seperator.
        /// </summary>
        public override string ToString() => ToString(", ");
        
        /// <summary>
        /// Returns a string representation of this quaternion using a provided seperator.
        /// </summary>
        public string ToString(string sep) => ((x + sep + y) + sep + (z + sep + w));
        
        /// <summary>
        /// Returns a string representation of this quaternion using a provided seperator and a format provider for each component.
        /// </summary>
        public string ToString(string sep, IFormatProvider provider) => ((x.ToString(provider) + sep + y.ToString(provider)) + sep + (z.ToString(provider) + sep + w.ToString(provider)));
        
        /// <summary>
        /// Returns a string representation of this quaternion using a provided seperator and a format for each component.
        /// </summary>
        public string ToString(string sep, string format) => ((x.ToString(format) + sep + y.ToString(format)) + sep + (z.ToString(format) + sep + w.ToString(format)));
        
        /// <summary>
        /// Returns a string representation of this quaternion using a provided seperator and a format and format provider for each component.
        /// </summary>
        public string ToString(string sep, string format, IFormatProvider provider) => ((x.ToString(format, provider) + sep + y.ToString(format, provider)) + sep + (z.ToString(format, provider) + sep + w.ToString(format, provider)));
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public bool Equals(dquat rhs) => ((x.Equals(rhs.x) && y.Equals(rhs.y)) && (z.Equals(rhs.z) && w.Equals(rhs.w)));
        
        /// <summary>
        /// Returns true iff this equals rhs type- and component-wise.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is dquat && Equals((dquat) obj);
        }
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((((((x.GetHashCode()) * 397) ^ y.GetHashCode()) * 397) ^ z.GetHashCode()) * 397) ^ w.GetHashCode();
            }
        }

        #endregion


        #region Static Functions
        
        /// <summary>
        /// Converts the string representation of the quaternion into a quaternion representation (using ', ' as a separator).
        /// </summary>
        public static dquat Parse(string s) => Parse(s, ", ");
        
        /// <summary>
        /// Converts the string representation of the quaternion into a quaternion representation (using a designated separator).
        /// </summary>
        public static dquat Parse(string s, string sep)
        {
            var kvp = s.Split(new[] { sep }, StringSplitOptions.None);
            if (kvp.Length != 4) throw new FormatException("input has not exactly 4 parts");
            return new dquat(double.Parse(kvp[0].Trim()), double.Parse(kvp[1].Trim()), double.Parse(kvp[2].Trim()), double.Parse(kvp[3].Trim()));
        }
        
        /// <summary>
        /// Converts the string representation of the quaternion into a quaternion representation (using a designated separator and a type provider).
        /// </summary>
        public static dquat Parse(string s, string sep, IFormatProvider provider)
        {
            var kvp = s.Split(new[] { sep }, StringSplitOptions.None);
            if (kvp.Length != 4) throw new FormatException("input has not exactly 4 parts");
            return new dquat(double.Parse(kvp[0].Trim(), provider), double.Parse(kvp[1].Trim(), provider), double.Parse(kvp[2].Trim(), provider), double.Parse(kvp[3].Trim(), provider));
        }
        
        /// <summary>
        /// Converts the string representation of the quaternion into a quaternion representation (using a designated separator and a number style).
        /// </summary>
        public static dquat Parse(string s, string sep, NumberStyles style)
        {
            var kvp = s.Split(new[] { sep }, StringSplitOptions.None);
            if (kvp.Length != 4) throw new FormatException("input has not exactly 4 parts");
            return new dquat(double.Parse(kvp[0].Trim(), style), double.Parse(kvp[1].Trim(), style), double.Parse(kvp[2].Trim(), style), double.Parse(kvp[3].Trim(), style));
        }
        
        /// <summary>
        /// Converts the string representation of the quaternion into a quaternion representation (using a designated separator and a number style and a format provider).
        /// </summary>
        public static dquat Parse(string s, string sep, NumberStyles style, IFormatProvider provider)
        {
            var kvp = s.Split(new[] { sep }, StringSplitOptions.None);
            if (kvp.Length != 4) throw new FormatException("input has not exactly 4 parts");
            return new dquat(double.Parse(kvp[0].Trim(), style, provider), double.Parse(kvp[1].Trim(), style, provider), double.Parse(kvp[2].Trim(), style, provider), double.Parse(kvp[3].Trim(), style, provider));
        }
        
        /// <summary>
        /// Tries to convert the string representation of the quaternion into a quaternion representation (using ', ' as a separator), returns false if string was invalid.
        /// </summary>
        public static bool TryParse(string s, out dquat result) => TryParse(s, ", ", out result);
        
        /// <summary>
        /// Tries to convert the string representation of the quaternion into a quaternion representation (using a designated separator), returns false if string was invalid.
        /// </summary>
        public static bool TryParse(string s, string sep, out dquat result)
        {
            result = Zero;
            if (string.IsNullOrEmpty(s)) return false;
            var kvp = s.Split(new[] { sep }, StringSplitOptions.None);
            if (kvp.Length != 4) return false;
            double x = 0.0, y = 0.0, z = 0.0, w = 0.0;
            var ok = ((double.TryParse(kvp[0].Trim(), out x) && double.TryParse(kvp[1].Trim(), out y)) && (double.TryParse(kvp[2].Trim(), out z) && double.TryParse(kvp[3].Trim(), out w)));
            result = ok ? new dquat(x, y, z, w) : Zero;
            return ok;
        }
        
        /// <summary>
        /// Tries to convert the string representation of the quaternion into a quaternion representation (using a designated separator and a number style and a format provider), returns false if string was invalid.
        /// </summary>
        public static bool TryParse(string s, string sep, NumberStyles style, IFormatProvider provider, out dquat result)
        {
            result = Zero;
            if (string.IsNullOrEmpty(s)) return false;
            var kvp = s.Split(new[] { sep }, StringSplitOptions.None);
            if (kvp.Length != 4) return false;
            double x = 0.0, y = 0.0, z = 0.0, w = 0.0;
            var ok = ((double.TryParse(kvp[0].Trim(), style, provider, out x) && double.TryParse(kvp[1].Trim(), style, provider, out y)) && (double.TryParse(kvp[2].Trim(), style, provider, out z) && double.TryParse(kvp[3].Trim(), style, provider, out w)));
            result = ok ? new dquat(x, y, z, w) : Zero;
            return ok;
        }
        
        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two quaternions.
        /// </summary>
        public static double Dot(dquat lhs, dquat rhs) => ((lhs.x * rhs.x + lhs.y * rhs.y) + (lhs.z * rhs.z + lhs.w * rhs.w));

        #endregion


        #region Component-Wise Static Functions
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of IsInfinity (double.IsInfinity(v)).
        /// </summary>
        public static bvec4 IsInfinity(dquat v) => new bvec4(double.IsInfinity(v.x), double.IsInfinity(v.y), double.IsInfinity(v.z), double.IsInfinity(v.w));
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of IsInfinity (double.IsInfinity(v)).
        /// </summary>
        public static bvec4 IsInfinity(double v) => new bvec4(double.IsInfinity(v));
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of IsFinite (!double.IsNaN(v) &amp;&amp; !double.IsInfinity(v)).
        /// </summary>
        public static bvec4 IsFinite(dquat v) => new bvec4(!double.IsNaN(v.x) && !double.IsInfinity(v.x), !double.IsNaN(v.y) && !double.IsInfinity(v.y), !double.IsNaN(v.z) && !double.IsInfinity(v.z), !double.IsNaN(v.w) && !double.IsInfinity(v.w));
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of IsFinite (!double.IsNaN(v) &amp;&amp; !double.IsInfinity(v)).
        /// </summary>
        public static bvec4 IsFinite(double v) => new bvec4(!double.IsNaN(v) && !double.IsInfinity(v));
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of IsNaN (double.IsNaN(v)).
        /// </summary>
        public static bvec4 IsNaN(dquat v) => new bvec4(double.IsNaN(v.x), double.IsNaN(v.y), double.IsNaN(v.z), double.IsNaN(v.w));
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of IsNaN (double.IsNaN(v)).
        /// </summary>
        public static bvec4 IsNaN(double v) => new bvec4(double.IsNaN(v));
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of IsNegativeInfinity (double.IsNegativeInfinity(v)).
        /// </summary>
        public static bvec4 IsNegativeInfinity(dquat v) => new bvec4(double.IsNegativeInfinity(v.x), double.IsNegativeInfinity(v.y), double.IsNegativeInfinity(v.z), double.IsNegativeInfinity(v.w));
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of IsNegativeInfinity (double.IsNegativeInfinity(v)).
        /// </summary>
        public static bvec4 IsNegativeInfinity(double v) => new bvec4(double.IsNegativeInfinity(v));
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of IsPositiveInfinity (double.IsPositiveInfinity(v)).
        /// </summary>
        public static bvec4 IsPositiveInfinity(dquat v) => new bvec4(double.IsPositiveInfinity(v.x), double.IsPositiveInfinity(v.y), double.IsPositiveInfinity(v.z), double.IsPositiveInfinity(v.w));
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of IsPositiveInfinity (double.IsPositiveInfinity(v)).
        /// </summary>
        public static bvec4 IsPositiveInfinity(double v) => new bvec4(double.IsPositiveInfinity(v));
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bvec4 Equal(dquat lhs, dquat rhs) => new bvec4(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z, lhs.w == rhs.w);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bvec4 Equal(dquat lhs, double rhs) => new bvec4(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs, lhs.w == rhs);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bvec4 Equal(double lhs, dquat rhs) => new bvec4(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z, lhs == rhs.w);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bvec4 Equal(double lhs, double rhs) => new bvec4(lhs == rhs);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bvec4 NotEqual(dquat lhs, dquat rhs) => new bvec4(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z, lhs.w != rhs.w);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bvec4 NotEqual(dquat lhs, double rhs) => new bvec4(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs, lhs.w != rhs);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bvec4 NotEqual(double lhs, dquat rhs) => new bvec4(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z, lhs != rhs.w);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bvec4 NotEqual(double lhs, double rhs) => new bvec4(lhs != rhs);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bvec4 GreaterThan(dquat lhs, dquat rhs) => new bvec4(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z, lhs.w > rhs.w);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bvec4 GreaterThan(dquat lhs, double rhs) => new bvec4(lhs.x > rhs, lhs.y > rhs, lhs.z > rhs, lhs.w > rhs);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bvec4 GreaterThan(double lhs, dquat rhs) => new bvec4(lhs > rhs.x, lhs > rhs.y, lhs > rhs.z, lhs > rhs.w);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bvec4 GreaterThan(double lhs, double rhs) => new bvec4(lhs > rhs);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bvec4 GreaterThanEqual(dquat lhs, dquat rhs) => new bvec4(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z, lhs.w >= rhs.w);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bvec4 GreaterThanEqual(dquat lhs, double rhs) => new bvec4(lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs, lhs.w >= rhs);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bvec4 GreaterThanEqual(double lhs, dquat rhs) => new bvec4(lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z, lhs >= rhs.w);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bvec4 GreaterThanEqual(double lhs, double rhs) => new bvec4(lhs >= rhs);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bvec4 LesserThan(dquat lhs, dquat rhs) => new bvec4(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z, lhs.w < rhs.w);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bvec4 LesserThan(dquat lhs, double rhs) => new bvec4(lhs.x < rhs, lhs.y < rhs, lhs.z < rhs, lhs.w < rhs);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bvec4 LesserThan(double lhs, dquat rhs) => new bvec4(lhs < rhs.x, lhs < rhs.y, lhs < rhs.z, lhs < rhs.w);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bvec4 LesserThan(double lhs, double rhs) => new bvec4(lhs < rhs);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bvec4 LesserThanEqual(dquat lhs, dquat rhs) => new bvec4(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z, lhs.w <= rhs.w);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bvec4 LesserThanEqual(dquat lhs, double rhs) => new bvec4(lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs, lhs.w <= rhs);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bvec4 LesserThanEqual(double lhs, dquat rhs) => new bvec4(lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z, lhs <= rhs.w);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bvec4 LesserThanEqual(double lhs, double rhs) => new bvec4(lhs <= rhs);

        #endregion


        #region Component-Wise Operator Overloads
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bvec4 operator<(dquat lhs, dquat rhs) => new bvec4(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z, lhs.w < rhs.w);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bvec4 operator<(dquat lhs, double rhs) => new bvec4(lhs.x < rhs, lhs.y < rhs, lhs.z < rhs, lhs.w < rhs);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bvec4 operator<(double lhs, dquat rhs) => new bvec4(lhs < rhs.x, lhs < rhs.y, lhs < rhs.z, lhs < rhs.w);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bvec4 operator<=(dquat lhs, dquat rhs) => new bvec4(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z, lhs.w <= rhs.w);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bvec4 operator<=(dquat lhs, double rhs) => new bvec4(lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs, lhs.w <= rhs);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bvec4 operator<=(double lhs, dquat rhs) => new bvec4(lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z, lhs <= rhs.w);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bvec4 operator>(dquat lhs, dquat rhs) => new bvec4(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z, lhs.w > rhs.w);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bvec4 operator>(dquat lhs, double rhs) => new bvec4(lhs.x > rhs, lhs.y > rhs, lhs.z > rhs, lhs.w > rhs);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bvec4 operator>(double lhs, dquat rhs) => new bvec4(lhs > rhs.x, lhs > rhs.y, lhs > rhs.z, lhs > rhs.w);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bvec4 operator>=(dquat lhs, dquat rhs) => new bvec4(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z, lhs.w >= rhs.w);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bvec4 operator>=(dquat lhs, double rhs) => new bvec4(lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs, lhs.w >= rhs);
        
        /// <summary>
        /// Returns a bvec4 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bvec4 operator>=(double lhs, dquat rhs) => new bvec4(lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z, lhs >= rhs.w);
        
        /// <summary>
        /// Returns a dquat from component-wise application of operator+ (identity).
        /// </summary>
        public static dquat operator+(dquat v) => v;
        
        /// <summary>
        /// Returns a dquat from component-wise application of operator- (-v).
        /// </summary>
        public static dquat operator-(dquat v) => new dquat(-v.x, -v.y, -v.z, -v.w);
        
        /// <summary>
        /// Returns a dquat from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static dquat operator+(dquat lhs, dquat rhs) => new dquat(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
        
        /// <summary>
        /// Returns a dquat from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static dquat operator+(dquat lhs, double rhs) => new dquat(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs, lhs.w + rhs);
        
        /// <summary>
        /// Returns a dquat from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static dquat operator+(double lhs, dquat rhs) => new dquat(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z, lhs + rhs.w);
        
        /// <summary>
        /// Returns a dquat from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static dquat operator-(dquat lhs, dquat rhs) => new dquat(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
        
        /// <summary>
        /// Returns a dquat from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static dquat operator-(dquat lhs, double rhs) => new dquat(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs, lhs.w - rhs);
        
        /// <summary>
        /// Returns a dquat from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static dquat operator-(double lhs, dquat rhs) => new dquat(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z, lhs - rhs.w);
        
        /// <summary>
        /// Returns a dquat from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static dquat operator*(dquat lhs, double rhs) => new dquat(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs, lhs.w * rhs);
        
        /// <summary>
        /// Returns a dquat from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static dquat operator/(dquat lhs, double rhs) => new dquat(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);

        #endregion

    }
}
