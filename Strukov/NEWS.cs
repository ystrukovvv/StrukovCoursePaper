//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Strukov
{
    using System;
    using System.Collections.Generic;
    
    public partial class NEWS
    {
        public int id { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public int AuthorId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public byte[] Image { get; set; }
    
        public virtual AUTHOR AUTHOR { get; set; }
    }
}
