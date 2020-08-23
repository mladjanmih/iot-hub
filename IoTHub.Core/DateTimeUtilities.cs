using System;
using System.Collections.Generic;
using System.Text;

namespace IoTHub.Core
{
    public static class DateTimeUtilities
    {
        public static long ToUnixTimestamp(this DateTime dateTime)
        {
            var dateTimeOffset = new DateTimeOffset(dateTime);
            return dateTimeOffset.ToUnixTimeSeconds();
        }

        public static DateTime FromUnixTimestamp(this long timestamp)
        {
            var dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(timestamp);
            return dateTimeOffset.LocalDateTime;
        }
    }
}
