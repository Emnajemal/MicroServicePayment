using System;
using System.Collections.Generic;

namespace MicroServicePayment.Models;

public partial class Productservice
{
    public long Pk { get; set; }

    public DateTime? Cdate { get; set; }

    public string? Cuser { get; set; }

    public string? Uuser { get; set; }

    public string? Abreviation { get; set; }

    public DateTime Activationdate { get; set; }

    public bool? Applyfiscalretention { get; set; }

    public bool Available { get; set; }

    public string? Cbcategorycode { get; set; }

    public long? Cbcategorypk { get; set; }

    public string Code { get; set; } = null!;

    public string? Description { get; set; }

    public bool Draft { get; set; }

    public DateTime? Enddate { get; set; }

    public bool? Expired { get; set; }

    public long? Ficheproductpk { get; set; }

    public string? Freetext { get; set; }

    public string Identifier { get; set; } = null!;

    public string? Internalcode { get; set; }

    public bool? Isathorizedoperationempty { get; set; }

    public bool? Islimiteempty { get; set; }

    public string? Name { get; set; }

    public bool? Offeredonce { get; set; }

    public string Productcategorycode { get; set; } = null!;

    public long Productcategorypk { get; set; }

    public long? Renewablerequestdelay { get; set; }

    public string? Revisionperiodicity { get; set; }

    public string? Risklevel { get; set; }

    public string? Translatedname { get; set; }

    public string Type { get; set; } = null!;

    public DateTime? Udate { get; set; }

    public string? Validationprocessname { get; set; }

    public string? Validationstepname { get; set; }

    public long? Vendorincentivespk { get; set; }

    public int? Versionnum { get; set; }

    public string? Prefixan { get; set; }

    public bool? Internal { get; set; }

    public string? Serial { get; set; }

    public string? Shortname { get; set; }

    public decimal? Weightingrate { get; set; }
}
