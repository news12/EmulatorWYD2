namespace Application.Enum
{

    public enum ClientStatus
    {
        Connection,
        Login,
        Numeric,
        Characters,
        Game,
        Disconnect
    }

    public enum EEquip
    {
        FACE,
        HELMT,
        ARMOR,
        PANT,
        GLOVE,
        BOOT,
        WEAPON1,
        WEAPON2,
        RING,
        AMULET,
        ORB,
        STONE,
        GUILD,
        PET,
        MOUNT,
        MANTLE
    }

    public enum EColor : uint
    {
        None = 0xFF000000,
        CornBlueName = None | 0xAAAAFF,
        CornflowerBlue = None | 0x6495ED,
        Yellow = None | 0xFFFF00,
        GoldenEscuro = None | 0xfeaa00,
        GreenYellow = None | 0xADFF2F,
        GoldenClaro = None | 0xfefeaa,
        DeepPink = None | 0xFF1493,
        Default = None | 0xCCAAFF,
        White = None | 0xFFFFFF,
        Blue = None | 0x0174DF,
        Orange = None | 0xCD6600,
        Speak = 0xFF00CD00,//verde padrão do gritar
        Snow = None | 0xFFFFFAFA,
        GhostWhite = None | 0xFFF8F8FF,
        WhiteSmoke = None | 0xFFF5F5F5,
        Gainsboro = None | 0xFFDCDCDC,
        FloralWhite = None | 0xFFFFFAF0,
        OldLace = None | 0xFFFDF5E6,
        Linen = None | 0xFFFAF0E6,
        AntiqueWhite = None | 0xFFFAEBD7,
        PapayaWhip = None | 0xFFFFEFD5,
        BlanchedAlmond = None | 0xFFFFEBCD,
        Bisque = None | 0xFFFFE4C4,
        PeachPuff = None | 0xFFFFDAB9,
        NavajoWhite = None | 0xFFFFDEAD,
        Moccasin = None | 0xFFFFE4B5,
        Cornsilk = None | 0xFFFFF8DC,
        Ivory = None | 0xFFFFFFF0,
        LemonChiffon = None | 0xFFFFFACD,
        Seashell = None | 0xFFFFF5EE,
        Honeydew = None | 0xFFF0FFF0,
        MintCream = None | 0xFFF5FFFA,
        Azure = None | 0xFFF0FFFF,
        AliceBlue = None | 0xFFF0F8FF,
        lavender = None | 0xFFE6E6FA,
        LavenderBlush = None | 0xFFFFF0F5,
        MistyRose = None | 0xFFFFE4E1,
        Black = None | 0xFF000000,
        DarkSlateGray = None | 0xFF2F4F4F,
        DimGrey = None | 0xFF696969,
        SlateGrey = None | 0xFF708090,
        LightSlateGray = None | 0xFF778899,
        Grey = None | 0xFFBEBEBE,
        LightGray = None | 0xFFD3D3D3,
        MidnightBlue = None | 0xFF191970,
        NavyBlue = None | 0xFF000080,
        CornflowerBlue2 = None | 0xFF6495ED,
        DarkSlateBlue = None | 0xFF483D8B,
        SlateBlue = None | 0xFF6A5ACD,
        MediumSlateBlue = None | 0xFF7B68EE,
        LightSlateBlue = None | 0xFF8470FF,
        MediumBlue = None | 0xFF0000CD,
        RoyalBlue = None | 0xFF4169E1,
        BlueNew = None | 0xFF0000FF,
        DodgerBlue = None | 0xFF1E90FF,
        DeepSkyBlue = None | 0xFF00BFFF,
        SkyBlue = None | 0xFF87CEEB,
        LightSkyBlue = None | 0xFF87CEFA,
        SeaGreen = None | 0xFF2E8B57,
        MediumSeaGreen = None | 0xFF3CB371,
        LightSeaGreen = None | 0xFF20B2AA,
        PaleGreen = None | 0xFF98FB98,
        SpringGreen = None | 0xFF00FF7F,
        LawnGreen = None | 0xFF7CFC00,
        Green = None | 0xFF00FF00,
        Red = None | 0xFF0000,
        Papa = None | 0xFFEFD5,
        BlackGround = None | 0x363636,
        DarkRed = None | 0x8B0000
    }

}
