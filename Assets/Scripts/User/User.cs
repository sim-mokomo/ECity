using MokomoGames.Protobuf;

namespace MokomoGames.Users
{
    public class User
    {
        public User(UserData data, uint maxFuel, uint needNextRankExp)
        {
            Stamina = data.Stamina;
            Yukichi = data.Yukichi;
            Coin = data.Coin;
            Mizu = data.Mizu;
            Rank = data.Rank;
            RankExp = data.RankExp;
            MaxFuel = maxFuel;
            NeedNextRankExp = needNextRankExp;
            Karuma = data.Karuma;
        }

        public uint Stamina { get; }

        public uint Yukichi { get; }

        public uint Coin { get; }

        public uint Mizu { get; }

        public uint Rank { get; }

        public uint RankExp { get; }

        public uint MaxFuel { get; }

        public uint NeedNextRankExp { get; }
        public uint Karuma { get; }

        public bool IsMaxFuel => Stamina >= MaxFuel;

        public UserData toData()
        {
            var data = new UserData
            {
                Coin = Coin,
                Mizu = Mizu,
                Rank = Rank,
                RankExp = RankExp,
                Stamina = Stamina,
                Yukichi = Yukichi,
                Karuma = Karuma
            };
            return data;
        }
    }
}