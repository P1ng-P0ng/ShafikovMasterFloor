//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShafikovMasterFloor
{
    using System;
    using System.Collections.Generic;
    
    public partial class StorageMaterial
    {
        public int StorageMaterialID { get; set; }
        public int MaterialID { get; set; }
        public int SupplierID { get; set; }
        public System.DateTime StorageMaterialDate { get; set; }
        public int StorageMaterialCount { get; set; }
        public int AdmissionOrOutput { get; set; }
    
        public virtual AdmissionOrOutput AdmissionOrOutput1 { get; set; }
        public virtual Material Material { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
