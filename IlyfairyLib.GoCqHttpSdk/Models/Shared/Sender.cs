using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlyfairyLib.GoCqHttpSdk.Models.Shared
{
    public record Sender
    {
        protected Sender(int age, string name, long id, Sex sex)
        {
            Age = age;
            Name = name;
            Id = id;
            Sex = sex;
        }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; init; }
        /// <summary>
        /// QQ昵称
        /// </summary>
        public string Name { get; init; }
        /// <summary>
        /// QQ号
        /// </summary>
        public long Id { get; init; }
        /// <summary>
        /// 性别
        /// </summary>
        public Sex Sex { get; init; }

        internal static Sender Get(JToken json)
        {
            var age = json.Value<int>("age");
            var nickname = json.Value<string>("nickname") ?? "";
            var sex = json.Value<string>("sex");
            var user_id = json.Value<long>("user_id");

            Sender sender = new(
                age,
                nickname,
                user_id,
                sex switch
                {
                    "male" => Sex.Male,
                    "female" => Sex.Female,
                    _ => Sex.Unknow,
                }
            );
            return sender;
        }
    }
}
