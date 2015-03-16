using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace GlmSharp
{
    [Serializable]
    public struct mat2 : IReadOnlyList<float>, IEquatable<mat2>
    {
        // Matrix fields mXY
        public float m00, m01; // Column 0
        public float m10, m11; // Column 1
        
        /// <summary>
        /// Creates a 2D array with all values (address: Values[x, y])
        /// </summary>
        public float[,] Values => new[,] { { m00, m01 }, { m10, m11 } };
        
        /// <summary>
        /// Creates a 1D array with all values (internal order)
        /// </summary>
        public float[] Values1D => new[] { m00, m01, m10, m11 };
        
        /// <summary>
        /// Returns the column nr 0
        /// </summary>
        public vec2 Column0 => new vec2(m00, m01);
        
        /// <summary>
        /// Returns the column nr 1
        /// </summary>
        public vec2 Column1 => new vec2(m10, m11);
        
        /// <summary>
        /// Returns the row nr 0
        /// </summary>
        public vec2 Row0 => new vec2(m00, m10);
        
        /// <summary>
        /// Returns the row nr 1
        /// </summary>
        public vec2 Row1 => new vec2(m01, m11);
        
        /// <summary>
        /// Predefined all-zero matrix (DO NOT MODIFY)
        /// </summary>
        public static readonly mat2 Zero = new mat2(default(float), default(float), default(float), default(float));
        
        /// <summary>
        /// Predefined all-ones matrix (DO NOT MODIFY)
        /// </summary>
        public static readonly mat2 Ones = new mat2(1f, 1f, 1f, 1f);
        
        /// <summary>
        /// Predefined identity matrix (DO NOT MODIFY)
        /// </summary>
        public static readonly mat2 Identity = new mat2(1f, default(float), default(float), 1f);
        
        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public mat2(float m00, float m01, float m10, float m11)
        {
            this.m00 = m00;
            this.m01 = m01;
            this.m10 = m10;
            this.m11 = m11;
        }
        
        /// <summary>
        /// Copy constructor
        /// </summary>
        public mat2(mat2 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m10 = m.m10;
            this.m11 = m.m11;
        }
        
        /// <summary>
        /// Column constructor
        /// </summary>
        public mat2(vec2 c0, vec2 c1)
        {
            this.m00 = c0.x;
            this.m01 = c0.y;
            this.m10 = c1.x;
            this.m11 = c1.y;
        }
        
        /// <summary>
        /// Returns an enumerator that iterates through all components.
        /// </summary>
        public IEnumerator<float> GetEnumerator()
        {
            yield return m00;
            yield return m01;
            yield return m10;
            yield return m11;
        }
        
        /// <summary>
        /// Returns an enumerator that iterates through all components.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
        /// <summary>
        /// Returns the number of components (4).
        /// </summary>
        public int Count => 4;
        
        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public float this[int fieldIndex]
        {
            get
            {
                switch (fieldIndex)
                {
                    case 0: return m00;
                    case 1: return m01;
                    case 2: return m10;
                    case 3: return m11;
                    default: throw new ArgumentOutOfRangeException("fieldIndex");
                }
            }
            set
            {
                switch (fieldIndex)
                {
                    case 0: this.m00 = value; break;
                    case 1: this.m01 = value; break;
                    case 2: this.m10 = value; break;
                    case 3: this.m11 = value; break;
                    default: throw new ArgumentOutOfRangeException("fieldIndex");
                }
            }
        }
        
        /// <summary>
        /// Gets/Sets a specific 2D-indexed component (a bit slower than direct access).
        /// </summary>
        public float this[int col, int row]
        {
            get
            {
                return this[col * 2 + row];
            }
            set
            {
                this[col * 2 + row] = value;
            }
        }
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public bool Equals(mat2 rhs) => m00.Equals(rhs.m00) && m01.Equals(rhs.m01) && m10.Equals(rhs.m10) && m11.Equals(rhs.m11);
        
        /// <summary>
        /// Returns true iff this equals rhs type- and component-wise.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is mat2 && Equals((mat2) obj);
        }
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool operator ==(mat2 lhs, mat2 rhs) => lhs.Equals(rhs);
        
        /// <summary>
        /// Returns true iff this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator !=(mat2 lhs, mat2 rhs) => !lhs.Equals(rhs);
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((((((m00.GetHashCode()) * 397) ^ m01.GetHashCode()) * 397) ^ m10.GetHashCode()) * 397) ^ m11.GetHashCode();
            }
        }
    }
}
