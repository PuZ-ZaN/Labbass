using System;

namespace Labbass_Laba0
{
    internal interface ILab
    {
        //string LabID; для Equals, что бы сообщать если подгрузили две одинаковые лабы
        void Show();
        event EventHandler Shown;
    }
}
