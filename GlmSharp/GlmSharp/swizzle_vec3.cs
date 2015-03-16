using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Linq;

namespace GlmSharp
{
    [Serializable]
    public struct swizzle_vec3
    {
        public readonly float x;
        public readonly float y;
        public readonly float z;
        
        public swizzle_vec3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        
        // XYZW Versions
        public vec2 xx => new vec2(x, x);
        public vec3 xxx => new vec3(x, x, x);
        public vec4 xxxx => new vec4(x, x, x, x);
        public vec4 xxxy => new vec4(x, x, x, y);
        public vec4 xxxz => new vec4(x, x, x, z);
        public vec3 xxy => new vec3(x, x, y);
        public vec4 xxyx => new vec4(x, x, y, x);
        public vec4 xxyy => new vec4(x, x, y, y);
        public vec4 xxyz => new vec4(x, x, y, z);
        public vec3 xxz => new vec3(x, x, z);
        public vec4 xxzx => new vec4(x, x, z, x);
        public vec4 xxzy => new vec4(x, x, z, y);
        public vec4 xxzz => new vec4(x, x, z, z);
        public vec2 xy => new vec2(x, y);
        public vec3 xyx => new vec3(x, y, x);
        public vec4 xyxx => new vec4(x, y, x, x);
        public vec4 xyxy => new vec4(x, y, x, y);
        public vec4 xyxz => new vec4(x, y, x, z);
        public vec3 xyy => new vec3(x, y, y);
        public vec4 xyyx => new vec4(x, y, y, x);
        public vec4 xyyy => new vec4(x, y, y, y);
        public vec4 xyyz => new vec4(x, y, y, z);
        public vec3 xyz => new vec3(x, y, z);
        public vec4 xyzx => new vec4(x, y, z, x);
        public vec4 xyzy => new vec4(x, y, z, y);
        public vec4 xyzz => new vec4(x, y, z, z);
        public vec2 xz => new vec2(x, z);
        public vec3 xzx => new vec3(x, z, x);
        public vec4 xzxx => new vec4(x, z, x, x);
        public vec4 xzxy => new vec4(x, z, x, y);
        public vec4 xzxz => new vec4(x, z, x, z);
        public vec3 xzy => new vec3(x, z, y);
        public vec4 xzyx => new vec4(x, z, y, x);
        public vec4 xzyy => new vec4(x, z, y, y);
        public vec4 xzyz => new vec4(x, z, y, z);
        public vec3 xzz => new vec3(x, z, z);
        public vec4 xzzx => new vec4(x, z, z, x);
        public vec4 xzzy => new vec4(x, z, z, y);
        public vec4 xzzz => new vec4(x, z, z, z);
        public vec2 yx => new vec2(y, x);
        public vec3 yxx => new vec3(y, x, x);
        public vec4 yxxx => new vec4(y, x, x, x);
        public vec4 yxxy => new vec4(y, x, x, y);
        public vec4 yxxz => new vec4(y, x, x, z);
        public vec3 yxy => new vec3(y, x, y);
        public vec4 yxyx => new vec4(y, x, y, x);
        public vec4 yxyy => new vec4(y, x, y, y);
        public vec4 yxyz => new vec4(y, x, y, z);
        public vec3 yxz => new vec3(y, x, z);
        public vec4 yxzx => new vec4(y, x, z, x);
        public vec4 yxzy => new vec4(y, x, z, y);
        public vec4 yxzz => new vec4(y, x, z, z);
        public vec2 yy => new vec2(y, y);
        public vec3 yyx => new vec3(y, y, x);
        public vec4 yyxx => new vec4(y, y, x, x);
        public vec4 yyxy => new vec4(y, y, x, y);
        public vec4 yyxz => new vec4(y, y, x, z);
        public vec3 yyy => new vec3(y, y, y);
        public vec4 yyyx => new vec4(y, y, y, x);
        public vec4 yyyy => new vec4(y, y, y, y);
        public vec4 yyyz => new vec4(y, y, y, z);
        public vec3 yyz => new vec3(y, y, z);
        public vec4 yyzx => new vec4(y, y, z, x);
        public vec4 yyzy => new vec4(y, y, z, y);
        public vec4 yyzz => new vec4(y, y, z, z);
        public vec2 yz => new vec2(y, z);
        public vec3 yzx => new vec3(y, z, x);
        public vec4 yzxx => new vec4(y, z, x, x);
        public vec4 yzxy => new vec4(y, z, x, y);
        public vec4 yzxz => new vec4(y, z, x, z);
        public vec3 yzy => new vec3(y, z, y);
        public vec4 yzyx => new vec4(y, z, y, x);
        public vec4 yzyy => new vec4(y, z, y, y);
        public vec4 yzyz => new vec4(y, z, y, z);
        public vec3 yzz => new vec3(y, z, z);
        public vec4 yzzx => new vec4(y, z, z, x);
        public vec4 yzzy => new vec4(y, z, z, y);
        public vec4 yzzz => new vec4(y, z, z, z);
        public vec2 zx => new vec2(z, x);
        public vec3 zxx => new vec3(z, x, x);
        public vec4 zxxx => new vec4(z, x, x, x);
        public vec4 zxxy => new vec4(z, x, x, y);
        public vec4 zxxz => new vec4(z, x, x, z);
        public vec3 zxy => new vec3(z, x, y);
        public vec4 zxyx => new vec4(z, x, y, x);
        public vec4 zxyy => new vec4(z, x, y, y);
        public vec4 zxyz => new vec4(z, x, y, z);
        public vec3 zxz => new vec3(z, x, z);
        public vec4 zxzx => new vec4(z, x, z, x);
        public vec4 zxzy => new vec4(z, x, z, y);
        public vec4 zxzz => new vec4(z, x, z, z);
        public vec2 zy => new vec2(z, y);
        public vec3 zyx => new vec3(z, y, x);
        public vec4 zyxx => new vec4(z, y, x, x);
        public vec4 zyxy => new vec4(z, y, x, y);
        public vec4 zyxz => new vec4(z, y, x, z);
        public vec3 zyy => new vec3(z, y, y);
        public vec4 zyyx => new vec4(z, y, y, x);
        public vec4 zyyy => new vec4(z, y, y, y);
        public vec4 zyyz => new vec4(z, y, y, z);
        public vec3 zyz => new vec3(z, y, z);
        public vec4 zyzx => new vec4(z, y, z, x);
        public vec4 zyzy => new vec4(z, y, z, y);
        public vec4 zyzz => new vec4(z, y, z, z);
        public vec2 zz => new vec2(z, z);
        public vec3 zzx => new vec3(z, z, x);
        public vec4 zzxx => new vec4(z, z, x, x);
        public vec4 zzxy => new vec4(z, z, x, y);
        public vec4 zzxz => new vec4(z, z, x, z);
        public vec3 zzy => new vec3(z, z, y);
        public vec4 zzyx => new vec4(z, z, y, x);
        public vec4 zzyy => new vec4(z, z, y, y);
        public vec4 zzyz => new vec4(z, z, y, z);
        public vec3 zzz => new vec3(z, z, z);
        public vec4 zzzx => new vec4(z, z, z, x);
        public vec4 zzzy => new vec4(z, z, z, y);
        public vec4 zzzz => new vec4(z, z, z, z);
        
        // RGBA Versions
        public vec2 rr => new vec2(x, x);
        public vec3 rrr => new vec3(x, x, x);
        public vec4 rrrr => new vec4(x, x, x, x);
        public vec4 rrrg => new vec4(x, x, x, y);
        public vec4 rrrb => new vec4(x, x, x, z);
        public vec3 rrg => new vec3(x, x, y);
        public vec4 rrgr => new vec4(x, x, y, x);
        public vec4 rrgg => new vec4(x, x, y, y);
        public vec4 rrgb => new vec4(x, x, y, z);
        public vec3 rrb => new vec3(x, x, z);
        public vec4 rrbr => new vec4(x, x, z, x);
        public vec4 rrbg => new vec4(x, x, z, y);
        public vec4 rrbb => new vec4(x, x, z, z);
        public vec2 rg => new vec2(x, y);
        public vec3 rgr => new vec3(x, y, x);
        public vec4 rgrr => new vec4(x, y, x, x);
        public vec4 rgrg => new vec4(x, y, x, y);
        public vec4 rgrb => new vec4(x, y, x, z);
        public vec3 rgg => new vec3(x, y, y);
        public vec4 rggr => new vec4(x, y, y, x);
        public vec4 rggg => new vec4(x, y, y, y);
        public vec4 rggb => new vec4(x, y, y, z);
        public vec3 rgb => new vec3(x, y, z);
        public vec4 rgbr => new vec4(x, y, z, x);
        public vec4 rgbg => new vec4(x, y, z, y);
        public vec4 rgbb => new vec4(x, y, z, z);
        public vec2 rb => new vec2(x, z);
        public vec3 rbr => new vec3(x, z, x);
        public vec4 rbrr => new vec4(x, z, x, x);
        public vec4 rbrg => new vec4(x, z, x, y);
        public vec4 rbrb => new vec4(x, z, x, z);
        public vec3 rbg => new vec3(x, z, y);
        public vec4 rbgr => new vec4(x, z, y, x);
        public vec4 rbgg => new vec4(x, z, y, y);
        public vec4 rbgb => new vec4(x, z, y, z);
        public vec3 rbb => new vec3(x, z, z);
        public vec4 rbbr => new vec4(x, z, z, x);
        public vec4 rbbg => new vec4(x, z, z, y);
        public vec4 rbbb => new vec4(x, z, z, z);
        public vec2 gr => new vec2(y, x);
        public vec3 grr => new vec3(y, x, x);
        public vec4 grrr => new vec4(y, x, x, x);
        public vec4 grrg => new vec4(y, x, x, y);
        public vec4 grrb => new vec4(y, x, x, z);
        public vec3 grg => new vec3(y, x, y);
        public vec4 grgr => new vec4(y, x, y, x);
        public vec4 grgg => new vec4(y, x, y, y);
        public vec4 grgb => new vec4(y, x, y, z);
        public vec3 grb => new vec3(y, x, z);
        public vec4 grbr => new vec4(y, x, z, x);
        public vec4 grbg => new vec4(y, x, z, y);
        public vec4 grbb => new vec4(y, x, z, z);
        public vec2 gg => new vec2(y, y);
        public vec3 ggr => new vec3(y, y, x);
        public vec4 ggrr => new vec4(y, y, x, x);
        public vec4 ggrg => new vec4(y, y, x, y);
        public vec4 ggrb => new vec4(y, y, x, z);
        public vec3 ggg => new vec3(y, y, y);
        public vec4 gggr => new vec4(y, y, y, x);
        public vec4 gggg => new vec4(y, y, y, y);
        public vec4 gggb => new vec4(y, y, y, z);
        public vec3 ggb => new vec3(y, y, z);
        public vec4 ggbr => new vec4(y, y, z, x);
        public vec4 ggbg => new vec4(y, y, z, y);
        public vec4 ggbb => new vec4(y, y, z, z);
        public vec2 gb => new vec2(y, z);
        public vec3 gbr => new vec3(y, z, x);
        public vec4 gbrr => new vec4(y, z, x, x);
        public vec4 gbrg => new vec4(y, z, x, y);
        public vec4 gbrb => new vec4(y, z, x, z);
        public vec3 gbg => new vec3(y, z, y);
        public vec4 gbgr => new vec4(y, z, y, x);
        public vec4 gbgg => new vec4(y, z, y, y);
        public vec4 gbgb => new vec4(y, z, y, z);
        public vec3 gbb => new vec3(y, z, z);
        public vec4 gbbr => new vec4(y, z, z, x);
        public vec4 gbbg => new vec4(y, z, z, y);
        public vec4 gbbb => new vec4(y, z, z, z);
        public vec2 br => new vec2(z, x);
        public vec3 brr => new vec3(z, x, x);
        public vec4 brrr => new vec4(z, x, x, x);
        public vec4 brrg => new vec4(z, x, x, y);
        public vec4 brrb => new vec4(z, x, x, z);
        public vec3 brg => new vec3(z, x, y);
        public vec4 brgr => new vec4(z, x, y, x);
        public vec4 brgg => new vec4(z, x, y, y);
        public vec4 brgb => new vec4(z, x, y, z);
        public vec3 brb => new vec3(z, x, z);
        public vec4 brbr => new vec4(z, x, z, x);
        public vec4 brbg => new vec4(z, x, z, y);
        public vec4 brbb => new vec4(z, x, z, z);
        public vec2 bg => new vec2(z, y);
        public vec3 bgr => new vec3(z, y, x);
        public vec4 bgrr => new vec4(z, y, x, x);
        public vec4 bgrg => new vec4(z, y, x, y);
        public vec4 bgrb => new vec4(z, y, x, z);
        public vec3 bgg => new vec3(z, y, y);
        public vec4 bggr => new vec4(z, y, y, x);
        public vec4 bggg => new vec4(z, y, y, y);
        public vec4 bggb => new vec4(z, y, y, z);
        public vec3 bgb => new vec3(z, y, z);
        public vec4 bgbr => new vec4(z, y, z, x);
        public vec4 bgbg => new vec4(z, y, z, y);
        public vec4 bgbb => new vec4(z, y, z, z);
        public vec2 bb => new vec2(z, z);
        public vec3 bbr => new vec3(z, z, x);
        public vec4 bbrr => new vec4(z, z, x, x);
        public vec4 bbrg => new vec4(z, z, x, y);
        public vec4 bbrb => new vec4(z, z, x, z);
        public vec3 bbg => new vec3(z, z, y);
        public vec4 bbgr => new vec4(z, z, y, x);
        public vec4 bbgg => new vec4(z, z, y, y);
        public vec4 bbgb => new vec4(z, z, y, z);
        public vec3 bbb => new vec3(z, z, z);
        public vec4 bbbr => new vec4(z, z, z, x);
        public vec4 bbbg => new vec4(z, z, z, y);
        public vec4 bbbb => new vec4(z, z, z, z);
    }
}
