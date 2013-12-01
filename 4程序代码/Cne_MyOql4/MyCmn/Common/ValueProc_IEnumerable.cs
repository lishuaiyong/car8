
using System.Collections.Generic;
using System;
using System.Linq;

namespace MyCmn
{
    public static partial class ValueProc
    {
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> source, Func<T, T, bool> Comparer)
        {
            return source.Distinct(new CommonEqualityComparer<T>(Comparer));
        }

        /// <summary>
        /// ���������һ��ֵ��
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="data"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> AddOne<TSource>(this IEnumerable<TSource> data, TSource Value)
        {
            if (data == null) return new TSource[1] { Value };
            return data.Concat(new TSource[1] { Value });
        }

        /// <summary>
        /// ���ϼ���.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="data"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Minus<TSource>(this IEnumerable<TSource> data, IEnumerable<TSource> other)
        {
            if (other != null)
            {
                return data.Where(o => (o.IsIn(other.ToArray()) == false));
            }
            else return data;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="data"></param>
        /// <param name="otherFunc">����true ��ʾ��ȣ�Ҫ��ȥ������false ������</param>
        /// <returns></returns>
        public static IEnumerable<TSource> Minus<TSource>(this IEnumerable<TSource> data, Func<TSource, bool> otherFunc)
        {
            if (otherFunc != null)
            {
                return data.Where(o => !otherFunc(o));
            }
            else return data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="equalFunc"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static bool Contains<TSource>(this IEnumerable<TSource> data, Func<TSource, bool> equalFunc)
        {
            return !data.All(o => !equalFunc(o));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="startIndex"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TSource> Slice<TSource>(this IEnumerable<TSource> source, int startIndex)
        {
            return Slice<TSource>(source, startIndex, int.MaxValue);
        }

        /// <summary>
        /// 
        ///������ javascript.slice �� ȡ�����ϵ�һ���� new int[1,2,3].Slice(0,2) ���� [1,2]
        /// </summary>
        /// <remarks>
        /// slice ����һֱ���Ƶ� end ��ָ����Ԫ�أ����ǲ�������Ԫ�ء�
        /// ��� start Ϊ����������Ϊ length + start�����˴� length Ϊ����ĳ��ȡ�
        /// ��� end Ϊ�����ͽ�����Ϊ length + end �����˴� length Ϊ����ĳ��ȡ�
        /// ���ʡ�� end ����ô slice ������һֱ���Ƶ� arrayObj �Ľ�β��
        /// ��� end ������ start ֮ǰ���������κ�Ԫ�ص��������С�
        /// ʾ��:
        /// <code>
        ///  new int[1,2,3].Slice(0,-1) ���� 1,2
        ///  new int[1,2,3].Slice(1,0)  ���� ��.
        ///  new int[1,2,3].Slice(-100,2) ���� 1,2
        ///  new int[1,2,3].Slice(-2,-1) ���� 3
        /// </code>
        /// </remarks>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="startIndex"> ��ʾҪ��ȡ���ַ����Ŀ�ʼ���� . ��� start Ϊ����������Ϊ length + start�����˴� length Ϊ����ĳ��ȡ� </param>
        /// <param name="endIndex">
        /// ��ʾҪ��ȡ���ַ����Ľ�������,��������Ԫ��.
        /// ��� end Ϊ�����ͽ�����Ϊ length + end �����˴� length Ϊ����ĳ��ȡ�
        /// ���ʡ�� end ����ô slice ������һֱ���Ƶ� arrayObj �Ľ�β��
        /// ��� end ������ start ֮ǰ���������κ�Ԫ�ص��������С�
        /// </param>
        /// <returns></returns>
        public static IEnumerable<TSource> Slice<TSource>(this IEnumerable<TSource> source, int startIndex, int endIndex)
        {
            if (startIndex < 0) return Slice<TSource>(source, source.Count() + startIndex, endIndex);
            if (endIndex < 0) return Slice<TSource>(source, startIndex, source.Count() + endIndex);

            return source.Where((value, index) =>
            {
                return index >= startIndex && index < endIndex;
            });
        }
    }
}
