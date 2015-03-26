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

namespace GlmSharpTest.Generated.Vec2
{
    [TestFixture]
    public class DecimalVec2Test
    {

        [Test]
        public void Constructors()
        {
            {
                var v = new decvec2(7.5m);
                Assert.AreEqual(7.5m, v.x);
                Assert.AreEqual(7.5m, v.y);
            }
            {
                var v = new decvec2(9, -8.5m);
                Assert.AreEqual(9, v.x);
                Assert.AreEqual(-8.5m, v.y);
            }
            {
                var v = new decvec2(new decvec2(-9.5m, -5));
                Assert.AreEqual(-9.5m, v.x);
                Assert.AreEqual(-5, v.y);
            }
            {
                var v = new decvec2(new decvec3(-3.5m, -6, -3));
                Assert.AreEqual(-3.5m, v.x);
                Assert.AreEqual(-6, v.y);
            }
            {
                var v = new decvec2(new decvec4(4.5m, 5, 8.5m, -8.5m));
                Assert.AreEqual(4.5m, v.x);
                Assert.AreEqual(5, v.y);
            }
        }

        [Test]
        public void Indexer()
        {
            var v = new decvec2(6.5m, 2.5m);
            Assert.AreEqual(6.5m, v[0]);
            Assert.AreEqual(2.5m, v[1]);
            
            Assert.Throws<ArgumentOutOfRangeException>(() => { var s = v[-2147483648]; } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { v[-2147483648] = 0m; } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { var s = v[-1]; } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { v[-1] = 0m; } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { var s = v[2]; } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { v[2] = 0m; } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { var s = v[2147483647]; } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { v[2147483647] = 0m; } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { var s = v[5]; } );
            Assert.Throws<ArgumentOutOfRangeException>(() => { v[5] = 0m; } );
            
            v[1] = 0m;
            Assert.AreEqual(0m, v[1]);
            v[0] = 1m;
            Assert.AreEqual(1m, v[0]);
            v[0] = 2;
            Assert.AreEqual(2, v[0]);
            v[0] = 3;
            Assert.AreEqual(3, v[0]);
            v[0] = 4;
            Assert.AreEqual(4, v[0]);
            v[0] = 5;
            Assert.AreEqual(5, v[0]);
            v[0] = 6;
            Assert.AreEqual(6, v[0]);
            v[1] = 7;
            Assert.AreEqual(7, v[1]);
            v[1] = 8;
            Assert.AreEqual(8, v[1]);
            v[0] = 9;
            Assert.AreEqual(9, v[0]);
            v[1] = -1;
            Assert.AreEqual(-1, v[1]);
            v[0] = -2;
            Assert.AreEqual(-2, v[0]);
            v[1] = -3;
            Assert.AreEqual(-3, v[1]);
            v[0] = -4;
            Assert.AreEqual(-4, v[0]);
            v[0] = -5;
            Assert.AreEqual(-5, v[0]);
            v[1] = -6;
            Assert.AreEqual(-6, v[1]);
            v[0] = -7;
            Assert.AreEqual(-7, v[0]);
            v[0] = -8;
            Assert.AreEqual(-8, v[0]);
            v[1] = -9;
            Assert.AreEqual(-9, v[1]);
            v[1] = -9.5m;
            Assert.AreEqual(-9.5m, v[1]);
            v[0] = -8.5m;
            Assert.AreEqual(-8.5m, v[0]);
            v[1] = -7.5m;
            Assert.AreEqual(-7.5m, v[1]);
            v[1] = -6.5m;
            Assert.AreEqual(-6.5m, v[1]);
            v[1] = -5.5m;
            Assert.AreEqual(-5.5m, v[1]);
            v[0] = -4.5m;
            Assert.AreEqual(-4.5m, v[0]);
            v[0] = -3.5m;
            Assert.AreEqual(-3.5m, v[0]);
            v[0] = -2.5m;
            Assert.AreEqual(-2.5m, v[0]);
            v[0] = -1.5m;
            Assert.AreEqual(-1.5m, v[0]);
            v[0] = -0.5m;
            Assert.AreEqual(-0.5m, v[0]);
            v[0] = 0.5m;
            Assert.AreEqual(0.5m, v[0]);
            v[1] = 1.5m;
            Assert.AreEqual(1.5m, v[1]);
            v[0] = 2.5m;
            Assert.AreEqual(2.5m, v[0]);
            v[0] = 3.5m;
            Assert.AreEqual(3.5m, v[0]);
            v[0] = 4.5m;
            Assert.AreEqual(4.5m, v[0]);
            v[1] = 5.5m;
            Assert.AreEqual(5.5m, v[1]);
            v[1] = 6.5m;
            Assert.AreEqual(6.5m, v[1]);
            v[1] = 7.5m;
            Assert.AreEqual(7.5m, v[1]);
            v[0] = 8.5m;
            Assert.AreEqual(8.5m, v[0]);
            v[1] = 9.5m;
            Assert.AreEqual(9.5m, v[1]);
        }

        [Test]
        public void PropertyValues()
        {
            var v = new decvec2(-1, -2.5m);
            var vals = v.Values;
            Assert.AreEqual(-1, vals[0]);
            Assert.AreEqual(-2.5m, vals[1]);
            Assert.That(vals.SequenceEqual(v.ToArray()));
        }

        [Test]
        public void StaticProperties()
        {
            Assert.AreEqual(0m, decvec2.Zero.x);
            Assert.AreEqual(0m, decvec2.Zero.y);
            
            Assert.AreEqual(1m, decvec2.Ones.x);
            Assert.AreEqual(1m, decvec2.Ones.y);
            
            Assert.AreEqual(1m, decvec2.UnitX.x);
            Assert.AreEqual(0m, decvec2.UnitX.y);
            
            Assert.AreEqual(0m, decvec2.UnitY.x);
            Assert.AreEqual(1m, decvec2.UnitY.y);
            
            Assert.AreEqual(decimal.MaxValue, decvec2.MaxValue.x);
            Assert.AreEqual(decimal.MaxValue, decvec2.MaxValue.y);
            
            Assert.AreEqual(decimal.MinValue, decvec2.MinValue.x);
            Assert.AreEqual(decimal.MinValue, decvec2.MinValue.y);
            
            Assert.AreEqual(decimal.MinusOne, decvec2.MinusOne.x);
            Assert.AreEqual(decimal.MinusOne, decvec2.MinusOne.y);
        }

        [Test]
        public void Operators()
        {
            var v1 = new decvec2(0.5m, -4);
            var v2 = new decvec2(0.5m, -4);
            var v3 = new decvec2(-4, 0.5m);
            Assert.That(v1 == new decvec2(v1));
            Assert.That(v2 == new decvec2(v2));
            Assert.That(v3 == new decvec2(v3));
            Assert.That(v1 == v2);
            Assert.That(v1 != v3);
            Assert.That(v2 != v3);
        }

        [Test]
        public void StringInterop()
        {
            var v = new decvec2(2, 3);
            
            var s0 = v.ToString();
            var s1 = v.ToString("#");
            
            var v0 = decvec2.Parse(s0);
            var v1 = decvec2.Parse(s1, "#");
            Assert.AreEqual(v, v0);
            Assert.AreEqual(v, v1);
            
            var b0 = decvec2.TryParse(s0, out v0);
            var b1 = decvec2.TryParse(s1, "#", out v1);
            Assert.That(b0);
            Assert.That(b1);
            Assert.AreEqual(v, v0);
            Assert.AreEqual(v, v1);
            
            b0 = decvec2.TryParse(null, out v0);
            Assert.False(b0);
            b0 = decvec2.TryParse("", out v0);
            Assert.False(b0);
            b0 = decvec2.TryParse(s0 + ", 0", out v0);
            Assert.False(b0);
            
            Assert.Throws<NullReferenceException>(() => { decvec2.Parse(null); });
            Assert.Throws<FormatException>(() => { decvec2.Parse(""); });
            Assert.Throws<FormatException>(() => { decvec2.Parse(s0 + ", 0"); });
            
            var s2 = v.ToString(";", CultureInfo.InvariantCulture);
            Assert.That(s2.Length > 0);
            
            var s3 = v.ToString("; ", "G");
            var s4 = v.ToString("; ", "G", CultureInfo.InvariantCulture);
            var v3 = decvec2.Parse(s3, "; ", NumberStyles.Number);
            var v4 = decvec2.Parse(s4, "; ", NumberStyles.Number, CultureInfo.InvariantCulture);
            Assert.AreEqual(v, v3);
            Assert.AreEqual(v, v4);
            
            var b4 = decvec2.TryParse(s4, "; ", NumberStyles.Number, CultureInfo.InvariantCulture, out v4);
            Assert.That(b4);
            Assert.AreEqual(v, v4);
        }

        [Test]
        public void SerializationJson()
        {
            var v0 = new decvec2(-2, -8.5m);
            var s0 = JsonConvert.SerializeObject(v0);
            
            var v1 = JsonConvert.DeserializeObject<decvec2>(s0);
            var s1 = JsonConvert.SerializeObject(v1);
            
            Assert.AreEqual(v0, v1);
            Assert.AreEqual(s0, s1);
        }

        [Test]
        public void InvariantId()
        {
            {
                var v0 = new decvec2(5, 1.5m);
                Assert.AreEqual(v0, +v0);
            }
            {
                var v0 = new decvec2(-1.5m, 9);
                Assert.AreEqual(v0, +v0);
            }
            {
                var v0 = new decvec2(-7.5m, -1);
                Assert.AreEqual(v0, +v0);
            }
            {
                var v0 = new decvec2(-2, -2.5m);
                Assert.AreEqual(v0, +v0);
            }
            {
                var v0 = new decvec2(-8, 2.5m);
                Assert.AreEqual(v0, +v0);
            }
            {
                var v0 = new decvec2(-2, 0m);
                Assert.AreEqual(v0, +v0);
            }
            {
                var v0 = new decvec2(7, 6);
                Assert.AreEqual(v0, +v0);
            }
            {
                var v0 = new decvec2(-3.5m, -2);
                Assert.AreEqual(v0, +v0);
            }
            {
                var v0 = new decvec2(-3.5m, 6.5m);
                Assert.AreEqual(v0, +v0);
            }
            {
                var v0 = new decvec2(6.5m, -2);
                Assert.AreEqual(v0, +v0);
            }
        }

        [Test]
        public void InvariantDouble()
        {
            {
                var v0 = new decvec2(8.5m, -5);
                Assert.AreEqual(v0 + v0, 2 * v0);
            }
            {
                var v0 = new decvec2(0.5m, 4.5m);
                Assert.AreEqual(v0 + v0, 2 * v0);
            }
            {
                var v0 = new decvec2(-5.5m, 0.5m);
                Assert.AreEqual(v0 + v0, 2 * v0);
            }
            {
                var v0 = new decvec2(9.5m, 1m);
                Assert.AreEqual(v0 + v0, 2 * v0);
            }
            {
                var v0 = new decvec2(-5, 2);
                Assert.AreEqual(v0 + v0, 2 * v0);
            }
            {
                var v0 = new decvec2(-9.5m, -9.5m);
                Assert.AreEqual(v0 + v0, 2 * v0);
            }
            {
                var v0 = new decvec2(0m, -9);
                Assert.AreEqual(v0 + v0, 2 * v0);
            }
            {
                var v0 = new decvec2(4, -1);
                Assert.AreEqual(v0 + v0, 2 * v0);
            }
            {
                var v0 = new decvec2(5.5m, 3.5m);
                Assert.AreEqual(v0 + v0, 2 * v0);
            }
            {
                var v0 = new decvec2(-9, -0.5m);
                Assert.AreEqual(v0 + v0, 2 * v0);
            }
        }

        [Test]
        public void InvariantTriple()
        {
            {
                var v0 = new decvec2(-6.5m, -4);
                Assert.AreEqual(v0 + v0 + v0, 3 * v0);
            }
            {
                var v0 = new decvec2(8, -5);
                Assert.AreEqual(v0 + v0 + v0, 3 * v0);
            }
            {
                var v0 = new decvec2(9.5m, 2.5m);
                Assert.AreEqual(v0 + v0 + v0, 3 * v0);
            }
            {
                var v0 = new decvec2(0.5m, -7.5m);
                Assert.AreEqual(v0 + v0 + v0, 3 * v0);
            }
            {
                var v0 = new decvec2(1m, -6.5m);
                Assert.AreEqual(v0 + v0 + v0, 3 * v0);
            }
            {
                var v0 = new decvec2(-7.5m, -3.5m);
                Assert.AreEqual(v0 + v0 + v0, 3 * v0);
            }
            {
                var v0 = new decvec2(1.5m, 4);
                Assert.AreEqual(v0 + v0 + v0, 3 * v0);
            }
            {
                var v0 = new decvec2(7, 5);
                Assert.AreEqual(v0 + v0 + v0, 3 * v0);
            }
            {
                var v0 = new decvec2(4.5m, 6.5m);
                Assert.AreEqual(v0 + v0 + v0, 3 * v0);
            }
            {
                var v0 = new decvec2(-6, 4);
                Assert.AreEqual(v0 + v0 + v0, 3 * v0);
            }
        }

        [Test]
        public void InvariantCommutative()
        {
            {
                var v0 = new decvec2(-2, 2);
                var v1 = new decvec2(8.5m, 5.5m);
                Assert.AreEqual(v0 * v1, v1 * v0);
            }
            {
                var v0 = new decvec2(-7.5m, 5.5m);
                var v1 = new decvec2(-4.5m, 7.5m);
                Assert.AreEqual(v0 * v1, v1 * v0);
            }
            {
                var v0 = new decvec2(2, -9.5m);
                var v1 = new decvec2(9.5m, 1.5m);
                Assert.AreEqual(v0 * v1, v1 * v0);
            }
            {
                var v0 = new decvec2(5.5m, 0.5m);
                var v1 = new decvec2(8, -8);
                Assert.AreEqual(v0 * v1, v1 * v0);
            }
            {
                var v0 = new decvec2(-8, -3.5m);
                var v1 = new decvec2(-5, 2);
                Assert.AreEqual(v0 * v1, v1 * v0);
            }
            {
                var v0 = new decvec2(-8.5m, 2);
                var v1 = new decvec2(3.5m, -3);
                Assert.AreEqual(v0 * v1, v1 * v0);
            }
            {
                var v0 = new decvec2(8.5m, 6);
                var v1 = new decvec2(-7, -6);
                Assert.AreEqual(v0 * v1, v1 * v0);
            }
            {
                var v0 = new decvec2(3.5m, -4);
                var v1 = new decvec2(9, -7);
                Assert.AreEqual(v0 * v1, v1 * v0);
            }
            {
                var v0 = new decvec2(0m, 6.5m);
                var v1 = new decvec2(0.5m, -9.5m);
                Assert.AreEqual(v0 * v1, v1 * v0);
            }
            {
                var v0 = new decvec2(7, 1m);
                var v1 = new decvec2(-3, 0.5m);
                Assert.AreEqual(v0 * v1, v1 * v0);
            }
        }

        [Test]
        public void InvariantAssociative()
        {
            {
                var v0 = new decvec2(-1.5m, -5.5m);
                var v1 = new decvec2(-3.5m, -8);
                var v2 = new decvec2(4, -0.5m);
                Assert.AreEqual(v0 * (v1 + v2), v0 * v1 + v0 * v2);
            }
            {
                var v0 = new decvec2(-1, 4);
                var v1 = new decvec2(7.5m, 1m);
                var v2 = new decvec2(-9.5m, 5);
                Assert.AreEqual(v0 * (v1 + v2), v0 * v1 + v0 * v2);
            }
            {
                var v0 = new decvec2(-3, -9.5m);
                var v1 = new decvec2(0m, 8);
                var v2 = new decvec2(0m, 5);
                Assert.AreEqual(v0 * (v1 + v2), v0 * v1 + v0 * v2);
            }
            {
                var v0 = new decvec2(4.5m, -9);
                var v1 = new decvec2(-1.5m, 3.5m);
                var v2 = new decvec2(1m, 2.5m);
                Assert.AreEqual(v0 * (v1 + v2), v0 * v1 + v0 * v2);
            }
            {
                var v0 = new decvec2(-3.5m, -8);
                var v1 = new decvec2(7.5m, 8);
                var v2 = new decvec2(-6.5m, 2);
                Assert.AreEqual(v0 * (v1 + v2), v0 * v1 + v0 * v2);
            }
            {
                var v0 = new decvec2(2.5m, -9);
                var v1 = new decvec2(0m, -8.5m);
                var v2 = new decvec2(-3, 1.5m);
                Assert.AreEqual(v0 * (v1 + v2), v0 * v1 + v0 * v2);
            }
            {
                var v0 = new decvec2(2.5m, -4.5m);
                var v1 = new decvec2(-3, 4);
                var v2 = new decvec2(8, -5.5m);
                Assert.AreEqual(v0 * (v1 + v2), v0 * v1 + v0 * v2);
            }
            {
                var v0 = new decvec2(8.5m, 4);
                var v1 = new decvec2(0.5m, -2.5m);
                var v2 = new decvec2(-4.5m, -2);
                Assert.AreEqual(v0 * (v1 + v2), v0 * v1 + v0 * v2);
            }
            {
                var v0 = new decvec2(2, 2);
                var v1 = new decvec2(-6.5m, -8);
                var v2 = new decvec2(-1, -1.5m);
                Assert.AreEqual(v0 * (v1 + v2), v0 * v1 + v0 * v2);
            }
            {
                var v0 = new decvec2(5.5m, 4.5m);
                var v1 = new decvec2(-7.5m, 4.5m);
                var v2 = new decvec2(1.5m, -3.5m);
                Assert.AreEqual(v0 * (v1 + v2), v0 * v1 + v0 * v2);
            }
        }

        [Test]
        public void InvariantIdNeg()
        {
            {
                var v0 = new decvec2(-0.5m, -1);
                Assert.AreEqual(v0, -(-v0));
            }
            {
                var v0 = new decvec2(-7.5m, -5);
                Assert.AreEqual(v0, -(-v0));
            }
            {
                var v0 = new decvec2(-6, -9);
                Assert.AreEqual(v0, -(-v0));
            }
            {
                var v0 = new decvec2(-2.5m, 3.5m);
                Assert.AreEqual(v0, -(-v0));
            }
            {
                var v0 = new decvec2(5, 1.5m);
                Assert.AreEqual(v0, -(-v0));
            }
            {
                var v0 = new decvec2(-4, -3.5m);
                Assert.AreEqual(v0, -(-v0));
            }
            {
                var v0 = new decvec2(1m, 7);
                Assert.AreEqual(v0, -(-v0));
            }
            {
                var v0 = new decvec2(-5, 1m);
                Assert.AreEqual(v0, -(-v0));
            }
            {
                var v0 = new decvec2(6.5m, 3);
                Assert.AreEqual(v0, -(-v0));
            }
            {
                var v0 = new decvec2(-9, 9.5m);
                Assert.AreEqual(v0, -(-v0));
            }
        }

        [Test]
        public void InvariantCommutativeNeg()
        {
            {
                var v0 = new decvec2(-6.5m, 1.5m);
                var v1 = new decvec2(-5.5m, -5.5m);
                Assert.AreEqual(v0 - v1, -(v1 - v0));
            }
            {
                var v0 = new decvec2(-6.5m, -6.5m);
                var v1 = new decvec2(-1, 1.5m);
                Assert.AreEqual(v0 - v1, -(v1 - v0));
            }
            {
                var v0 = new decvec2(4, 6);
                var v1 = new decvec2(-7.5m, -3);
                Assert.AreEqual(v0 - v1, -(v1 - v0));
            }
            {
                var v0 = new decvec2(1.5m, -4.5m);
                var v1 = new decvec2(4, -4.5m);
                Assert.AreEqual(v0 - v1, -(v1 - v0));
            }
            {
                var v0 = new decvec2(-6.5m, -9.5m);
                var v1 = new decvec2(-8, -7);
                Assert.AreEqual(v0 - v1, -(v1 - v0));
            }
            {
                var v0 = new decvec2(-3.5m, 2);
                var v1 = new decvec2(6.5m, -5.5m);
                Assert.AreEqual(v0 - v1, -(v1 - v0));
            }
            {
                var v0 = new decvec2(-6.5m, -8);
                var v1 = new decvec2(-0.5m, 4.5m);
                Assert.AreEqual(v0 - v1, -(v1 - v0));
            }
            {
                var v0 = new decvec2(-7.5m, -7);
                var v1 = new decvec2(0.5m, 5.5m);
                Assert.AreEqual(v0 - v1, -(v1 - v0));
            }
            {
                var v0 = new decvec2(-9, -9.5m);
                var v1 = new decvec2(3, 4);
                Assert.AreEqual(v0 - v1, -(v1 - v0));
            }
            {
                var v0 = new decvec2(-5, -0.5m);
                var v1 = new decvec2(9, 0m);
                Assert.AreEqual(v0 - v1, -(v1 - v0));
            }
        }

        [Test]
        public void InvariantAssociativeNeg()
        {
            {
                var v0 = new decvec2(1.5m, -6.5m);
                var v1 = new decvec2(7.5m, 3);
                var v2 = new decvec2(-4, 0.5m);
                Assert.AreEqual(v0 * (v1 - v2), v0 * v1 - v0 * v2);
            }
            {
                var v0 = new decvec2(-6.5m, 9.5m);
                var v1 = new decvec2(0m, 5);
                var v2 = new decvec2(5, -9);
                Assert.AreEqual(v0 * (v1 - v2), v0 * v1 - v0 * v2);
            }
            {
                var v0 = new decvec2(7.5m, 7);
                var v1 = new decvec2(-1.5m, 4);
                var v2 = new decvec2(-1.5m, -4);
                Assert.AreEqual(v0 * (v1 - v2), v0 * v1 - v0 * v2);
            }
            {
                var v0 = new decvec2(-1, 7.5m);
                var v1 = new decvec2(9.5m, 1m);
                var v2 = new decvec2(2.5m, -8.5m);
                Assert.AreEqual(v0 * (v1 - v2), v0 * v1 - v0 * v2);
            }
            {
                var v0 = new decvec2(9, -7);
                var v1 = new decvec2(-8, 6.5m);
                var v2 = new decvec2(-6, -5.5m);
                Assert.AreEqual(v0 * (v1 - v2), v0 * v1 - v0 * v2);
            }
            {
                var v0 = new decvec2(5, 7);
                var v1 = new decvec2(-4, 5.5m);
                var v2 = new decvec2(8.5m, -9.5m);
                Assert.AreEqual(v0 * (v1 - v2), v0 * v1 - v0 * v2);
            }
            {
                var v0 = new decvec2(-4.5m, -3.5m);
                var v1 = new decvec2(-6.5m, -2);
                var v2 = new decvec2(-9, -3);
                Assert.AreEqual(v0 * (v1 - v2), v0 * v1 - v0 * v2);
            }
            {
                var v0 = new decvec2(-9, -7.5m);
                var v1 = new decvec2(-6, -1.5m);
                var v2 = new decvec2(3, -5);
                Assert.AreEqual(v0 * (v1 - v2), v0 * v1 - v0 * v2);
            }
            {
                var v0 = new decvec2(9.5m, -4);
                var v1 = new decvec2(4, -2);
                var v2 = new decvec2(-3.5m, 1.5m);
                Assert.AreEqual(v0 * (v1 - v2), v0 * v1 - v0 * v2);
            }
            {
                var v0 = new decvec2(0.5m, 0.5m);
                var v1 = new decvec2(1.5m, -6);
                var v2 = new decvec2(3.5m, 7.5m);
                Assert.AreEqual(v0 * (v1 - v2), v0 * v1 - v0 * v2);
            }
        }

    }
}