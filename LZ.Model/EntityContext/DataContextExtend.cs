using common.Tools;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LZ.Model.EntityContext
{
    public static class DataContextExtend
    {

        public static List<T> SqlQuery<T>(this DatabaseFacade facade, string sql, params object[] parameters)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"]))
            {
                conn.Open();
                var ds = new DataSet();
                using (var da = new SqlDataAdapter(sql, conn))
                {
                    if (parameters.Any())
                    {
                        da.SelectCommand.Parameters.AddRange(parameters);
                    }
                    da.Fill(ds);
                }

                conn.Close();
                if (ds.Tables.Count > 0)
                {
                    //return ds.Tables[0].ToEnumerable<T>();
                    return ToDataList<T>(ds.Tables[0]);
                }
                else
                {
                    return new List<T>();
                }
            }

        }
        /// <summary>
        /// 返回首行首列
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="facade"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static T SqlCount<T>(this DatabaseFacade facade, string sql, params object[] parameters)
        {
            using (var conn = new SqlConnection(facade.GetDbConnection().ConnectionString))
            {
                conn.Open();
                T result;
                var ds = new DataSet();

                using (var commend = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        if (parameters.Any())
                            commend.Parameters.AddRange(parameters);
                    }
                    result = (T)commend.ExecuteScalar();
                }

                conn.Close();

                return result;

            }

        }





        /// <summary>
        /// DataTable转成List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ToDataList<T>(this DataTable dt)
        {
            var list = new List<T>();
            var plist = new List<PropertyInfo>(typeof(T).GetProperties());
            if (typeof(T) == typeof(string))
            {
                foreach (DataRow givenObject in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (givenObject[i] != DBNull.Value && givenObject[i] != null)
                        {
                            var instance = givenObject[i].ToString();  // Your custom conversion to string.
                            list.Add((T)(object)instance);
                        }
                        else
                        {
                            list.Add((T)(object)null);
                        }
                    }
                }
            }
            else if (typeof(T).IsClass)
            {
                foreach (DataRow item in dt.Rows)
                {
                    T s = Activator.CreateInstance<T>();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        PropertyInfo info = plist.Find(p => p.Name.ToUpper() == dt.Columns[i].ColumnName.ToUpper());
                        if (info != null)
                        {
                            try
                            {
                                if (!Convert.IsDBNull(item[i]))
                                {
                                    object v = null;
                                    if (info.PropertyType.ToString().Contains("System.Nullable"))
                                    {
                                        v = Convert.ChangeType(item[i], Nullable.GetUnderlyingType(info.PropertyType));
                                    }
                                    else
                                    {
                                        if (info.PropertyType.BaseType != null && info.PropertyType.BaseType.ToString().Contains("System.Enum"))
                                        {
                                            //将字符串转换为枚举对象
                                            //v = Enum.Parse(info.PropertyType, item[i].ToString());
                                            v = int.Parse(item[i].ToString());
                                        }
                                        else
                                        {
                                            v = Convert.ChangeType(item[i], info.PropertyType);
                                        }
                                    }
                                    info.SetValue(s, v, null);
                                }
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("字段[" + info.Name + "]转换出错," + ex.Message);
                            }
                        }
                    }
                    list.Add(s);
                }
            }
            else if (typeof(T).BaseType == typeof(System.ValueType))
            {
                try
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            if (item[i] != DBNull.Value && item[i] != null)
                            {
                                if (plist.Count > 0)
                                {

                                    Type t = plist.LastOrDefault()?.PropertyType;
                                    if (t.ToString() != "System.Boolean")
                                    {
                                        list.Add((T)((object)Convert.ChangeType(item[i], t)));
                                    }
                                    else
                                    {
                                        list.Add((T)item[i]);
                                    }


                                }
                                else
                                {
                                    if (item[i].GetType().ToString() == "System.Int64" && typeof(T).FullName == "System.Int32")
                                    {
                                        list.Add((T)((object)int.Parse(item[i].ToString())));
                                    }
                                    else
                                    {
                                        list.Add((T)((object)item[i]));
                                    }
                                }
                            }
                            else
                            {
                                list.Add((T)(object)null);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("类型[" + typeof(T) + "]转换出错,item[i] 转换成 " + plist.LastOrDefault()?.PropertyType.ToString() + Environment.NewLine + ex.Message);
                }
            }
            return list;
        }
        /// <summary>
        /// 将DataTable转换为IEnumerable的强类型对象
        /// </summary>
        /// <typeparam name="T">要转换为的强类型</typeparam>
        /// <param name="table">要转换的DataTable对象</param>
        /// <returns>转换后的IEnumerable的强类型对象</returns>
        public static List<T> ToEnumerable<T>(this DataTable table)
        {
            List<T> list = new List<T>();
            PropertyInfo[] piArr = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (DataRow row in table.Rows)
            {
                var obj = Activator.CreateInstance<T>();
                FillObject(obj, row, piArr);
                list.Add(obj);
            }
            return list;
        }


        //用row的栏填充obj
        public static void FillObject<T>(T obj, DataRow row, PropertyInfo[] piArr)
        {
            foreach (var pi in piArr)
            {
                try
                {
                    if (row.Table.Columns.Contains(pi.Name) && !(row[pi.Name] is DBNull))
                    {
                        pi.SetValue(obj, row[pi.Name]);
                    }
                }
                catch (Exception ex)
                {
                    //LogHelper.Error("数据转换异常" + pi.Name + ":" + row[pi.Name].ToString() + Environment.NewLine + ex.Message);
                }
            }
        }




    }
}
