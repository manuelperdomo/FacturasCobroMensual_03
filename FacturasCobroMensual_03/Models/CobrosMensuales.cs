//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FacturasCobroMensual_03.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CobrosMensuales
    {
        public int IDCobroMensual { get; set; }
        public Nullable<int> IDResidente { get; set; }
        public System.DateTime Mes { get; set; }
        public decimal MontoAPagar { get; set; }
        public decimal MontoPagado { get; set; }
        public decimal DeudaAnterior { get; set; }
    
        public virtual Residentes Residentes { get; set; }
        public virtual Residentes Residentes1 { get; set; }
    }
}