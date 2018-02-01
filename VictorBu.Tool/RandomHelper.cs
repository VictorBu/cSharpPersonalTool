using System;

namespace VictorBu.Tool
{
    public class RandomHelper
    {
        /// <summary>
        /// 生成有序的 GUID
        /// https://github.com/ericdc1/Dapper.SimpleCRUD
        /// </summary>
        /// <returns></returns>
        public static string SequentialGuid()
        {
            var tempGuid = Guid.NewGuid();
            var bytes = tempGuid.ToByteArray();
            var time = DateTime.Now;
            bytes[3] = (byte)time.Year;
            bytes[2] = (byte)time.Month;
            bytes[1] = (byte)time.Day;
            bytes[0] = (byte)time.Hour;
            bytes[5] = (byte)time.Minute;
            bytes[4] = (byte)time.Second;
            return new Guid(bytes).ToString();
        }
    }
}
