//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AguilaDoradaWeb
{
    using System;
    using System.Collections.Generic;
    
    public partial class CuentasBancariasDepo
    {
        public int Id { get; set; }
        public Nullable<int> IdAgencia { get; set; }
        public string IdUser { get; set; }
        public Nullable<int> IdCuentasBancarias { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<decimal> Monto { get; set; }
        public Nullable<decimal> Saldo { get; set; }
        public string Observaciones { get; set; }
        public Nullable<int> LiquidacionId { get; set; }
    }
}