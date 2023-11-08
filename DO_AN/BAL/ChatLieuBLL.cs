using DO_AN.DAL;
using DO_AN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN.BAL
{
    internal class ChatLieuBLL
    {
        ChatLieuDAL dal = new ChatLieuDAL();
        public List<ChatLieu> ReadChatLieu()
        {
            List<ChatLieu> lstCus = dal.ReadChatLieu();
            return lstCus;
        }
        public void NewChatLieu(ChatLieu cus)
        {
            dal.NewChatLieu(cus);
        }
        public void DeleteChatLieu(ChatLieu cus)
        {
            dal.DeleteChatLieu(cus);
        }
        public void EditChatLieu(ChatLieu cus)
        {
            dal.EditChatLieu(cus);
        }
        public void LuuChatLieu(ChatLieu cus)
        {
            dal.LuuChatLieu(cus);
        }
    }
}
