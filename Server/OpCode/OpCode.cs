namespace Application.OpCode
{

    public enum OpCodeType : short
    {
        pLoginCheck = 0x78, //120
        pLogin = 0x20D,//525
        pCharacterLogin = 0x213,//531
        pCharacterCreate = 0x20F, //527
        pUpdateCity = 0x291,//657
        pMove = 0x36C,//876
        pNumeric = 0xFDE,//4062
    
        pMsgClient = 0x101,//257
        pLoginClient = 0x10A,//266
        pCreateCharacterClient = 0x110, //272
        pCharacterInfoClient = 0x114,//276
        pCharacterLoginClient = 0x144,//276
        pSpawanClient = 0x364, //868
        pMsgColorClient = 0xD1D,//3357
        pNumericFailClient = 0xFDF//4063
    }

    
}
