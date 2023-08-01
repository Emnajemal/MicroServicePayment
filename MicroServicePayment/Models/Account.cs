using System;
using System.Collections.Generic;

namespace MicroServicePayment.Models;

public partial class Account
{
    public long Pk { get; set; }

    public DateTime? Cdate { get; set; }

    public string? Cuser { get; set; }

    public string? Uuser { get; set; }

    public string? Accountnumber { get; set; }

    public DateTime? Activationdate { get; set; }

    public bool Active { get; set; }

    public string? Bankcode { get; set; }

    public long? Bankpk { get; set; }

    public string Code { get; set; } = null!;

    public string Currencycode { get; set; } = null!;

    public long Currencypk { get; set; }

    public string? Iban { get; set; }

    public bool Isinternalrib { get; set; }

    public string? Ownership { get; set; }

    public string Rib { get; set; } = null!;

    public string? Signaturetype { get; set; }

    public string? Unitcode { get; set; }

    public long? Unitpk { get; set; }

    public DateTime? Udate { get; set; }

    public int? Versionnum { get; set; }

    public string? Productcategorycode { get; set; }

    public string? Productcode { get; set; }

    public string? Fullname { get; set; }

    public virtual Accountcontract? Accountcontract { get; set; }
}
