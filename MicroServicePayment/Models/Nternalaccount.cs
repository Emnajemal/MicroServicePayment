using System;
using System.Collections.Generic;

namespace MicroServicePayment.Models;

public partial class Nternalaccount
{
    public long Ownerpk { get; set; }

    public long Internalaccountspk { get; set; }

    public virtual Entity OwnerpkNavigation { get; set; } = null!;
}
