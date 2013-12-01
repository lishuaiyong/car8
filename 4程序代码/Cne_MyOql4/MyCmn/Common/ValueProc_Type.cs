using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Collections;

namespace MyCmn
{
    public static partial class ValueProc
    {
        /// <summary>
        /// 得到对象的 Bool 类型的值
        /// </summary>
        /// <param name="Value">要转换的值</param>
        /// <param name="defaultValue">如果转换失败，返回的默认值</param>
        /// <returns>如果对象的值可正确返回， 返回对象转换的值 ，否则， 返回默认值 。</returns>
        public static bool AsBool(this object Value, bool defaultValue)
        {
            if (Value.IsDBNull()) return defaultValue;
#if DEBUG
            GodError.Check((Value as ICantToValueType) != null, "检测到要将不可转换为值类型(ICantToValueType)的对象转换为值类型,请检查代码!");
#endif
            var blValue = Value as bool?;
            if (blValue.HasValue) { return blValue.Value; }

            var strValue = Value as string;
            if (strValue != null && strValue.HasValue() == false) return defaultValue;


            if (strValue != null)
            {
                if (strValue == "0") return false;
                if (strValue == "1") return true;
                if (string.Equals(strValue, "yes", StringComparison.CurrentCultureIgnoreCase)) return true;
                if (string.Equals(strValue, "no", StringComparison.CurrentCultureIgnoreCase)) return false;

                bool retVal = defaultValue;
                if (bool.TryParse(strValue, out retVal))
                {
                    return retVal;
                }
                else return defaultValue;
            }
            else if (Value is IConvertible)
            {
                var val = Value as IConvertible;
                if (val != null)
                    return val.ToBoolean(CultureInfo.CurrentCulture);
            }

            var iValue = Value as int?;
            if (iValue.HasValue) return iValue != 0;

            return defaultValue;
        }


        /// <summary>
        /// 得到对象的 Int 类型的值,如果是 Float 和 Double , 则 截断 返回.
        /// </summary>
        /// <remarks>
        /// 具体逻辑:
        /// 1. 如果是 Null 或 DbNull  返回默认. 另外, 如果Value 是 ICantToValueType , 则报错.
        /// 2. 如果是String,调用 int.TryParse , 出错,则调用 AsFloat 转Int.
        /// 3. 如果不是String,则依次转为 int?,float?,double? ,IConvertible 进行转换返回.
        /// </remarks>
        /// <param name="Value">要转换的值</param>
        /// <param name="defaultValue">如果转换失败，返回的默认值</param>
        /// <param name="Rounding">是否四舍五入</param>
        /// <returns>如果对象的值可正确返回， 返回对象转换的值 ，否则， 返回默认值 。</returns>
        public static int AsInt(this object Value, int defaultValue, bool Rounding)
        {
            if (Value.IsDBNull()) return defaultValue;

            {
                var nval = Value as int?;
                if (nval != null && nval.HasValue) return nval.Value;
            }


            var StringValue = Value as string;
            bool ValueIsString = StringValue != null;

            if (ValueIsString && StringValue.HasValue() == false) return defaultValue;
#if DEBUG
            GodError.Check((Value as ICantToValueType) != null, "检测到要将不可转换为值类型(ICantToValueType)的对象转换为值类型,请检查代码!");
#endif

            int retVal = defaultValue;
            if (ValueIsString)
            {
                if (StringValue.Contains('.'))
                {
                    return (int)(AsDecimal(Value, defaultValue.AsDecimal()) + (Rounding ? 0.5m : 0.0m));
                }
                else
                {
                    if (int.TryParse(StringValue, NumberStyles.Any, CultureInfo.CurrentCulture, out retVal))
                    {
                        return retVal;
                    }
                    else return defaultValue;
                }

                //统一使用 先转 float ，再转 int 的方式 。
                //return (int)(AsFloat(Value, defaultValue.AsFloat()) + (Rounding ? 0.5 : 0.0));
                //if (int.TryParse(StringValue, NumberStyles.Any, CultureInfo.CurrentCulture, out retVal))
                //{
                //    return retVal;
                //}
                //else
                //{
                //    //对于 Oracle.DataAccess.Types.OracleDecimal 来说, 直接转换会出错. 先进行 Float 转换.
                //    // Convert.ToInt32 如果超出范围,会报错, 强制类型转换 不会报错, 会默认返回0 .
                //}
            }
            else
            {
                //判断是否是   float 和 double
                {
                    var nval = Value as float?;
                    if (nval != null && nval.HasValue) return (int)(nval.Value + (Rounding ? 0.5 : 0.0));
                }
                {
                    var nval = Value as double?;
                    if (nval != null && nval.HasValue) return (int)(nval.Value + (Rounding ? 0.5 : 0.0));
                }


                //如果定义了 IConvertible ， 如枚举，则忽略掉四舍五入。
                {
                    var nval = Value as IConvertible;
                    if (Equals(nval, null) == false)
                    {
                        //可能会 value is greater than Int32.MaxValue or less than Int32.MinValue ，直接抛错
                        return nval.ToInt32(CultureInfo.CurrentCulture);
                    }
                }
            }


            //最后，调用 ConvertFrom 和 ConvertTo 方法。忽略四舍五入。
            var cov = changeType(typeof(int), Value, null);
            if (cov.IsDBNull()) return defaultValue;
            else return (int)cov;
        }

        public static uint AsUInt(this object Value, uint defaultValue, bool Rounding)
        {
            if (Value.IsDBNull()) return defaultValue;

            {
                var uiValue = Value as uint?;
                if (uiValue.HasValue) return uiValue.Value;
            }

            {
                var val = Value as int?;
                if (val.HasValue) return (uint)val.Value;
            }


            var strValue = Value as string;
            if (strValue != null && strValue.HasValue() == false) return defaultValue;

#if DEBUG
            GodError.Check((Value as ICantToValueType) != null, "检测到要将不可转换为值类型(ICantToValueType)的对象转换为值类型,请检查代码!");
#endif
            if (strValue != null)
            {
                return (uint)(AsLong(Value, defaultValue.AsLong(), Rounding));

                //uint retVal = defaultValue;
                //if (uint.TryParse(strValue, NumberStyles.Any, CultureInfo.CurrentCulture, out retVal))
                //{
                //    return retVal;
                //}
            }
            else
            {
                var conValue = Value as IConvertible;
                if (conValue != null)
                {
                    //可能会 超出范围 ，直接抛错
                    return conValue.ToUInt32(CultureInfo.CurrentCulture);
                }
            }

            //最后，调用 ConvertFrom 和 ConvertTo 方法。忽略四舍五入。
            var cov = changeType(typeof(int), Value, null);
            if (cov.IsDBNull()) return defaultValue;
            else return (uint)cov;
        }

        /// <summary>
        /// 得到对象的 String 类型的值
        /// </summary>
        /// <remarks>
        /// 具体逻辑:
        /// 1. 如果是 Null 或 DbNull  返回默认. 另外, 如果Value 是 ICantToValueType , 则报错.
        /// 2. 转换顺序为: string ,IEnumerable&lt;char&gt;,char[] 
        /// 3. 最后调用 TypeDescriptor.GetConverter(typeof(string)).ConvertFrom
        /// 4.如果 defaultValue 是 null,表示：忽略 defaultValue , 仅返回 Value 的字串值。
        /// </remarks>
        /// <param name="Value">要转换的值，如果是字符串且字符串是空字符串或Null，则返回 DefaultValue </param>
        /// <param name="defaultValue">如果是字符串且字符串是空字符串或Null，则返回该值。</param>
        /// <returns>如果对象的值可正确返回， 返回对象转换的值 ，否则， 返回默认值 。</returns>
        public static string AsString(this object Value, string defaultValue)
        {
            if (Equals(Value, null)) return defaultValue;
            if ((Value as DBNull) != null) return defaultValue;
            //GodError.Check((Value as ICantToValueType) != null, typeof(ValueProc), () => "检测到要将不可转换为值类型(ICantToValueType)的对象转换为 String,请检查代码!");
            //string retVal = defaultValue;

            var strValue = Value as string;
            if (strValue != null)
            {
                if (strValue != string.Empty) return strValue;
                //else if (defaultValue == null) return strValue;
                else return defaultValue;
            }

            var IEnumChars = Value as IEnumerable<char>;
            if (IEnumChars != null)
            {
                return new string(IEnumChars.ToArray());
            }

            var chrs = Value as char[];
            if (chrs != null)
            {
                return new string(chrs);
            }

            return Value.ToString();
        }

        /// <summary>
        /// 得到对象的 Decimal 类型的值
        /// </summary>
        /// <param name="Value">要转换的值</param>
        /// <param name="defaultValue">如果转换失败，返回的默认值</param>
        /// <returns>如果对象的值可正确返回， 返回对象转换的值 ，否则， 返回默认值 。</returns>
        public static decimal AsDecimal(this object Value, decimal defaultValue)
        {
            if (Value.IsDBNull()) return defaultValue;

            {
                var decValue = Value as decimal?;
                if (decValue.HasValue) return decValue.Value;
            }
            {
                var decValue = Value as int?;
                if (decValue.HasValue) return decValue.Value;
            }

            var strValue = Value as string;
            if (strValue != null)
            {
                if (string.IsNullOrEmpty(strValue))
                {
                    return defaultValue;
                }
                else
                {
                    decimal retVal = defaultValue;
                    if (decimal.TryParse(strValue, NumberStyles.Any, CultureInfo.CurrentCulture, out retVal))
                    {
                        return retVal;
                    }
                    else return defaultValue;
                }
            }

#if DEBUG
            GodError.Check((Value as ICantToValueType) != null, "检测到要将不可转换为值类型(ICantToValueType)的对象转换为值类型,请检查代码!");
#endif

            if (Value is IConvertible)
            {
                //可能会 超出范围,没有实现，非法转换等 ，直接抛错
                //http://msdn.microsoft.com/zh-cn/library/ms130989
                return (Value as IConvertible).ToDecimal(CultureInfo.CurrentCulture);
            }

            //最后，调用 ConvertFrom 和 ConvertTo 方法。忽略四舍五入。
            var cov = changeType(typeof(decimal), Value, null);
            if (cov.IsDBNull()) return defaultValue;
            else return (decimal)cov;
        }

        /// <summary>
        /// 得到对象的 Long 类型的值,对于小数，会截断返回。
        /// </summary>
        /// <param name="Value">要转换的值</param>
        /// <param name="defaultValue">如果转换失败，返回的默认值</param>
        /// <returns>如果对象的值可正确返回， 返回对象转换的值 ，否则， 返回默认值 。</returns>
        public static long AsLong(this object Value, long defaultValue, bool Rounding)
        {
            if (Value.IsDBNull()) return defaultValue;

            {
                var lngValue = Value as long?;
                if (lngValue.HasValue) return lngValue.Value;
            }
            {
                var val = Value as int?;
                if (val.HasValue) return val.Value;
            }

            var StringValue = Value as string;

            if (StringValue != null && StringValue.Length == 0) return defaultValue;

#if DEBUG
            GodError.Check((Value as ICantToValueType) != null, "检测到要将不可转换为值类型(ICantToValueType)的对象转换为值类型,请检查代码!");
#endif

            if (StringValue != null)
            {
                if (StringValue.Contains('.'))
                {
                    //如果有小数点, 或 E , 则先调用 AsDecimal 再..
                    return (long)(AsDecimal(StringValue, defaultValue) + (Rounding ? 0.5m : 0.0m));
                }

                long retVal = defaultValue;
                if (long.TryParse(StringValue, NumberStyles.Any, CultureInfo.CurrentCulture, out retVal))
                {
                    return retVal;
                }
                else return defaultValue;
            }
            else
            {
                var convValue = Value as IConvertible;
                if (convValue != null)
                {
                    return convValue.ToInt64(CultureInfo.CurrentCulture);
                }
            }

            //最后，调用 ConvertFrom 和 ConvertTo 方法。忽略四舍五入。
            var cov = changeType(typeof(long), Value, null);
            if (cov.IsDBNull()) return defaultValue;
            else return (long)cov;
        }

        /// <summary>
        /// 得到对象的 Float 类型的值,如果Value非法(IsNaN,IsNegativeInfinity,IsPositiveInfinity),返回默认值.
        /// </summary>
        /// <param name="Value">要转换的值</param>
        /// <param name="defaultValue">如果转换失败，返回的默认值</param>
        /// <returns>如果对象的值可正确返回， 返回对象转换的值 ，否则， 返回默认值 。</returns>
        public static float AsFloat(this object Value, float defaultValue)
        {
            if (Value.IsDBNull()) return defaultValue;

            var fltValue = Value as float?;
            if (fltValue.HasValue) return fltValue.Value;

            var strValue = Value as string;

            if (strValue != null)
            {
                //strValue = strValue.Trim();

                if (strValue.Length == 0) return defaultValue;
            }

#if DEBUG
            GodError.Check((Value as ICantToValueType) != null, "检测到要将不可转换为值类型(ICantToValueType)的对象转换为值类型,请检查代码!");
#endif
            float retVal = defaultValue;

            if (float.TryParse(strValue ?? Value.AsString(), NumberStyles.Any, CultureInfo.CurrentCulture, out retVal))
            {
                if (float.IsNaN(retVal) || float.IsInfinity(retVal) || float.IsNegativeInfinity(retVal) ||
                    float.IsPositiveInfinity(retVal))
                {
                    return defaultValue;
                }
                else return retVal;
            }

            //最后，调用 ConvertFrom 和 ConvertTo 方法。忽略四舍五入。
            var cov = changeType(typeof(float), Value, null);
            if (cov.IsDBNull()) return defaultValue;
            else return (float)cov;
        }


        public static double AsDouble(this object Value, double defaultValue)
        {
            if (Value.IsDBNull()) return defaultValue;

            var dblValue = Value as double?;
            if (dblValue.HasValue) return dblValue.Value;

            var strValue = Value as string;

            if (strValue != null)
            {
                //strValue = strValue.Trim();

                if (strValue.HasValue() == false) return defaultValue;
            }

#if DEBUG
            GodError.Check((Value as ICantToValueType) != null, "检测到要将不可转换为值类型(ICantToValueType)的对象转换为值类型,请检查代码!");
#endif
            double retVal = defaultValue;

            if (strValue != null)
            {
                if (double.TryParse(strValue, NumberStyles.Any, CultureInfo.CurrentCulture, out retVal))
                {
                    if (double.IsNaN(retVal) || double.IsInfinity(retVal) || double.IsNegativeInfinity(retVal) ||
                        double.IsPositiveInfinity(retVal))
                    {
                        return defaultValue;
                    }
                    return retVal;
                }
                else return defaultValue;
            }

            //最后，调用 ConvertFrom 和 ConvertTo 方法。忽略四舍五入。
            var cov = changeType(typeof(double), Value, null);
            if (cov.IsDBNull()) return defaultValue;
            else return (double)cov;
        }


        /// <summary>
        /// 得到对象的 DateTime 类型的值
        /// </summary>
        /// <param name="Value">要转换的值</param>
        /// <param name="defaultValue">如果转换失败，返回的默认值</param>
        /// <returns>如果对象的值可正确返回， 返回对象转换的值 ，否则， 返回默认值 。</returns>
        public static DateTime AsDateTime(this object Value, DateTime defaultValue)
        {
            if (Value.IsDBNull()) return defaultValue;

            var dtValue = Value as DateTime?;
            if (dtValue.HasValue) return dtValue.Value;


            var strValue = Value as string;
            if (strValue == null)
            {
                if (Value is IConvertible)
                {
                    DateTime retVal = (Value as IConvertible).ToDateTime(CultureInfo.CurrentCulture);
                    return retVal.HasValue() ? retVal : defaultValue;
                }
                else
                {
#if DEBUG
                    GodError.Check((Value as ICantToValueType) != null, "检测到要将不可转换为值类型(ICantToValueType)的对象转换为值类型,请检查代码!");
#endif
                }
            }
            else
            {
                strValue = strValue.Trim();
                if (strValue.HasValue() == false) return defaultValue;

                strValue = strValue
                    .Replace("年", "-")
                    .Replace("月", "-")
                    .Replace("日", "-")
                    .Replace("点", ":")
                    .Replace("时", ":")
                    .Replace("分", ":")
                    .Replace("秒", ":")
                    ;

                //补全 MyDate 的秒。
                if (strValue.Count(o => o == ':') == 1)
                {
                    strValue += ":00";
                }

                DateTime dt = defaultValue;
                if (DateTime.TryParse(strValue, out dt))
                {
                    return dt;
                }
                else return defaultValue;
            }


            //最后，调用 ConvertFrom 和 ConvertTo 方法。忽略四舍五入。
            var cov = changeType(typeof(DateTime), Value, null);
            if (cov.IsDBNull()) return defaultValue;
            else return (DateTime)cov;

        }


        /// <summary>
        /// 用它和 default(T) 进行比较，如果等于默认值，则返回false, 否则:
        /// 1. 时间最小值 ,返回 false
        /// 2. float 非法值 最小值 ,返回 false
        /// 3. dbouble 非法值 最小值,返回false
        /// 4. decimal 最小值, 返回 false
        /// 5. ICollection , IEnumerable  0长度，返回 false
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static bool HasValue<T>(this T Value)
        {
            Type type = typeof(T);
            if (type.IsEnum == false && (object.Equals(Value, default(T)) || Value.Equals(default(T)))) return false;
            if (object.Equals(Value, DBNull.Value)) return false;

            if (type.IsNullableType())
            {
                type = Nullable.GetUnderlyingType(type);

                var defValue = ValueProc.GetDefaultValue(type);
                if (type.IsEnum == false && (object.Equals(Value, defValue) || Value.Equals(defValue))) return false;
            }


            if (type.IsClass)
            {
                var strVal = Value as string;
                if (strVal != null)
                {
                    return !string.IsNullOrEmpty(strVal);
                }


                var collVal = Value as ICollection;
                if (collVal != null)
                {
                    return collVal.Count > 0;
                }

                var enmVal = Value as IEnumerable;
                if (enmVal != null)
                {
                    var d = enmVal.GetEnumerator();

                    if (d.MoveNext()) return true;
                    else return false;
                }
            }


            if (type.IsEnum)
            {
                return EnumHelper.GetDefault(type).AsInt() != Convert.ToInt32(Value);
            }
            else if (type.FullName == "System.Enum")
            {
                return EnumHelper.GetDefault(Value.GetType()).AsInt() != Convert.ToInt32(Value);
            }


            if (type.FullName == "System.Single")
            {
                var nval = (Value as float?);
                if (nval.HasValue == false) return false;

                if (nval.Value == float.NaN ||
                    nval.Value == float.MinValue ||
                    nval.Value == float.NegativeInfinity ||
                    nval.Value == float.PositiveInfinity)
                {
                    return false;
                }
            }
            else if (type.FullName == "System.Double")
            {
                var nval = (Value as double?);
                if (nval.HasValue == false) return false;

                if (nval.Value == double.NaN ||
                    nval.Value == double.MinValue ||
                    nval.Value == double.NegativeInfinity ||
                    nval.Value == double.PositiveInfinity)
                {
                    return false;
                }
            }
            else if (type.FullName == "System.Decimal")
            {
                var nval = (Value as decimal?);
                if (nval.HasValue == false) return false;

                if (nval.Value == decimal.MinValue)
                {
                    return false;
                }
            }
            else if (type.FullName == "System.DateTime")
            {
                var nval = (Value as DateTime?);
                if (nval.HasValue == false) return false;

                if (nval.Value == DateTime.MinValue)
                {
                    return false;
                }
            }
            else if (type.FullName == "MyCmn.MyDate")
            {
                var nval = (Value as MyDate?);
                if (nval.HasValue == false) return false;

                if (nval.Value == DateTime.MinValue)
                {
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="guidValue"></param>
        /// <returns></returns>
        public static Guid AsGuid(this string guidValue)
        {
            if (guidValue.HasValue() == false) return Guid.Empty;

            try
            {
                return new Guid(guidValue);
            }
            catch
            {
                return Guid.Empty;
            }
        }

        public static short AsShortInt(this object Value, short defaultValue, bool Rounding)
        {
            if (Value.IsDBNull()) return defaultValue;

            {
                var lngValue = Value as short?;
                if (lngValue.HasValue) return lngValue.Value;
            }
            {
                var val = Value as int?;
                if (val.HasValue) return (short)val.Value;
            }

            var strValue = Value as string;

            if (strValue != null)
            {
                //strValue = strValue.Trim();

                if (strValue.HasValue() == false) return defaultValue;
            }


#if DEBUG
            GodError.Check((Value as ICantToValueType) != null, "检测到要将不可转换为值类型(ICantToValueType)的对象转换为值类型,请检查代码!");
#endif

            if (strValue != null)
            {
                if (strValue.Contains('.'))
                {
                    //如果有小数点, 或 E , 则先调用 AsDecimal 再..
                    return (short)AsInt(Value, defaultValue, Rounding);
                }

                short retVal = defaultValue;
                if (short.TryParse(strValue, NumberStyles.Any, CultureInfo.CurrentCulture, out retVal))
                {
                    return retVal;
                }
                else return defaultValue;
            }
            else
            {
                var convValue = Value as IConvertible;
                if (convValue != null)
                {
                    return convValue.ToInt16(CultureInfo.CurrentCulture);
                }
            }

            //最后，调用 ConvertFrom 和 ConvertTo 方法。忽略四舍五入。
            var cov = changeType(typeof(short), Value, null);
            if (cov.IsDBNull()) return defaultValue;
            else return (short)cov;
        }


        /// <summary>
        /// 找该类或基类的泛型类。
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type getGenericType(this Type type)
        {
            if (type == null) return null;
            if (type.IsGenericType) return type;
            else return getGenericType(type.BaseType);
        }


        /// <summary>
        /// 判断是否是 枚举类。
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsIEnm(this Type type)
        {
            return type.GetInterface("MyCmn.IEnm") != null;
        }


        public static object GetDefaultValue(this Type type)
        {
            return typeof(ValueProc)
                .GetMethod("Get_DefaultValue", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                .MakeGenericMethod(type)
                .Invoke(null, null);
        }

        private static T Get_DefaultValue<T>()
        {
            return default(T);
        }


        public static object NewWithType(this Type type)
        {
            return typeof(ValueProc).GetMethod("Create_WithType").MakeGenericMethod(type)
                .Invoke(null, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static, null, null, CultureInfo.CurrentCulture);
        }

        private static T Create_WithType<T>() where T : new()
        {
            return new T();
        }
    }
}