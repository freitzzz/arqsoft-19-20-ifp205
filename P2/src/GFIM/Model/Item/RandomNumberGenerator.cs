using System;

namespace GFAB.Model
{

  public class RandomNumberGenerator : Generator
  {
    public long Generate()
    {

      byte[] buf = new byte[8];
      new Random().NextBytes(buf);
      long longRand = BitConverter.ToInt64(buf, 0);
      return (Math.Abs(longRand % (long.MaxValue - 0)) + 0);

    }
  }

}