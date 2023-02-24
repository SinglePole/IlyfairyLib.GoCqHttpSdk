using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Models.Shared;

public interface IGroupInfo
{
    public GroupInfo GroupInfo { get; init; }
    public long GroupId { get; init; }
}
