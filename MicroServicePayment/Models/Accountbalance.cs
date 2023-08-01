using System;
using System.Collections.Generic;

namespace MicroServicePayment.Models;

public partial class Accountbalance
{
    public long Pk { get; set; }

    public DateTime? Cdate { get; set; }

    public string? Cuser { get; set; }

    public string? Uuser { get; set; }

    public string Accountcode { get; set; } = null!;

    public long Accountpk { get; set; }

    public decimal Balance { get; set; }

    public string Balancetype { get; set; } = null!;

    public decimal? Creditmvt { get; set; }

    public string Currencycode { get; set; } = null!;

    public long Currencypk { get; set; }

    public decimal? Debitmvt { get; set; }

    public DateTime Enddate { get; set; }

    public decimal? Lockamount { get; set; }

    public decimal? Overdraftamount { get; set; }

    public DateTime Positiondate { get; set; }

    public DateTime? Udate { get; set; }

    public int? Versionnum { get; set; }

    public virtual Accountcontract AccountpkNavigation { get; set; } = null!;
}
