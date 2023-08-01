using System;
using System.Collections.Generic;

namespace MicroServicePayment.Models;

public partial class Accountcontract
{
    public string? Accountcode { get; set; }

    public bool? Accountmig { get; set; }

    public string Accountnumber { get; set; } = null!;

    public long? Accountpk { get; set; }

    public string? Addinfo1 { get; set; }

    public string? Addinfo2 { get; set; }

    public string? Addinfo3 { get; set; }

    public string? Addinfo4 { get; set; }

    public long? Clientpouvoirpk { get; set; }

    public DateTime? Closingdate { get; set; }

    public string? Comissionaccountcode { get; set; }

    public long? Comissionaccountpk { get; set; }

    public bool? Frozen { get; set; }

    public long Inactivityperiodpk { get; set; }

    public string? Linckedaccountcode { get; set; }

    public long? Linckedaccountpk { get; set; }

    public bool Locked { get; set; }

    public string? Settlementaccountcode { get; set; }

    public long? Settlementaccountpk { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? Transitiondate { get; set; }

    public long? Validationprocesspk { get; set; }

    public long Pk { get; set; }

    public bool? Generatereleve { get; set; }

    public bool? Generatesettlreport { get; set; }

    public bool? Maxima { get; set; }

    public string? Codebp { get; set; }

    public string? Categorie { get; set; }

    public string? Countrybpcode { get; set; }

    public long? Countrybppk { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public DateTime? Addinfo5 { get; set; }

    public DateTime? Addinfo6 { get; set; }

    public bool? Electionpresidentielle { get; set; }

    public string? Davepackagecode { get; set; }

    public long? Davepackagepk { get; set; }

    public DateTime? Frozendate { get; set; }

    public bool? Generateafbreleve { get; set; }

    public bool? Generateswiftreleve { get; set; }

    public string? Numcpt7 { get; set; }

    public string? Technicalaccountcode { get; set; }

    public long? Technicalaccountpk { get; set; }

    public string? Swiftreleveaddress { get; set; }

    public string? Swiftrelevetype { get; set; }

    public string? Swiftrelevesequence { get; set; }

    public string? Addinfo7 { get; set; }

    public bool? Freezecredit { get; set; }

    public bool? Freezeregulatory { get; set; }

    public bool? Inactivecredit { get; set; }

    public bool? Inactivedebit { get; set; }

    public string? Creationaccountcode { get; set; }

    public long? Creationaccountpk { get; set; }

    public string? Objectrelationcode { get; set; }

    public long? Objectrelationpk { get; set; }

    public string? Otherobjectrelation { get; set; }

    public string? Pendingaccountcode { get; set; }

    public long? Pendingaccountpk { get; set; }

    public bool? Freezedebit { get; set; }

    public string? Origincreation { get; set; }

    public bool? Confiscated { get; set; }

    public string? Linkedaccountpackage { get; set; }

    public DateTime? Dateentrypackage { get; set; }

    public virtual ICollection<Accountbalance> Accountbalances { get; set; } = new List<Accountbalance>();

    public virtual Account? AccountpkNavigation { get; set; }

    public virtual Accountcontract? ComissionaccountpkNavigation { get; set; }

    public virtual ICollection<Accountcontract> InverseComissionaccountpkNavigation { get; set; } = new List<Accountcontract>();

    public virtual ICollection<Accountcontract> InverseLinckedaccountpkNavigation { get; set; } = new List<Accountcontract>();

    public virtual ICollection<Accountcontract> InversePendingaccountpkNavigation { get; set; } = new List<Accountcontract>();

    public virtual ICollection<Accountcontract> InverseTechnicalaccountpkNavigation { get; set; } = new List<Accountcontract>();

    public virtual Accountcontract? LinckedaccountpkNavigation { get; set; }

    public virtual ICollection<Paymentcard> Paymentcards { get; set; } = new List<Paymentcard>();

    public virtual Accountcontract? PendingaccountpkNavigation { get; set; }

    public virtual Accountcontract? TechnicalaccountpkNavigation { get; set; }
}
