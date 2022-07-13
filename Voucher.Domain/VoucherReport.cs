using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.Domain
{
    public class VoucherReport
    {
        public string? Base {get; set;}
        public string? Dest { get; set; }
        public DateTime? DtVoo { get; set; }
        public string NVoucher { get; set; }
        public StatusType Status { get; set; }
        public DateTime? DtCnl { get; set; }
        public string Tipo { get; set; }
        public float Valor { get; set; }
        public string Fornecedor { get; set; }
        public string Loc_Pnr { get; set; }
        public string Cliente { get; set; }

    }
}
