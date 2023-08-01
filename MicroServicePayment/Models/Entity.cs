using System;
using System.Collections.Generic;

namespace MicroServicePayment.Models;

public partial class Entity
{
    public long Pk { get; set; }

    public DateTime? Cdate { get; set; }

    public string? Cuser { get; set; }

    public string? Uuser { get; set; }

    public string? Centralbankcode { get; set; }

    public string Code { get; set; } = null!;

    public DateTime? Datefield1 { get; set; }

    public DateTime? Datefield2 { get; set; }

    public DateTime? Datefield3 { get; set; }

    public string? Description { get; set; }

    public string Entitycategorycode { get; set; } = null!;

    public long Entitycategorypk { get; set; }

    public string? Fiscalresidencecode { get; set; }

    public long? Fiscalresidencepk { get; set; }

    public string? Fullname { get; set; }

    public string Identifier { get; set; } = null!;

    public string? Identifier2 { get; set; }

    public string? Migstate { get; set; }

    public string? Nationalitycode { get; set; }

    public long? Nationalitypk { get; set; }

    public bool? Notresident { get; set; }

    public long? Professionalactivitypk { get; set; }

    public string? Residencecode { get; set; }

    public long? Residencepk { get; set; }

    public bool? Resident { get; set; }

    public DateTime? Socialaffiliationdate { get; set; }

    public string? Socialaffiliationnum { get; set; }

    public string? Soundex { get; set; }

    public string? Stringfield1 { get; set; }

    public string? Stringfield2 { get; set; }

    public string? Stringfield3 { get; set; }

    public string? Stringfield4 { get; set; }

    public string? Stringfield5 { get; set; }

    public string? Stringfield6 { get; set; }

    public string? Stringfield7 { get; set; }

    public string? Translatedname { get; set; }

    public string Type { get; set; } = null!;

    public DateTime? Udate { get; set; }

    public int? Versionnum { get; set; }

    public string? Branch { get; set; }

    public bool? Withanomaly { get; set; }

    public long? Ccppk { get; set; }

    public long? Crepk { get; set; }

    public string? Inscode { get; set; }

    public bool? Bl { get; set; }

    public bool? Gc { get; set; }

    public bool? Ppe { get; set; }

    public string? Labft { get; set; }

    public bool? Assaini { get; set; }

    public bool? Validatedbyjurdical { get; set; }

    public string? Riskcode { get; set; }

    public string? Riskcodebc { get; set; }

    public long? Officialmailpk { get; set; }

    public bool? Decbctrisk { get; set; }

    public string? Otherfunctionsppe { get; set; }

    public long? Ppefunctionpk { get; set; }

    public bool? Draft { get; set; }

    public bool? Forbiddenaccount { get; set; }

    public bool? Isvalidated { get; set; }

    public bool? Prospect { get; set; }

    public bool? Isarchived { get; set; }

    public virtual ICollection<Nternalaccount> Nternalaccounts { get; set; } = new List<Nternalaccount>();
}
