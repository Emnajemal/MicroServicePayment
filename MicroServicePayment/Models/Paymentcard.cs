using System;
using System.Collections.Generic;

namespace MicroServicePayment.Models;

public partial class Paymentcard
{
    public long Pk { get; set; }

    public DateTime? Cdate { get; set; }

    public string? Cuser { get; set; }

    public string? Uuser { get; set; }

    public string Accountcode { get; set; } = null!;

    public long Accountpk { get; set; }

    public string Cardsproductcode { get; set; } = null!;

    public long Cardsproductpk { get; set; }

    public decimal? Celling { get; set; }

    public string Code { get; set; } = null!;

    public string Currencycode { get; set; } = null!;

    public long Currencypk { get; set; }

    public DateTime? Deliverydate { get; set; }

    public DateTime? Expirydate { get; set; }

    public decimal? Maxgab { get; set; }

    public decimal? Maxtpe { get; set; }

    public string? Periodicity { get; set; }

    public string Reference { get; set; } = null!;

    public bool? Renewable { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? Transitiondate { get; set; }

    public DateTime? Udate { get; set; }

    public int? Versionnum { get; set; }

    public string? Cancelreason { get; set; }

    public string? Cardnumber { get; set; }

    public string? Confidentialcode { get; set; }

    public string? Delivereraddress { get; set; }

    public string? Delivererfirstname { get; set; }

    public string? Delivereriddocument { get; set; }

    public string? Delivereridtypecode { get; set; }

    public long? Delivereridtypepk { get; set; }

    public string? Delivererlastname { get; set; }

    public string? Deliverermail { get; set; }

    public string? Deliverertel { get; set; }

    public string? Deliverertype { get; set; }

    public decimal? Overdraftamount { get; set; }

    public string? Category { get; set; }

    public bool? Torenew { get; set; }

    public bool? Injected { get; set; }

    public bool? Isprepaid { get; set; }

    public bool? Withcommission { get; set; }

    public bool? Enroled { get; set; }

    public string? Numotp { get; set; }

    public virtual Accountcontract AccountpkNavigation { get; set; } = null!;
}
