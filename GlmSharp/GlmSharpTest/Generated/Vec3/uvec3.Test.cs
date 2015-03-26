using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Numerics;
using System.Linq;
using NUnit.Framework;
using Newtonsoft.Json;
using GlmSharp;

// ReSharper disable InconsistentNaming

namespace GlmSharpTest.Generated.Vec3
{
    [TestFixture]
    public class UintVec3Test
    {

        [Test]
        public void Constructors()
        {
            {
                var v = new uvec3(9);
                Assert.AreEqual(9, v.x);
                Assert.AreEqual(9, v.y);
                Assert.AreEqual(9, v.z);
            }
            {
                var v = new uvec3(6, 5, 2);
                Assert.AreEqual(6, v.x);
                Assert.AreEqual(5, v.y);
                Assert.AreEqual(2, v.z);
            }
            {
                var v = new uvec3(new uvec2(8, 9));
                Assert.AreEqual(8, v.x);
                Assert.AreEqual(9, v.y);
                Assert.AreEqual(0u, v.z);
            }
            {
                var v = new uvec3(new uvec3(6, 3, 2));
                Assert.AreEqual(6, v.x);
                Assert.AreEqual(3, v.y);
                Assert.AreEqual(2, v.z);
            }
            {
                var v = new uvec3(new uvec4(8, 5, 6, 4));
                Assert.AreEqual(8, v.x);
                Assert.AreEqual(5, v.y);
                Assert.AreEqual(6, v.z);
            }
        }

        [Test]
        public void Indexer()
        {
            var v = new uvec3(9, 1u, 1u);
            Assert.AreEqual(9, v[0]);
            Assert.AreEqual(1u, v[1]);
            Assert.AreEqual(1u, v[2]);
            
            Assert.Throws<ArgumentOutOfRangeException>(() => { var s = v[-2147483648]; } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { v[-2147483648] = 0u; } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { var s = v[-1]; } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { v[-1] = 0u; } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { var s = v[3]; } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { v[3] = 0u; } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { var s = v[2147483647]; } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { v[2147483647] = 0u; } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { var s = v[5]; } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { v[5] = 0u; } );
            
            v[1] = 0u;
            Assert.AreEqual(0u, v[1]);
            v[0] = 1u;
            Assert.AreEqual(1u, v[0]);
            v[1] = 2;
            Assert.AreEqual(2, v[1]);
            v[2] = 3;
            Assert.AreEqual(3, v[2]);
            v[0] = 4;
            Assert.AreEqual(4, v[0]);
            v[2] = 5;
            Assert.AreEqual(5, v[2]);
            v[0] = 6;
            Assert.AreEqual(6, v[0]);
            v[2] = 7;
            Assert.AreEqual(7, v[2]);
            v[2] = 8;
            Assert.AreEqual(8, v[2]);
            v[1] = 9;
            Assert.AreEqual(9, v[1]);
        }

        [Test]
        public void PropertyValues()
        {
            var v = new uvec3(5, 2, 9);
            var vals = v.Values;
            Assert.AreEqual(5, vals[0]);
            Assert.AreEqual(2, vals[1]);
            Assert.AreEqual(9, vals[2]);
            Assert.That(vals.SequenceEqual(v.ToArray()));
        }

        [Test]
        public void StaticProperties()
        {
            Assert.AreEqual(0u, uvec3.Zero.x);
            Assert.AreEqual(0u, uvec3.Zero.y);
            Assert.AreEqual(0u, uvec3.Zero.z);
            
            Assert.AreEqual(1u, uvec3.Ones.x);
            Assert.AreEqual(1u, uvec3.Ones.y);
            Assert.AreEqual(1u, uvec3.Ones.z);
            
            Assert.AreEqual(1u, uvec3.UnitX.x);
            Assert.AreEqual(0u, uvec3.UnitX.y);
            Assert.AreEqual(0u, uvec3.UnitX.z);
            
            Assert.AreEqual(0u, uvec3.UnitY.x);
            Assert.AreEqual(1u, uvec3.UnitY.y);
            Assert.AreEqual(0u, uvec3.UnitY.z);
            
            Assert.AreEqual(0u, uvec3.UnitZ.x);
            Assert.AreEqual(0u, uvec3.UnitZ.y);
            Assert.AreEqual(1u, uvec3.UnitZ.z);
            
            Assert.AreEqual(uint.MaxValue, uvec3.MaxValue.x);
            Assert.AreEqual(uint.MaxValue, uvec3.MaxValue.y);
            Assert.AreEqual(uint.MaxValue, uvec3.MaxValue.z);
            
            Assert.AreEqual(uint.MinValue, uvec3.MinValue.x);
            Assert.AreEqual(uint.MinValue, uvec3.MinValue.y);
            Assert.AreEqual(uint.MinValue, uvec3.MinValue.z);
        }

        [Test]
        public void Operators()
        {
            var v1 = new uvec3(3, 5, 6);
            var v2 = new uvec3(3, 5, 6);
            var v3 = new uvec3(6, 5, 3);
            Assert.That(v1 == new uvec3(v1));
            Assert.That(v2 == new uvec3(v2));
            Assert.That(v3 == new uvec3(v3));
            Assert.That(v1 == v2);
            Assert.That(v1 != v3);
            Assert.That(v2 != v3);
        }

        [Test]
        public void StringInterop()
        {
            var v = new uvec3(4, 3, 3);
            
            var s0 = v.ToString();
            var s1 = v.ToString("#");
            
            var v0 = uvec3.Parse(s0);
            var v1 = uvec3.Parse(s1, "#");
            Assert.AreEqual(v, v0);
            Assert.AreEqual(v, v1);
            
            var b0 = uvec3.TryParse(s0, out v0);
            var b1 = uvec3.TryParse(s1, "#", out v1);
            Assert.That(b0);
            Assert.That(b1);
            Assert.AreEqual(v, v0);
            Assert.AreEqual(v, v1);
            
            b0 = uvec3.TryParse(null, out v0);
            Assert.False(b0);
            b0 = uvec3.TryParse("", out v0);
            Assert.False(b0);
            b0 = uvec3.TryParse(s0 + ", 0", out v0);
            Assert.False(b0);
            
            Assert.Throws<NullReferenceException>(() => { uvec3.Parse(null); });
            Assert.Throws<FormatException>(() => { uvec3.Parse(""); });
            Assert.Throws<FormatException>(() => { uvec3.Parse(s0 + ", 0"); });
            
            var s2 = v.ToString(";", CultureInfo.InvariantCulture);
            Assert.That(s2.Length > 0);
            
            var s3 = v.ToString("; ", "G");
            var s4 = v.ToString("; ", "G", CultureInfo.InvariantCulture);
            var v3 = uvec3.Parse(s3, "; ", NumberStyles.Number);
            var v4 = uvec3.Parse(s4, "; ", NumberStyles.Number, CultureInfo.InvariantCulture);
            Assert.AreEqual(v, v3);
            Assert.AreEqual(v, v4);
            
            var b4 = uvec3.TryParse(s4, "; ", NumberStyles.Number, CultureInfo.InvariantCulture, out v4);
            Assert.That(b4);
            Assert.AreEqual(v, v4);
        }

        [Test]
        public void SerializationJson()
        {
            var v0 = new uvec3(5, 4, 3);
            var s0 = JsonConvert.SerializeObject(v0);
            
            var v1 = JsonConvert.DeserializeObject<uvec3>(s0);
            var s1 = JsonConvert.SerializeObject(v1);
            
            Assert.AreEqual(v0, v1);
            Assert.AreEqual(s0, s1);
        }

        [Test]
        public void InvariantId()
        {
            {
                var v0 = new uvec3(9, 1u, 7);
                Assert.AreEqual(v0, +v0);
            }
            {
                var v0 = new uvec3(6, 9, 0u);
                Assert.AreEqual(v0, +v0);
            }
            {
                var v0 = new uvec3(2, 4, 5);
                Assert.AreEqual(v0, +v0);
            }
            {
                var v0 = new uvec3(9, 8, 2);
                Assert.AreEqual(v0, +v0);
            }
            {
                var v0 = new uvec3(7, 1u, 8);
                Assert.AreEqual(v0, +v0);
            }
            {
                var v0 = new uvec3(0u, 3, 0u);
                Assert.AreEqual(v0, +v0);
            }
            {
                var v0 = new uvec3(4, 4, 2);
                Assert.AreEqual(v0, +v0);
            }
            {
                var v0 = new uvec3(6, 3, 5);
                Assert.AreEqual(v0, +v0);
            }
            {
                var v0 = new uvec3(1u, 4, 4);
                Assert.AreEqual(v0, +v0);
            }
            {
                var v0 = new uvec3(6, 0u, 1u);
                Assert.AreEqual(v0, +v0);
            }
        }

        [Test]
        public void InvariantDouble()
        {
            {
                var v0 = new uvec3(8, 5, 2);
                Assert.AreEqual(v0 + v0, 2 * v0);
            }
            {
                var v0 = new uvec3(9, 5, 8);
                Assert.AreEqual(v0 + v0, 2 * v0);
            }
            {
                var v0 = new uvec3(0u, 5, 7);
                Assert.AreEqual(v0 + v0, 2 * v0);
            }
            {
                var v0 = new uvec3(9, 0u, 6);
                Assert.AreEqual(v0 + v0, 2 * v0);
            }
            {
                var v0 = new uvec3(9, 1u, 7);
                Assert.AreEqual(v0 + v0, 2 * v0);
            }
            {
                var v0 = new uvec3(7, 4, 4);
                Assert.AreEqual(v0 + v0, 2 * v0);
            }
            {
                var v0 = new uvec3(9, 5, 9);
                Assert.AreEqual(v0 + v0, 2 * v0);
            }
            {
                var v0 = new uvec3(1u, 9, 8);
                Assert.AreEqual(v0 + v0, 2 * v0);
            }
            {
                var v0 = new uvec3(6, 4, 0u);
                Assert.AreEqual(v0 + v0, 2 * v0);
            }
            {
                var v0 = new uvec3(2, 6, 7);
                Assert.AreEqual(v0 + v0, 2 * v0);
            }
        }

        [Test]
        public void InvariantTriple()
        {
            {
                var v0 = new uvec3(2, 5, 8);
                Assert.AreEqual(v0 + v0 + v0, 3 * v0);
            }
            {
                var v0 = new uvec3(3, 1u, 8);
                Assert.AreEqual(v0 + v0 + v0, 3 * v0);
            }
            {
                var v0 = new uvec3(2, 0u, 0u);
                Assert.AreEqual(v0 + v0 + v0, 3 * v0);
            }
            {
                var v0 = new uvec3(4, 9, 5);
                Assert.AreEqual(v0 + v0 + v0, 3 * v0);
            }
            {
                var v0 = new uvec3(1u, 4, 6);
                Assert.AreEqual(v0 + v0 + v0, 3 * v0);
            }
            {
                var v0 = new uvec3(9, 4, 3);
                Assert.AreEqual(v0 + v0 + v0, 3 * v0);
            }
            {
                var v0 = new uvec3(0u, 1u, 4);
                Assert.AreEqual(v0 + v0 + v0, 3 * v0);
            }
            {
                var v0 = new uvec3(5, 1u, 6);
                Assert.AreEqual(v0 + v0 + v0, 3 * v0);
            }
            {
                var v0 = new uvec3(6, 4, 3);
                Assert.AreEqual(v0 + v0 + v0, 3 * v0);
            }
            {
                var v0 = new uvec3(6, 7, 7);
                Assert.AreEqual(v0 + v0 + v0, 3 * v0);
            }
        }

        [Test]
        public void InvariantCommutative()
        {
            {
                var v0 = new uvec3(2, 5, 4);
                var v1 = new uvec3(3, 0u, 3);
                Assert.AreEqual(v0 * v1, v1 * v0);
            }
            {
                var v0 = new uvec3(0u, 8, 8);
                var v1 = new uvec3(9, 6, 4);
                Assert.AreEqual(v0 * v1, v1 * v0);
            }
            {
                var v0 = new uvec3(0u, 0u, 1u);
                var v1 = new uvec3(0u, 7, 4);
                Assert.AreEqual(v0 * v1, v1 * v0);
            }
            {
                var v0 = new uvec3(1u, 3, 6);
                var v1 = new uvec3(9, 6, 3);
                Assert.AreEqual(v0 * v1, v1 * v0);
            }
            {
                var v0 = new uvec3(2, 6, 5);
                var v1 = new uvec3(5, 2, 2);
                Assert.AreEqual(v0 * v1, v1 * v0);
            }
            {
                var v0 = new uvec3(4, 1u, 7);
                var v1 = new uvec3(6, 2, 9);
                Assert.AreEqual(v0 * v1, v1 * v0);
            }
            {
                var v0 = new uvec3(5, 0u, 6);
                var v1 = new uvec3(5, 1u, 8);
                Assert.AreEqual(v0 * v1, v1 * v0);
            }
            {
                var v0 = new uvec3(3, 9, 0u);
                var v1 = new uvec3(8, 3, 1u);
                Assert.AreEqual(v0 * v1, v1 * v0);
            }
            {
                var v0 = new uvec3(0u, 3, 6);
                var v1 = new uvec3(8, 6, 8);
                Assert.AreEqual(v0 * v1, v1 * v0);
            }
            {
                var v0 = new uvec3(2, 2, 9);
                var v1 = new uvec3(1u, 1u, 3);
                Assert.AreEqual(v0 * v1, v1 * v0);
            }
        }

        [Test]
        public void InvariantAssociative()
        {
            {
                var v0 = new uvec3(0u, 8, 1u);
                var v1 = new uvec3(1u, 8, 2);
                var v2 = new uvec3(4, 8, 1u);
                Assert.AreEqual(v0 * (v1 + v2), v0 * v1 + v0 * v2);
            }
            {
                var v0 = new uvec3(5, 4, 3);
                var v1 = new uvec3(0u, 1u, 9);
                var v2 = new uvec3(2, 5, 3);
                Assert.AreEqual(v0 * (v1 + v2), v0 * v1 + v0 * v2);
            }
            {
                var v0 = new uvec3(9, 1u, 9);
                var v1 = new uvec3(7, 2, 6);
                var v2 = new uvec3(9, 1u, 9);
                Assert.AreEqual(v0 * (v1 + v2), v0 * v1 + v0 * v2);
            }
            {
                var v0 = new uvec3(9, 3, 4);
                var v1 = new uvec3(0u, 3, 6);
                var v2 = new uvec3(8, 6, 2);
                Assert.AreEqual(v0 * (v1 + v2), v0 * v1 + v0 * v2);
            }
            {
                var v0 = new uvec3(1u, 6, 3);
                var v1 = new uvec3(7, 9, 5);
                var v2 = new uvec3(0u, 2, 1u);
                Assert.AreEqual(v0 * (v1 + v2), v0 * v1 + v0 * v2);
            }
            {
                var v0 = new uvec3(8, 6, 0u);
                var v1 = new uvec3(6, 5, 3);
                var v2 = new uvec3(6, 8, 2);
                Assert.AreEqual(v0 * (v1 + v2), v0 * v1 + v0 * v2);
            }
            {
                var v0 = new uvec3(0u, 2, 6);
                var v1 = new uvec3(5, 1u, 6);
                var v2 = new uvec3(2, 5, 4);
                Assert.AreEqual(v0 * (v1 + v2), v0 * v1 + v0 * v2);
            }
            {
                var v0 = new uvec3(6, 4, 1u);
                var v1 = new uvec3(7, 1u, 4);
                var v2 = new uvec3(6, 0u, 9);
                Assert.AreEqual(v0 * (v1 + v2), v0 * v1 + v0 * v2);
            }
            {
                var v0 = new uvec3(9, 1u, 2);
                var v1 = new uvec3(4, 7, 9);
                var v2 = new uvec3(4, 0u, 5);
                Assert.AreEqual(v0 * (v1 + v2), v0 * v1 + v0 * v2);
            }
            {
                var v0 = new uvec3(9, 3, 8);
                var v1 = new uvec3(1u, 4, 4);
                var v2 = new uvec3(4, 7, 3);
                Assert.AreEqual(v0 * (v1 + v2), v0 * v1 + v0 * v2);
            }
        }

    }
}