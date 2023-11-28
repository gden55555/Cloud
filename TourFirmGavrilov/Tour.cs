//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TourFirmGavrilov
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tour()
        {
            this.Orders = new ObservableListSource<Order>();
        }
    
        public int tourId { get; set; }
        public string name { get; set; }
        public Nullable<int> guidesId { get; set; }
        public Nullable<int> citiesId { get; set; }
        public Nullable<double> price { get; set; }
        public Nullable<System.DateTime> tourDate { get; set; }
        public Nullable<int> tourDuration { get; set; }
    
        public virtual City City { get; set; }
        public virtual Guide Guide { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableListSource<Order> Orders { get; set; }
    }
}