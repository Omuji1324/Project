﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Configuration
{
    public class OrderConfig
    {
        public enum Status
        {
            WAIT = 1,
            CONFIRM = 2,
            CANCEL = 3,
            SHIP = 4,
            FINISH = 5,
            ISDELETE = 1,
            WAITFORPAY = 0,
        }
        public static Dictionary<int, string> StatusToDictionaryHTML = new Dictionary<int, string>()
        {
            {-1, "Tất cả" },
           // {(int)Status.WAITFORPAY, "Chờ thanh toán" },
            {(int)Status.WAIT, "Chờ xử lý" },
            {(int)Status.CONFIRM, "Xác nhận" },
            {(int)Status.FINISH, "Hoàn thành" },
           {(int)Status.CANCEL, "Hủy" },
        };
        public static Dictionary<int, string> StatusToDictionaryALL = new Dictionary<int, string>()
        {
            {(int)Status.WAIT, "Chờ xử lý" },
            {(int)Status.CONFIRM, "Xác nhận" },
            {(int)Status.FINISH, "Hoàn thành" },
           {(int)Status.CANCEL, "Hủy" },
        };
        public static Dictionary<int, string> StatusToDictionaryWAIT = new Dictionary<int, string>()
        {
            {(int)Status.WAIT, "Chờ xử lý" },
            {(int)Status.CONFIRM, "Xác nhận" },
           {(int)Status.CANCEL, "Hủy" },
        };
        public static Dictionary<int, string> StatusToDictionaryCONFIRM = new Dictionary<int, string>()
        {
            {(int)Status.CONFIRM, "Xác nhận" },
            {(int)Status.FINISH, "Hoàn thành" },
            {(int)Status.CANCEL, "Hủy" },
        };
        public static Dictionary<int, string> StatusToDictionaryFINISH = new Dictionary<int, string>()
        {
            {(int)Status.FINISH, "Hoàn thành" },
                 {(int)Status.CANCEL, "Hủy" },
        };
        public enum Pay
        {
            PAID = 1,
            UNPAID = 0,
        }
        public static Dictionary<int, string> StatusToDictionaryPayHTML = new Dictionary<int, string>()
        {
            {(int)Pay.UNPAID, "Chưa thanh toán" },
            {(int)Pay.PAID, "Đã thanh toán" },
        };
    }
}
