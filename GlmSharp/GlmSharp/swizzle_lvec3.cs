using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Linq;

namespace GlmSharp
{
    [Serializable]
    public struct swizzle_lvec3
    {
        public readonly long x;
        public readonly long y;
        public readonly long z;
        
        public swizzle_lvec3(long x, long y, long z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        
        // XYZW Versions
        public lvec2 xx => new lvec2(x, x);
        public lvec3 xxx => new lvec3(x, x, x);
        public lvec4 xxxx => new lvec4(x, x, x, x);
        public lvec4 xxxy => new lvec4(x, x, x, y);
        public lvec4 xxxz => new lvec4(x, x, x, z);
        public lvec3 xxy => new lvec3(x, x, y);
        public lvec4 xxyx => new lvec4(x, x, y, x);
        public lvec4 xxyy => new lvec4(x, x, y, y);
        public lvec4 xxyz => new lvec4(x, x, y, z);
        public lvec3 xxz => new lvec3(x, x, z);
        public lvec4 xxzx => new lvec4(x, x, z, x);
        public lvec4 xxzy => new lvec4(x, x, z, y);
        public lvec4 xxzz => new lvec4(x, x, z, z);
        public lvec2 xy => new lvec2(x, y);
        public lvec3 xyx => new lvec3(x, y, x);
        public lvec4 xyxx => new lvec4(x, y, x, x);
        public lvec4 xyxy => new lvec4(x, y, x, y);
        public lvec4 xyxz => new lvec4(x, y, x, z);
        public lvec3 xyy => new lvec3(x, y, y);
        public lvec4 xyyx => new lvec4(x, y, y, x);
        public lvec4 xyyy => new lvec4(x, y, y, y);
        public lvec4 xyyz => new lvec4(x, y, y, z);
        public lvec3 xyz => new lvec3(x, y, z);
        public lvec4 xyzx => new lvec4(x, y, z, x);
        public lvec4 xyzy => new lvec4(x, y, z, y);
        public lvec4 xyzz => new lvec4(x, y, z, z);
        public lvec2 xz => new lvec2(x, z);
        public lvec3 xzx => new lvec3(x, z, x);
        public lvec4 xzxx => new lvec4(x, z, x, x);
        public lvec4 xzxy => new lvec4(x, z, x, y);
        public lvec4 xzxz => new lvec4(x, z, x, z);
        public lvec3 xzy => new lvec3(x, z, y);
        public lvec4 xzyx => new lvec4(x, z, y, x);
        public lvec4 xzyy => new lvec4(x, z, y, y);
        public lvec4 xzyz => new lvec4(x, z, y, z);
        public lvec3 xzz => new lvec3(x, z, z);
        public lvec4 xzzx => new lvec4(x, z, z, x);
        public lvec4 xzzy => new lvec4(x, z, z, y);
        public lvec4 xzzz => new lvec4(x, z, z, z);
        public lvec2 yx => new lvec2(y, x);
        public lvec3 yxx => new lvec3(y, x, x);
        public lvec4 yxxx => new lvec4(y, x, x, x);
        public lvec4 yxxy => new lvec4(y, x, x, y);
        public lvec4 yxxz => new lvec4(y, x, x, z);
        public lvec3 yxy => new lvec3(y, x, y);
        public lvec4 yxyx => new lvec4(y, x, y, x);
        public lvec4 yxyy => new lvec4(y, x, y, y);
        public lvec4 yxyz => new lvec4(y, x, y, z);
        public lvec3 yxz => new lvec3(y, x, z);
        public lvec4 yxzx => new lvec4(y, x, z, x);
        public lvec4 yxzy => new lvec4(y, x, z, y);
        public lvec4 yxzz => new lvec4(y, x, z, z);
        public lvec2 yy => new lvec2(y, y);
        public lvec3 yyx => new lvec3(y, y, x);
        public lvec4 yyxx => new lvec4(y, y, x, x);
        public lvec4 yyxy => new lvec4(y, y, x, y);
        public lvec4 yyxz => new lvec4(y, y, x, z);
        public lvec3 yyy => new lvec3(y, y, y);
        public lvec4 yyyx => new lvec4(y, y, y, x);
        public lvec4 yyyy => new lvec4(y, y, y, y);
        public lvec4 yyyz => new lvec4(y, y, y, z);
        public lvec3 yyz => new lvec3(y, y, z);
        public lvec4 yyzx => new lvec4(y, y, z, x);
        public lvec4 yyzy => new lvec4(y, y, z, y);
        public lvec4 yyzz => new lvec4(y, y, z, z);
        public lvec2 yz => new lvec2(y, z);
        public lvec3 yzx => new lvec3(y, z, x);
        public lvec4 yzxx => new lvec4(y, z, x, x);
        public lvec4 yzxy => new lvec4(y, z, x, y);
        public lvec4 yzxz => new lvec4(y, z, x, z);
        public lvec3 yzy => new lvec3(y, z, y);
        public lvec4 yzyx => new lvec4(y, z, y, x);
        public lvec4 yzyy => new lvec4(y, z, y, y);
        public lvec4 yzyz => new lvec4(y, z, y, z);
        public lvec3 yzz => new lvec3(y, z, z);
        public lvec4 yzzx => new lvec4(y, z, z, x);
        public lvec4 yzzy => new lvec4(y, z, z, y);
        public lvec4 yzzz => new lvec4(y, z, z, z);
        public lvec2 zx => new lvec2(z, x);
        public lvec3 zxx => new lvec3(z, x, x);
        public lvec4 zxxx => new lvec4(z, x, x, x);
        public lvec4 zxxy => new lvec4(z, x, x, y);
        public lvec4 zxxz => new lvec4(z, x, x, z);
        public lvec3 zxy => new lvec3(z, x, y);
        public lvec4 zxyx => new lvec4(z, x, y, x);
        public lvec4 zxyy => new lvec4(z, x, y, y);
        public lvec4 zxyz => new lvec4(z, x, y, z);
        public lvec3 zxz => new lvec3(z, x, z);
        public lvec4 zxzx => new lvec4(z, x, z, x);
        public lvec4 zxzy => new lvec4(z, x, z, y);
        public lvec4 zxzz => new lvec4(z, x, z, z);
        public lvec2 zy => new lvec2(z, y);
        public lvec3 zyx => new lvec3(z, y, x);
        public lvec4 zyxx => new lvec4(z, y, x, x);
        public lvec4 zyxy => new lvec4(z, y, x, y);
        public lvec4 zyxz => new lvec4(z, y, x, z);
        public lvec3 zyy => new lvec3(z, y, y);
        public lvec4 zyyx => new lvec4(z, y, y, x);
        public lvec4 zyyy => new lvec4(z, y, y, y);
        public lvec4 zyyz => new lvec4(z, y, y, z);
        public lvec3 zyz => new lvec3(z, y, z);
        public lvec4 zyzx => new lvec4(z, y, z, x);
        public lvec4 zyzy => new lvec4(z, y, z, y);
        public lvec4 zyzz => new lvec4(z, y, z, z);
        public lvec2 zz => new lvec2(z, z);
        public lvec3 zzx => new lvec3(z, z, x);
        public lvec4 zzxx => new lvec4(z, z, x, x);
        public lvec4 zzxy => new lvec4(z, z, x, y);
        public lvec4 zzxz => new lvec4(z, z, x, z);
        public lvec3 zzy => new lvec3(z, z, y);
        public lvec4 zzyx => new lvec4(z, z, y, x);
        public lvec4 zzyy => new lvec4(z, z, y, y);
        public lvec4 zzyz => new lvec4(z, z, y, z);
        public lvec3 zzz => new lvec3(z, z, z);
        public lvec4 zzzx => new lvec4(z, z, z, x);
        public lvec4 zzzy => new lvec4(z, z, z, y);
        public lvec4 zzzz => new lvec4(z, z, z, z);
        
        // RGBA Versions
        public lvec2 rr => new lvec2(x, x);
        public lvec3 rrr => new lvec3(x, x, x);
        public lvec4 rrrr => new lvec4(x, x, x, x);
        public lvec4 rrrg => new lvec4(x, x, x, y);
        public lvec4 rrrb => new lvec4(x, x, x, z);
        public lvec3 rrg => new lvec3(x, x, y);
        public lvec4 rrgr => new lvec4(x, x, y, x);
        public lvec4 rrgg => new lvec4(x, x, y, y);
        public lvec4 rrgb => new lvec4(x, x, y, z);
        public lvec3 rrb => new lvec3(x, x, z);
        public lvec4 rrbr => new lvec4(x, x, z, x);
        public lvec4 rrbg => new lvec4(x, x, z, y);
        public lvec4 rrbb => new lvec4(x, x, z, z);
        public lvec2 rg => new lvec2(x, y);
        public lvec3 rgr => new lvec3(x, y, x);
        public lvec4 rgrr => new lvec4(x, y, x, x);
        public lvec4 rgrg => new lvec4(x, y, x, y);
        public lvec4 rgrb => new lvec4(x, y, x, z);
        public lvec3 rgg => new lvec3(x, y, y);
        public lvec4 rggr => new lvec4(x, y, y, x);
        public lvec4 rggg => new lvec4(x, y, y, y);
        public lvec4 rggb => new lvec4(x, y, y, z);
        public lvec3 rgb => new lvec3(x, y, z);
        public lvec4 rgbr => new lvec4(x, y, z, x);
        public lvec4 rgbg => new lvec4(x, y, z, y);
        public lvec4 rgbb => new lvec4(x, y, z, z);
        public lvec2 rb => new lvec2(x, z);
        public lvec3 rbr => new lvec3(x, z, x);
        public lvec4 rbrr => new lvec4(x, z, x, x);
        public lvec4 rbrg => new lvec4(x, z, x, y);
        public lvec4 rbrb => new lvec4(x, z, x, z);
        public lvec3 rbg => new lvec3(x, z, y);
        public lvec4 rbgr => new lvec4(x, z, y, x);
        public lvec4 rbgg => new lvec4(x, z, y, y);
        public lvec4 rbgb => new lvec4(x, z, y, z);
        public lvec3 rbb => new lvec3(x, z, z);
        public lvec4 rbbr => new lvec4(x, z, z, x);
        public lvec4 rbbg => new lvec4(x, z, z, y);
        public lvec4 rbbb => new lvec4(x, z, z, z);
        public lvec2 gr => new lvec2(y, x);
        public lvec3 grr => new lvec3(y, x, x);
        public lvec4 grrr => new lvec4(y, x, x, x);
        public lvec4 grrg => new lvec4(y, x, x, y);
        public lvec4 grrb => new lvec4(y, x, x, z);
        public lvec3 grg => new lvec3(y, x, y);
        public lvec4 grgr => new lvec4(y, x, y, x);
        public lvec4 grgg => new lvec4(y, x, y, y);
        public lvec4 grgb => new lvec4(y, x, y, z);
        public lvec3 grb => new lvec3(y, x, z);
        public lvec4 grbr => new lvec4(y, x, z, x);
        public lvec4 grbg => new lvec4(y, x, z, y);
        public lvec4 grbb => new lvec4(y, x, z, z);
        public lvec2 gg => new lvec2(y, y);
        public lvec3 ggr => new lvec3(y, y, x);
        public lvec4 ggrr => new lvec4(y, y, x, x);
        public lvec4 ggrg => new lvec4(y, y, x, y);
        public lvec4 ggrb => new lvec4(y, y, x, z);
        public lvec3 ggg => new lvec3(y, y, y);
        public lvec4 gggr => new lvec4(y, y, y, x);
        public lvec4 gggg => new lvec4(y, y, y, y);
        public lvec4 gggb => new lvec4(y, y, y, z);
        public lvec3 ggb => new lvec3(y, y, z);
        public lvec4 ggbr => new lvec4(y, y, z, x);
        public lvec4 ggbg => new lvec4(y, y, z, y);
        public lvec4 ggbb => new lvec4(y, y, z, z);
        public lvec2 gb => new lvec2(y, z);
        public lvec3 gbr => new lvec3(y, z, x);
        public lvec4 gbrr => new lvec4(y, z, x, x);
        public lvec4 gbrg => new lvec4(y, z, x, y);
        public lvec4 gbrb => new lvec4(y, z, x, z);
        public lvec3 gbg => new lvec3(y, z, y);
        public lvec4 gbgr => new lvec4(y, z, y, x);
        public lvec4 gbgg => new lvec4(y, z, y, y);
        public lvec4 gbgb => new lvec4(y, z, y, z);
        public lvec3 gbb => new lvec3(y, z, z);
        public lvec4 gbbr => new lvec4(y, z, z, x);
        public lvec4 gbbg => new lvec4(y, z, z, y);
        public lvec4 gbbb => new lvec4(y, z, z, z);
        public lvec2 br => new lvec2(z, x);
        public lvec3 brr => new lvec3(z, x, x);
        public lvec4 brrr => new lvec4(z, x, x, x);
        public lvec4 brrg => new lvec4(z, x, x, y);
        public lvec4 brrb => new lvec4(z, x, x, z);
        public lvec3 brg => new lvec3(z, x, y);
        public lvec4 brgr => new lvec4(z, x, y, x);
        public lvec4 brgg => new lvec4(z, x, y, y);
        public lvec4 brgb => new lvec4(z, x, y, z);
        public lvec3 brb => new lvec3(z, x, z);
        public lvec4 brbr => new lvec4(z, x, z, x);
        public lvec4 brbg => new lvec4(z, x, z, y);
        public lvec4 brbb => new lvec4(z, x, z, z);
        public lvec2 bg => new lvec2(z, y);
        public lvec3 bgr => new lvec3(z, y, x);
        public lvec4 bgrr => new lvec4(z, y, x, x);
        public lvec4 bgrg => new lvec4(z, y, x, y);
        public lvec4 bgrb => new lvec4(z, y, x, z);
        public lvec3 bgg => new lvec3(z, y, y);
        public lvec4 bggr => new lvec4(z, y, y, x);
        public lvec4 bggg => new lvec4(z, y, y, y);
        public lvec4 bggb => new lvec4(z, y, y, z);
        public lvec3 bgb => new lvec3(z, y, z);
        public lvec4 bgbr => new lvec4(z, y, z, x);
        public lvec4 bgbg => new lvec4(z, y, z, y);
        public lvec4 bgbb => new lvec4(z, y, z, z);
        public lvec2 bb => new lvec2(z, z);
        public lvec3 bbr => new lvec3(z, z, x);
        public lvec4 bbrr => new lvec4(z, z, x, x);
        public lvec4 bbrg => new lvec4(z, z, x, y);
        public lvec4 bbrb => new lvec4(z, z, x, z);
        public lvec3 bbg => new lvec3(z, z, y);
        public lvec4 bbgr => new lvec4(z, z, y, x);
        public lvec4 bbgg => new lvec4(z, z, y, y);
        public lvec4 bbgb => new lvec4(z, z, y, z);
        public lvec3 bbb => new lvec3(z, z, z);
        public lvec4 bbbr => new lvec4(z, z, z, x);
        public lvec4 bbbg => new lvec4(z, z, z, y);
        public lvec4 bbbb => new lvec4(z, z, z, z);
    }
}
