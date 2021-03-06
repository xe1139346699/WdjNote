﻿using System.Collections.Generic;
using Interface;
using Model;
using System.Data;
using System;

namespace SQLDAL
{
    public class SQLFileOperateImpl : ISQLFileOperate
    {
        public SFile OpenFile(int fno)
        {
            string sql = "select * from userfile where fno = " + fno;
            DataTable dt = SQLOperate.QueryTable(sql);

            SFile sf = null;
            if(dt.Rows.Count > 0)
                sf = new SFile(Convert.ToInt32(dt.Rows[0][0].ToString()),
                    dt.Rows[0][1].ToString().Trim(), dt.Rows[0][2].ToString().Trim(),
                    Convert.ToInt32(dt.Rows[0][3].ToString()),
                    Convert.ToInt32(dt.Rows[0][4].ToString()));

            return sf;
        }

        public List<SFile> ReadFileByCno(int cno, int uno)
        {
            string sql = "select * from userfile where fcno='" + cno + "'and funo='" + uno + "'";
            DataTable dt = SQLOperate.QueryTable(sql);

            List<SFile> sfList = new List<SFile>();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                SFile sf = new SFile(Convert.ToInt32(dt.Rows[i][0].ToString()),
                    dt.Rows[i][1].ToString().Trim(), dt.Rows[i][2].ToString().Trim(),
                    Convert.ToInt32(dt.Rows[i][3].ToString()),
                    Convert.ToInt32(dt.Rows[i][4].ToString()));
                sfList.Add(sf);
            }

            return sfList;
        }

        public int SaveFile(SFile f)
        {
            string sql = "insert into userfile(fname,fcontent,fcno,funo) values('" + f.Fname + "','" + f.Fcontent
                + "','" + f.Fcno + "','" + f.Funo + "')";
            return SQLOperate.ExecuteSql(sql);
        }

        public int DeleteFile(int fno)
        {
            string sql = "delete userfile where fno = '" + fno + "'";
            return SQLOperate.ExecuteSql(sql);
        }

        public MyFile SFileToMyFile(SFile sf, string username)
        {
            string sql = "select * from cate where cno = '" + sf.Fcno + "'";
            string cateName = SQLOperate.QueryTable(sql).Rows[0][2].ToString().Trim();

            MyFile mf = new MyFile();
            mf.Path = "D:\\WdjNote\\" + username + "\\" + cateName; 
            mf.Name = sf.Fname.Trim() + ".txt";
            mf.Content = sf.Fcontent.Trim();
            return mf;
        }
    }
}
