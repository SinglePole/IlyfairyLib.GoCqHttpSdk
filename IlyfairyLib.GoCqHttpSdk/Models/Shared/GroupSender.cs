using Newtonsoft.Json.Linq;
using System;

namespace IlyfairyLib.GoCqHttpSdk.Models.Shared;

public record GroupSender : Sender
{
    private GroupSender(int age, string name, long id, Sex sex, string cardName, string level, Role role, string title, string area) : base(age, name, id, sex)
    {
        CardName = cardName;
        Level = level;
        Role = role;
        Title = title;
        Area = area;
    }

    /// <summary>
    /// 群名片
    /// </summary>
    public string CardName { get; init; }
    /// <summary>
    /// 成员等级
    /// </summary>
    public string Level { get; init; }
    /// <summary>
    /// 群员身份
    /// </summary>
    public Role Role { get; init; }
    /// <summary>
    /// 专属头衔
    /// </summary>
    public string Title { get; init; }
    /// <summary>
    /// 地区
    /// </summary>
    public string Area { get; init; }

    internal new static GroupSender? Get(JToken json)
    {
        try
        {
            var area = json.Value<string>("area") ?? "";
            var card = json.Value<string>("card") ?? "";
            var level = json.Value<string>("level") ?? "";
            var role = json.Value<string>("role") ?? "";
            var title = json.Value<string>("title") ?? "";

            var old = Sender.Get(json);

            GroupSender sender = new(
                old.Age,
                old.Name,
                old.Id,
                old.Sex,
                card == "" ? old.Name : card,
                level,
                role switch
                {
                    "owner" => Role.Owner,
                    "admin" => Role.Admin,
                    "member" => Role.Member,
                    _ => Role.Member
                },
                title,
                area
            );
            return sender;
        }
        catch (Exception)
        {
            return null;
        }
    }
}
